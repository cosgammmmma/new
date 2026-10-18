using System;
using System.Globalization;
using System.IO;
using System.Text;
using URWPGSim2D.Common;

namespace URWPGSim2D.Strategy
{
    internal static class Observability
    {
        public static bool Enabled
        {
            get { return true; }
        }

        public static void Record(Mission mission, int teamId, Decision[] decisions, string[] reasons)
        {
            if (mission == null || decisions == null || GlobalVar.MyTeam == null)
            {
                return;
            }

            int remainingCycles = mission.CommonPara.RemainingCycles;
            bool newMatch = lastRemainingCycles < 0 || remainingCycles > lastRemainingCycles + NewMatchCycleJump;
            if (newMatch)
            {
                ResetRuntimeState();
                initialTeamId = teamId;
                lastTeamId = teamId;
                WriteEvent(teamId, "VERSION", -1, -1, "schema=1;coordinateView=normalized-left;build=Stage4Observability");
            }
            else if (remainingCycles == lastRemainingCycles)
            {
                return;
            }
            matchCycle++;
            lastRemainingCycles = remainingCycles;

            if (newMatch)
            {
                WriteEvent(teamId, "MATCH_START", -1, -1, "totalSeconds=" + mission.CommonPara.TotalSeconds.ToString(CultureInfo.InvariantCulture));
            }
            else if (teamId != lastTeamId)
            {
                lastTeamId = teamId;
                sideSwapCycle = matchCycle;
                WriteEvent(teamId, "SIDE_SWAP", -1, -1, "coordinateView=normalized-left");
            }

            DetectAnomalies(teamId, decisions);
			if (matchCycle == 1 || matchCycle % SnapshotIntervalCycles == 0)
			{
				WriteSnapshot(teamId, decisions, reasons);
			}
        }

        public static void RecordException(Exception exception, Mission mission, int teamId)
        {
            int remainingCycles = mission == null ? -1 : mission.CommonPara.RemainingCycles;
            string detail = "remainingCycles=" + remainingCycles.ToString(CultureInfo.InvariantCulture)
                + ";type=" + exception.GetType().FullName + ";message=" + NormalizeText(exception.Message);
            WriteEvent(teamId, "DECISION_EXCEPTION", -1, -1, detail);
        }

        public static void RecordMatchStateReset(int teamId)
        {
            string detail = "matchSequence=" + GlobalVar.MatchSequence.ToString(CultureInfo.InvariantCulture)
                + ";resetCycle=" + GlobalVar.LastResetCycle.ToString(CultureInfo.InvariantCulture)
                + ";final=" + GlobalVar.final.ToString(CultureInfo.InvariantCulture)
                + ";goalBlocked=" + GlobalVar.flag_duqiumen.ToString(CultureInfo.InvariantCulture)
                + ";target0=" + GlobalVar.Bringing_BallID[0].ToString(CultureInfo.InvariantCulture)
                + ";target1=" + GlobalVar.Bringing_BallID[1].ToString(CultureInfo.InvariantCulture)
                + ";detour0=" + GlobalVar.detour_stage[0].ToString(CultureInfo.InvariantCulture)
                + ";flick0=" + GlobalVar.flick_ball_stage[0].ToString(CultureInfo.InvariantCulture);
            WriteEvent(teamId, "MATCH_STATE_RESET", -1, -1, detail);
        }

        public static void SetDecisionContext(int targetBall0, int targetBall1, string branch)
        {
            decisionTargetBall[0] = IsValidBall(targetBall0) ? targetBall0 : -1;
            decisionTargetBall[1] = IsValidBall(targetBall1) ? targetBall1 : -1;
            decisionBranch = String.IsNullOrEmpty(branch) ? "UNKNOWN" : branch;
        }

        public static void RecordTacticalEvent(string eventName, int fishId, int targetBall, string detail)
        {
            if (GlobalVar.teamId < 0 || GlobalVar.teamId > 1 || String.IsNullOrEmpty(eventName))
            {
                return;
            }
            WriteEvent(GlobalVar.teamId, eventName, fishId, targetBall,
                String.IsNullOrEmpty(detail) ? "state=UNKNOWN" : detail);
        }

        public static string GetCurrentBranch()
        {
            return GetStrategyBranch();
        }

        public static string RunDetectorSelfTest()
        {
            string[] requiredEvents = new string[]
            {
                "NO_TARGET",
                "TEAMMATE_TARGET_CONFLICT",
                "SCORED_BALL_TARGET",
                "PROLONGED_LOW_SPEED",
                "PROLONGED_SPIN",
                "REPEATED_WALL_CONTACT",
                "GOAL_BLOCKED",
                "BOUNDARY_STALEMATE",
                "TARGET_THRASHING"
            };
            for (int i = 0; i < requiredEvents.Length; i++)
            {
                int cycles = 0;
                bool active = false;
                if (AdvanceTestCondition(true, 2, ref cycles, ref active))
                {
                    return "FAIL:" + requiredEvents[i] + ":early-entry";
                }
                if (!AdvanceTestCondition(true, 2, ref cycles, ref active))
                {
                    return "FAIL:" + requiredEvents[i] + ":missing-entry";
                }
                if (!AdvanceTestCondition(false, 2, ref cycles, ref active))
                {
                    return "FAIL:" + requiredEvents[i] + ":missing-exit";
                }
                AppendSelfTestRecord(requiredEvents[i], "ENTER");
                AppendSelfTestRecord(requiredEvents[i], "EXIT");
            }
            return "PASS:" + string.Join(",", requiredEvents);
        }

        private static void AppendSelfTestRecord(string eventName, string state)
        {
            string path = Path.Combine(Path.GetTempPath(), "StrategyNew2V2_observability_selftest.log");
            File.AppendAllText(path, "SELFTEST\t" + eventName + "\t" + state + Environment.NewLine, Encoding.UTF8);
        }

        private static bool AdvanceTestCondition(bool condition, int thresholdCycles, ref int cycleCount, ref bool active)
        {
            cycleCount = condition ? cycleCount + 1 : 0;
            if (cycleCount >= thresholdCycles && !active)
            {
                active = true;
                return true;
            }
            if (!condition && active)
            {
                active = false;
                return true;
            }
            return false;
        }

        private static void DetectAnomalies(int teamId, Decision[] decisions)
        {
            int fishCount = Math.Min(2, Math.Min(decisions.Length, GlobalVar.MyTeam.Fishes.Count));
            bool noTarget = fishCount > 0;
            for (int fishId = 0; fishId < fishCount; fishId++)
            {
                int targetBall = GetTargetBall(fishId);
                noTarget = noTarget && targetBall < 0;
                bool scoredTarget = targetBall >= 0 && targetBall < GlobalVar.leftScore.Length && GlobalVar.leftScore[targetBall] == 1;
                UpdateCondition(teamId, "SCORED_BALL_TARGET", fishId, targetBall, scoredTarget, 5, ref scoredTargetCycles[fishId], ref scoredTargetActive[fishId]);

                RoboFish fish = GlobalVar.MyTeam.Fishes[fishId];
                bool lowSpeed = decisions[fishId].VCode > 0 && fish.VelocityMmPs < 20.0f;
                UpdateCondition(teamId, "PROLONGED_LOW_SPEED", fishId, targetBall, lowSpeed, 120, ref lowSpeedCycles[fishId], ref lowSpeedActive[fishId]);
                bool spinning = fish.VelocityMmPs < 30.0f && Math.Abs(fish.AngularVelocityRadPs) > 0.3f && decisions[fishId].TCode != 7;
                UpdateCondition(teamId, "PROLONGED_SPIN", fishId, targetBall, spinning, 120, ref spinCycles[fishId], ref spinActive[fishId]);
                bool wallContact = Math.Abs(fish.PositionMm.X) > 1400.0f || Math.Abs(fish.PositionMm.Z) > 900.0f;
                UpdateCondition(teamId, "REPEATED_WALL_CONTACT", fishId, targetBall, wallContact, 60, ref wallCycles[fishId], ref wallActive[fishId]);
                bool boundaryStalemate = wallContact && lowSpeed;
                UpdateCondition(teamId, "BOUNDARY_STALEMATE", fishId, targetBall, boundaryStalemate, 60, ref boundaryStalemateCycles[fishId], ref boundaryStalemateActive[fishId]);

                if (targetBall != previousTargetBall[fishId])
                {
					int previousTarget = previousTargetBall[fishId];
                    targetChanges[fishId]++;
                    previousTargetBall[fishId] = targetBall;
					if (matchCycle >= TargetChangeDiagnosticStartCycle && previousTarget >= -1)
					{
						WriteEvent(teamId, "TARGET_CHANGED", fishId, targetBall,
							"previousTarget=" + previousTarget.ToString(CultureInfo.InvariantCulture)
							+ ";branch=" + decisionBranch);
					}
                }
                targetWindowCycles[fishId]++;
                bool targetThrashing = targetWindowCycles[fishId] >= 120 && targetChanges[fishId] >= 8;
                UpdateCondition(teamId, "TARGET_THRASHING", fishId, targetBall, targetThrashing, 1, ref targetThrashCycles[fishId], ref targetThrashActive[fishId]);
                if (targetWindowCycles[fishId] >= 120)
                {
                    targetWindowCycles[fishId] = 0;
                    targetChanges[fishId] = 0;
                }
            }

            UpdateCondition(teamId, "NO_TARGET", -1, -1, noTarget, 100, ref noTargetCycles, ref noTargetActive);
            bool goalBlocked = GlobalVar.flag_duqiumen == 1;
            UpdateCondition(teamId, "GOAL_BLOCKED", -1, -1, goalBlocked, 5, ref goalBlockedCycles, ref goalBlockedActive);
            bool sameTarget = fishCount == 2 && GetTargetBall(0) >= 0 && GetTargetBall(0) == GetTargetBall(1);
            int sharedTarget = sameTarget ? GetTargetBall(0) : -1;
            UpdateCondition(teamId, "TEAMMATE_TARGET_CONFLICT", -1, sharedTarget, sameTarget, 30, ref sameTargetCycles, ref sameTargetActive);
        }

        private static void UpdateCondition(int teamId, string eventName, int fishId, int targetBall, bool condition, int thresholdCycles, ref int cycleCount, ref bool active)
        {
            cycleCount = condition ? cycleCount + 1 : 0;
            if (cycleCount >= thresholdCycles && !active)
            {
                active = true;
                WriteEvent(teamId, eventName, fishId, targetBall, "state=ENTER;thresholdCycles=" + thresholdCycles.ToString(CultureInfo.InvariantCulture));
            }
            else if (!condition && active)
            {
                active = false;
                WriteEvent(teamId, eventName, fishId, targetBall, "state=EXIT");
            }
        }

        private static void WriteSnapshot(int teamId, Decision[] decisions, string[] reasons)
        {
            EnsureHeader(teamId);
            int myScore = GlobalVar.MyTeam.Para.Score;
            int opponentScore = GlobalVar.OppTeam == null ? -1 : GlobalVar.OppTeam.Para.Score;
            int fishCount = Math.Min(2, Math.Min(decisions.Length, GlobalVar.MyTeam.Fishes.Count));
            for (int fishId = 0; fishId < fishCount; fishId++)
            {
                RoboFish fish = GlobalVar.MyTeam.Fishes[fishId];
                string reason = reasons != null && fishId < reasons.Length ? reasons[fishId] : "";
                string record = string.Join("\t", new string[]
                {
                    "SNAPSHOT",
                    matchCycle.ToString(CultureInfo.InvariantCulture),
                    GetMatchPhase(teamId),
                    teamId.ToString(CultureInfo.InvariantCulture),
                    myScore.ToString(CultureInfo.InvariantCulture),
                    opponentScore.ToString(CultureInfo.InvariantCulture),
                    fishId.ToString(CultureInfo.InvariantCulture),
                    FormatNumber(fish.PositionMm.X),
                    FormatNumber(fish.PositionMm.Z),
                    FormatNumber(fish.BodyDirectionRad),
                    FormatNumber(fish.VelocityMmPs),
                    FormatNumber(fish.AngularVelocityRadPs),
                    GetTargetBall(fishId).ToString(CultureInfo.InvariantCulture),
                    decisionBranch,
                    decisions[fishId].VCode.ToString(CultureInfo.InvariantCulture),
                    decisions[fishId].TCode.ToString(CultureInfo.InvariantCulture),
                    NormalizeText(reason)
                });
                AppendRecord(teamId, record);
            }
        }

        private static void WriteEvent(int teamId, string eventName, int fishId, int targetBall, string detail)
        {
            EnsureHeader(teamId);
            string record = string.Join("\t", new string[]
            {
                "EVENT",
                matchCycle.ToString(CultureInfo.InvariantCulture),
                GetMatchPhase(teamId),
                teamId.ToString(CultureInfo.InvariantCulture),
                eventName,
                fishId.ToString(CultureInfo.InvariantCulture),
                targetBall.ToString(CultureInfo.InvariantCulture),
                NormalizeText(detail)
            });
            AppendRecord(teamId, record);
        }

        private static void EnsureHeader(int teamId)
        {
            if (teamId < 0 || teamId >= headerWritten.Length || headerWritten[teamId])
            {
                return;
            }
            headerWritten[teamId] = true;
            AppendRecord(teamId, "# StrategyNew2V2 observability schema=1 coordinateView=normalized-left");
            AppendRecord(teamId, "# SNAPSHOT\tcycle\tphase\tteamId\tmyScore\topponentScore\tfishId\txMm\tzMm\tbodyDirectionRad\tvelocityMmPs\tangularVelocityRadPs\ttargetBall\tstrategyBranch\tVCode\tTCode\treason");
            AppendRecord(teamId, "# EVENT\tcycle\tphase\tteamId\teventName\tfishId\ttargetBall\tdetail");
        }

        private static void AppendRecord(int teamId, string record)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StrategyNew2V2_observability_team" + teamId.ToString(CultureInfo.InvariantCulture) + ".log");
                File.AppendAllText(path, record + Environment.NewLine, Encoding.UTF8);
            }
            catch
            {
            }
        }

        private static int GetTargetBall(int fishId)
        {
            if (fishId < 0 || fishId >= decisionTargetBall.Length)
            {
                return -1;
            }
            return decisionTargetBall[fishId];
        }

        private static bool IsValidBall(int targetBall)
        {
            return targetBall >= 0 && targetBall < GlobalVar.balls.Length;
        }

        private static string GetMatchPhase(int teamId)
        {
            if (initialTeamId < 0 || teamId == initialTeamId)
            {
                return "FIRST_HALF";
            }
            if (sideSwapCycle >= 0 && matchCycle - sideSwapCycle < 80)
            {
                return "HALFTIME_TRANSITION";
            }
            return "SECOND_HALF";
        }

        private static string GetStrategyBranch()
        {
            if (GlobalVar.final == 1)
            {
                return "FINAL";
            }
            if (GlobalVar.Paishu >= 4800)
            {
                return "LATE_GAME_CONTEST";
            }
            if (GlobalVar.Paishu >= 4500)
            {
                return "GOAL_AREA_PRIORITY";
            }
            if (GlobalVar.Paishu > 3000 && GlobalVar.Paishu <= 3080)
            {
                return "HALFTIME_SPECIAL";
            }
            if (GlobalVar.detour_stage[0] != 0 || GlobalVar.detour_stage[1] != 0)
            {
                return "OPPONENT_DETOUR";
            }
            if (GlobalVar.flick_ball_stage[0] != 0 || GlobalVar.flick_ball_stage[1] != 0)
            {
                return "STALEMATE_FLICK";
            }
            return "NORMAL";
        }

        private static string NormalizeText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return "";
            }
            text = text.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
            return text.Length <= MaxReasonLength ? text : text.Substring(0, MaxReasonLength);
        }

        private static string FormatNumber(float value)
        {
            return value.ToString("0.0000", CultureInfo.InvariantCulture);
        }

        private static void ResetRuntimeState()
        {
            noTargetCycles = 0;
            noTargetActive = false;
            sameTargetCycles = 0;
            sameTargetActive = false;
            goalBlockedCycles = 0;
            goalBlockedActive = false;
            sideSwapCycle = -1;
            matchCycle = 0;
            for (int i = 0; i < 2; i++)
            {
                lowSpeedCycles[i] = 0;
                spinCycles[i] = 0;
                wallCycles[i] = 0;
                boundaryStalemateCycles[i] = 0;
                scoredTargetCycles[i] = 0;
                targetWindowCycles[i] = 0;
                targetChanges[i] = 0;
                targetThrashCycles[i] = 0;
                previousTargetBall[i] = -2;
                lowSpeedActive[i] = false;
                spinActive[i] = false;
                wallActive[i] = false;
                boundaryStalemateActive[i] = false;
                scoredTargetActive[i] = false;
                targetThrashActive[i] = false;
            }
        }

        private const int SnapshotIntervalCycles = 50;
        private const int MaxReasonLength = 500;
        private const int NewMatchCycleJump = 100;
		private const int TargetChangeDiagnosticStartCycle = 4000;
        private static int lastRemainingCycles = -1;
        private static int matchCycle;
        private static int initialTeamId = -1;
        private static int lastTeamId = -1;
        private static int sideSwapCycle = -1;
        private static bool[] headerWritten = new bool[2];
        private static int noTargetCycles;
        private static bool noTargetActive;
        private static int sameTargetCycles;
        private static bool sameTargetActive;
        private static int goalBlockedCycles;
        private static bool goalBlockedActive;
        private static int[] lowSpeedCycles = new int[2];
        private static int[] spinCycles = new int[2];
        private static int[] wallCycles = new int[2];
        private static int[] boundaryStalemateCycles = new int[2];
        private static int[] scoredTargetCycles = new int[2];
        private static int[] targetWindowCycles = new int[2];
        private static int[] targetChanges = new int[2];
        private static int[] targetThrashCycles = new int[2];
        private static int[] previousTargetBall = new int[] { -2, -2 };
        private static bool[] lowSpeedActive = new bool[2];
        private static bool[] spinActive = new bool[2];
        private static bool[] wallActive = new bool[2];
        private static bool[] boundaryStalemateActive = new bool[2];
        private static bool[] scoredTargetActive = new bool[2];
        private static bool[] targetThrashActive = new bool[2];
        private static int[] decisionTargetBall = new int[] { -1, -1 };
        private static string decisionBranch = "UNKNOWN";
    }
}
