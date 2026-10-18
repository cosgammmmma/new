using System;
using System.Collections.Generic;
using System.Globalization;
using xna = Microsoft.Xna.Framework;
using URWPGSim2D.Common;
using URWPGSim2D.StrategyHelper;
using URWPGSim2D.StrategyLoader;
using FrameDiagnostics;

namespace URWPGSim2D.Strategy
{
    public class Strategy : MarshalByRefObject, IStrategy
    {
        private const int SpecialFishMaxVCode = 15;
        private const int NormalFishMaxVCode = 8;
        private const float FieldMargin = 220f;
        private const float StuckThreshold = 10f;
        private const int StuckLimit = 22;
        // 捉捕手需要贴近障碍边的猎物，余量取小；躲避手/防御手取大，避免擦墙卡死。
        private const float HunterClearance = 120f;
        private const float EvaderClearance = 160f;

        private Decision[] decisions = null;
        private int[] settleTimes = null;
        private int[] stuckFrames = null;
        private xna.Vector3[] lastPositions = null;
        private bool watchdogReady = false;
        private int currentTarget = -1;
        private int lastRole = -1;
        private static FrameLogger _diagLogger;
        private static int _diagLastRemaining = -1;
        private static readonly string[] DiagFields = new string[] { "cycle", "fish_id", "role", "vcode", "tcode", "x", "z", "body_dir", "stuck" };

        #region reserved code never be changed or removed
        public override object InitializeLifetimeService()
        {
            return null;
        }
        #endregion

        public string GetTeamName()
        {
            return "NEU666_V3";
        }

        public Decision[] GetDecision(Mission mission, int teamId)
        {
            EnsureState(mission);
            EnsureDiagnostics(mission, teamId);

            for (int i = 0; i < mission.CommonPara.FishCntPerTeam; i++)
            {
                decisions[i].VCode = 0;
                decisions[i].TCode = 7;
            }

            // 第十九届规则：左半场一方进攻（1 号特殊鱼为捉捕手），右半场一方防守；交换半场后攻守互换。
            Team<RoboFish> myTeam = mission.TeamsRef[teamId];
            bool isAttacking = myTeam.Para.MyHalfCourt == HalfCourt.LEFT;
            int role = isAttacking ? 1 : 0;
            if (role != lastRole)
            {
                lastRole = role;
                currentTarget = -1;
                watchdogReady = false;
            }

            UpdateWatchdog(mission, teamId);

            if (isAttacking)
            {
                RunAttackStrategy(mission, teamId);
            }
            else
            {
                RunDefenseStrategy(mission, teamId);
            }

            WriteDiagFrame(mission, teamId);
            return decisions;
        }

        private void EnsureDiagnostics(Mission mission, int teamId)
        {
            try
            {
                int currentRemaining = mission.CommonPara.RemainingCycles;
                if (_diagLogger != null && currentRemaining > _diagLastRemaining + 100)
                {
                    _diagLogger.Dispose();
                    _diagLogger = null;
                }
                if (_diagLogger == null)
                {
                    string dirPath = @"E:\progaram\URWPGSim2D\logs";
                    System.IO.Directory.CreateDirectory(dirPath);
                    FrameLoggerOptions opts = new FrameLoggerOptions();
                    opts.DirectoryPath = dirPath;
                    opts.Mission = "fight-for-live";
                    opts.TeamId = teamId.ToString(CultureInfo.InvariantCulture);
                    opts.FileNamePrefix = "fight_for_live";
                    opts.Enabled = true;
                    _diagLogger = new FrameLogger(opts);
                    _diagLogger.Begin(new List<string>(DiagFields));
                    _diagLastRemaining = currentRemaining;
                }
            }
            catch { }
        }

        private void WriteDiagFrame(Mission mission, int teamId)
        {
            try
            {
                if (_diagLogger == null) return;
                Team<RoboFish> myTeam = mission.TeamsRef[teamId];
                bool isAttacking = myTeam.Para.MyHalfCourt == HalfCourt.LEFT;
                int cycle = mission.CommonPara.TotalSeconds * 1000 / mission.CommonPara.MsPerCycle - mission.CommonPara.RemainingCycles;
                List<FrameRow> rows = new List<FrameRow>(4);
                for (int i = 0; i < 4; i++)
                {
                    Decision dec = decisions[i];
                    RoboFish fish = myTeam.Fishes[i];
                    string roleStr = isAttacking ? ((i == 0) ? "hunter" : "idle") : ((i == 0) ? "blocker" : "evader");
                    rows.Add(new FrameRow(new string[] {
                        cycle.ToString(CultureInfo.InvariantCulture),
                        i.ToString(CultureInfo.InvariantCulture),
                        roleStr,
                        dec.VCode.ToString(CultureInfo.InvariantCulture),
                        dec.TCode.ToString(CultureInfo.InvariantCulture),
                        fish.PositionMm.X.ToString("F1", CultureInfo.InvariantCulture),
                        fish.PositionMm.Z.ToString("F1", CultureInfo.InvariantCulture),
                        fish.BodyDirectionRad.ToString("F4", CultureInfo.InvariantCulture),
                        stuckFrames[i].ToString(CultureInfo.InvariantCulture)
                    }));
                }
                _diagLogger.WriteFrame(rows);
            }
            catch { }
        }

        private void EnsureState(Mission mission)
        {
            int fishCount = mission.CommonPara.FishCntPerTeam;
            if (decisions == null || decisions.Length != fishCount)
            {
                decisions = new Decision[fishCount];
            }

            if (settleTimes == null || settleTimes.Length != fishCount)
            {
                settleTimes = new int[fishCount];
            }

            if (stuckFrames == null || stuckFrames.Length != fishCount)
            {
                stuckFrames = new int[fishCount];
            }

            if (lastPositions == null || lastPositions.Length != fishCount)
            {
                lastPositions = new xna.Vector3[fishCount];
                watchdogReady = false;
            }
        }

        private void UpdateWatchdog(Mission mission, int teamId)
        {
            Team<RoboFish> myTeam = mission.TeamsRef[teamId];
            if (!watchdogReady)
            {
                for (int i = 0; i < myTeam.Fishes.Count; i++)
                {
                    lastPositions[i] = myTeam.Fishes[i].PositionMm;
                    stuckFrames[i] = 0;
                }

                watchdogReady = true;
                return;
            }

            for (int i = 0; i < myTeam.Fishes.Count; i++)
            {
                float moved = Distance2D(myTeam.Fishes[i].PositionMm, lastPositions[i]);
                if (moved < StuckThreshold)
                {
                    stuckFrames[i]++;
                }
                else
                {
                    stuckFrames[i] = 0;
                }

                lastPositions[i] = myTeam.Fishes[i].PositionMm;
            }
        }

        private void RunAttackStrategy(Mission mission, int teamId)
        {
            Team<RoboFish> myTeam = mission.TeamsRef[teamId];
            Team<RoboFish> opponentTeam = mission.TeamsRef[1 - teamId];
            RoboFish hunter = myTeam.Fishes[0];
            int targetIndex = SelectAttackTarget(mission, teamId);

            if (targetIndex < 0)
            {
                xna.Vector3 standby = new xna.Vector3(mission.EnvRef.FieldInfo.RightMm * 0.3f, 0, 0);
                DriveFish(mission, hunter, 0, standby, 0f, SpecialFishMaxVCode, true, false, false, HunterClearance);
                return;
            }

            RoboFish prey = opponentTeam.Fishes[targetIndex];
            RoboFish defender = opponentTeam.Fishes[0];
            xna.Vector3 intercept = BuildAttackInterceptPoint(mission, hunter, prey, defender);
            float desiredDir = DirectionTo(intercept - hunter.PositionMm);
            DriveFish(mission, hunter, 0, intercept, desiredDir, SpecialFishMaxVCode, true, false, false, HunterClearance);
        }

        private void RunDefenseStrategy(Mission mission, int teamId)
        {
            Team<RoboFish> myTeam = mission.TeamsRef[teamId];
            Team<RoboFish> opponentTeam = mission.TeamsRef[1 - teamId];
            RoboFish attacker = opponentTeam.Fishes[0];
            int threatenedIndex = SelectMostThreatenedFish(mission, myTeam, attacker);

            for (int fishIndex = 1; fishIndex <= 3; fishIndex++)
            {
                if (IsCurrentTeamFishCaught(mission, myTeam, fishIndex))
                {
                    decisions[fishIndex].VCode = 0;
                    decisions[fishIndex].TCode = 7;
                    continue;
                }

                RoboFish fish = myTeam.Fishes[fishIndex];
                xna.Vector3 dodgePoint = BuildDodgePoint(mission, fish, attacker, fishIndex, threatenedIndex);
                float desiredDir = DirectionTo(dodgePoint - fish.PositionMm);
                bool urgentEscape = fishIndex == threatenedIndex || Distance2D(fish.PositionMm, attacker.PositionMm) < 520f;
                DriveFish(mission, fish, fishIndex, dodgePoint, desiredDir, NormalFishMaxVCode, false, false, urgentEscape, EvaderClearance);
            }

            xna.Vector3 blockPoint = BuildAggressiveBlockPoint(mission, attacker, myTeam, threatenedIndex);
            float blockDir = DirectionTo(attacker.PositionMm - blockPoint);
            DriveFish(mission, myTeam.Fishes[0], 0, blockPoint, blockDir, SpecialFishMaxVCode, true, true, false, EvaderClearance);
        }

        // 猎物是对方 2~4 号（数组下标 1~3）；返回数组下标，全部被捕时返回 -1。
        private int SelectAttackTarget(Mission mission, int teamId)
        {
            Team<RoboFish> myTeam = mission.TeamsRef[teamId];
            Team<RoboFish> opponentTeam = mission.TeamsRef[1 - teamId];
            string opponentColor = GetTeamColor(mission, opponentTeam.Para.MyHalfCourt);

            Vec2[] preys = new Vec2[3];
            bool[] caught = new bool[3];
            for (int i = 0; i < 3; i++)
            {
                preys[i] = ToVec2(opponentTeam.Fishes[i + 1].PositionMm);
                caught[i] = IsFishCaught(mission, opponentColor, i + 2);
            }

            int pick = TargetSelector.Pick(
                ToVec2(myTeam.Fishes[0].PositionMm),
                ToVec2(opponentTeam.Fishes[0].PositionMm),
                preys, caught, currentTarget - 1,
                BuildObstacles(mission), BuildArena(mission), HunterClearance);

            currentTarget = pick < 0 ? -1 : pick + 1;
            return currentTarget;
        }

        private int SelectMostThreatenedFish(Mission mission, Team<RoboFish> myTeam, RoboFish attacker)
        {
            int bestIndex = -1;
            float bestScore = float.MinValue;
            for (int fishIndex = 1; fishIndex <= 3; fishIndex++)
            {
                if (IsCurrentTeamFishCaught(mission, myTeam, fishIndex))
                {
                    continue;
                }

                RoboFish fish = myTeam.Fishes[fishIndex];
                float attackerDistance = Distance2D(fish.PositionMm, attacker.PositionMm);
                float sameLaneRisk = 460f - Math.Abs(fish.PositionMm.Z - attacker.PositionMm.Z);
                float edgeRisk = 320f - DistanceToNearestFieldEdge(mission, fish.PositionMm);
                float deepAttackRisk = attacker.PositionMm.X - 250f;
                float obstacleRisk = 260f - DistanceToNearestObstacle(mission, fish.PositionMm);
                float imminentRisk = attackerDistance < 520f ? 420f - attackerDistance : 0f;
                float score = 3200f - attackerDistance
                    + sameLaneRisk
                    + edgeRisk
                    + deepAttackRisk
                    + 0.6f * obstacleRisk
                    + 1.4f * imminentRisk;
                if (score > bestScore)
                {
                    bestScore = score;
                    bestIndex = fishIndex;
                }
            }

            return bestIndex == -1 ? 1 : bestIndex;
        }

        private xna.Vector3 BuildAttackInterceptPoint(Mission mission, RoboFish hunter, RoboFish prey, RoboFish defender)
        {
            Field field = mission.EnvRef.FieldInfo;
            float leadSeconds = Distance2D(hunter.PositionMm, prey.PositionMm) > 900f ? 0.45f : 0.25f;
            xna.Vector3 predicted = prey.PositionMm + VelocityVector(prey, leadSeconds);
            xna.Vector3 intercept = predicted + new xna.Vector3(120f, 0, prey.PositionMm.Z >= 0 ? 80f : -80f);

            float defenderDistance = Distance2D(defender.PositionMm, intercept);
            if (defenderDistance < 380f)
            {
                intercept.Z += intercept.Z >= defender.PositionMm.Z ? 180f : -180f;
            }

            if (field.RightMm - prey.PositionMm.X < 260f)
            {
                intercept.X = prey.PositionMm.X - 70f;
            }

            if (hunter.PositionMm.X < -420f && intercept.X > -80f && Math.Abs(intercept.Z) < 920f)
            {
                intercept.Z = SelectCorridorZ(prey.PositionMm.Z, defender.PositionMm.Z);
            }

            foreach (RectangularObstacle obstacle in mission.EnvRef.ObstaclesRect)
            {
                float dx = Math.Abs(intercept.X - obstacle.PositionMm.X);
                float dz = Math.Abs(intercept.Z - obstacle.PositionMm.Z);
                if (dx < obstacle.LengthMm * 0.5f + 180f && dz < obstacle.WidthMm * 0.5f + 180f)
                {
                    intercept.Z = obstacle.PositionMm.Z + (intercept.Z >= obstacle.PositionMm.Z ? 260f : -260f);
                }
            }

            return ClampToField(mission, intercept, FieldMargin);
        }

        // 平时守在右半场三条泳道的锚点；捉捕手逼近时交给 DodgePlanner 选点（预测、防贴墙、防擦身）。
        private xna.Vector3 BuildDodgePoint(Mission mission, RoboFish fish, RoboFish attacker, int fishIndex, int threatenedIndex)
        {
            Field field = mission.EnvRef.FieldInfo;
            float[] laneZs = new float[] { -940f, 0f, 940f };
            float anchorX = field.RightMm - (fishIndex == threatenedIndex ? 320f : 430f);
            Vec2 home = new Vec2(anchorX, laneZs[fishIndex - 1]);

            Vec2 p = DodgePlanner.Plan(
                ToVec2(fish.PositionMm), home,
                ToVec2(attacker.PositionMm), ToVec2(VelocityVector(attacker, 1f)),
                BuildObstacles(mission), BuildArena(mission), EvaderClearance);

            return ClampToField(mission, ToVector3(p), FieldMargin);
        }

        private xna.Vector3 BuildAggressiveBlockPoint(Mission mission, RoboFish attacker, Team<RoboFish> myTeam, int protectedFishIndex)
        {
            Field field = mission.EnvRef.FieldInfo;
            if (protectedFishIndex < 1 || protectedFishIndex > 3 || IsCurrentTeamFishCaught(mission, myTeam, protectedFishIndex))
            {
                return new xna.Vector3(780f, 0, 0);
            }

            RoboFish protectedFish = myTeam.Fishes[protectedFishIndex];
            xna.Vector3 corridor = protectedFish.PositionMm - attacker.PositionMm;
            xna.Vector3 unit = Normalize2D(corridor);
            xna.Vector3 normal = new xna.Vector3(-unit.Z, 0, unit.X);

            xna.Vector3 point = attacker.PositionMm + corridor * 0.45f + normal * 90f;
            point.X = Clamp(point.X, 500f, field.RightMm - 520f);
            point.Z = Clamp(point.Z, field.TopMm + 300f, field.BottomMm - 300f);

            if (Distance2D(attacker.PositionMm, protectedFish.PositionMm) < 520f)
            {
                point = attacker.PositionMm + corridor * 0.38f + normal * 110f;
            }

            if (attacker.PositionMm.X < 320f)
            {
                point = new xna.Vector3(620f, 0, Clamp(attacker.PositionMm.Z * 0.75f, field.TopMm + 360f, field.BottomMm - 360f));
            }
            else if (attacker.PositionMm.X > 700f)
            {
                point.X = Math.Max(760f, attacker.PositionMm.X - 80f);
            }

            point.Z += Clamp((protectedFish.PositionMm.Z - attacker.PositionMm.Z) * 0.15f, -90f, 90f);

            return ClampToField(mission, point, FieldMargin);
        }

        private void DriveFish(Mission mission, RoboFish fish, int fishIndex, xna.Vector3 rawTarget, float desiredDir, int maxVCode, bool aggressive, bool defenseRole, bool urgentEscape, float clearance)
        {
            xna.Vector3 goal = AddBoundaryOffset(mission, fish, rawTarget);
            // 三块障碍膨胀后连成一堵墙，直线目标被挡时改走 Navigator 给出的绕行角点。
            xna.Vector3 target = ToVector3(Navigator.NextWaypoint(
                ToVec2(fish.PositionMm), ToVec2(goal), BuildObstacles(mission), BuildArena(mission), clearance));
            bool detouring = Distance2D(target, goal) > 1f;
            if (detouring)
            {
                desiredDir = DirectionTo(target - fish.PositionMm);
            }

            float distance = Distance2D(fish.PositionMm, target);
            float settleDistance = aggressive ? (defenseRole ? 150f : 170f) : 150f;

            if (!detouring && distance < settleDistance)
            {
                Helpers.PoseToPose(ref decisions[fishIndex], fish, target, desiredDir, aggressive ? (defenseRole ? 22f : 24f) : 18f, aggressive ? 100f : 90f,
                    mission.CommonPara.MsPerCycle, ref settleTimes[fishIndex]);
                decisions[fishIndex].VCode = Math.Min(decisions[fishIndex].VCode, Math.Min(maxVCode, aggressive ? (defenseRole ? 5 : 4) : (urgentEscape ? 6 : 5)));
            }
            else
            {
                settleTimes[fishIndex] = 0;
                int farSpeed = aggressive
                    ? Math.Min(maxVCode, defenseRole ? 13 : 10)
                    : Math.Min(maxVCode, urgentEscape ? 8 : 6);
                int nearSpeed = aggressive
                    ? Math.Min(maxVCode, defenseRole ? 8 : 6)
                    : Math.Min(maxVCode, urgentEscape ? 7 : 5);
                Helpers.Dribble(ref decisions[fishIndex], fish, target, desiredDir,
                    aggressive ? (defenseRole ? 9f : 10f) : (urgentEscape ? 8f : 7f),
                    aggressive ? (defenseRole ? 30f : 32f) : (urgentEscape ? 26f : 24f),
                    aggressive ? (defenseRole ? 260f : 280f) : (urgentEscape ? 250f : 220f),
                    farSpeed, nearSpeed, aggressive ? 7 : 8, mission.CommonPara.MsPerCycle, true);
                decisions[fishIndex].VCode = Math.Min(decisions[fishIndex].VCode, maxVCode);
            }

            ApplyWatchdogEscape(mission, fish, fishIndex, target, maxVCode);

            if (detouring)
            {
                return;
            }

            if (aggressive && distance < 80f)
            {
                decisions[fishIndex].VCode = 0;
                decisions[fishIndex].TCode = 7;
            }
            else if (!aggressive && distance < 90f)
            {
                decisions[fishIndex].VCode = Math.Min(maxVCode, urgentEscape ? 6 : 5);
            }
        }

        private void ApplyWatchdogEscape(Mission mission, RoboFish fish, int fishIndex, xna.Vector3 target, int maxVCode)
        {
            if (stuckFrames[fishIndex] < StuckLimit)
            {
                return;
            }

            float lateralSign = fishIndex % 2 == 0 ? 1f : -1f;
            xna.Vector3 escapePoint = target + new xna.Vector3(fishIndex == 0 ? 80f : 0f, 0, 220f * lateralSign);
            escapePoint = ClampToField(mission, escapePoint, FieldMargin);
            float dir = DirectionTo(escapePoint - fish.PositionMm);
            Helpers.Dribble(ref decisions[fishIndex], fish, escapePoint, dir, 6f, 35f, 260f,
                Math.Min(maxVCode, fishIndex == 0 ? 9 : 7), Math.Min(maxVCode, 5), 6, mission.CommonPara.MsPerCycle, true);
            decisions[fishIndex].VCode = Math.Min(decisions[fishIndex].VCode, maxVCode);
            stuckFrames[fishIndex] = 8;
        }

        // 只保留边界斥力；障碍由 Navigator 负责，旧的障碍斥力会把目标推进障碍之间的缝里。
        private xna.Vector3 AddBoundaryOffset(Mission mission, RoboFish fish, xna.Vector3 target)
        {
            xna.Vector3 offset = ComputeBoundaryRepulsion(mission, fish.PositionMm);

            if (offset.Length() > 1f)
            {
                target += Normalize2D(offset) * Math.Min(offset.Length(), 280f);
            }

            return ClampToField(mission, target, FieldMargin);
        }

        private xna.Vector3 ComputeBoundaryRepulsion(Mission mission, xna.Vector3 position)
        {
            Field field = mission.EnvRef.FieldInfo;
            xna.Vector3 repulsion = xna.Vector3.Zero;

            if (position.X < field.LeftMm + 260f)
            {
                repulsion.X += field.LeftMm + 260f - position.X;
            }
            else if (position.X > field.RightMm - 260f)
            {
                repulsion.X -= position.X - (field.RightMm - 260f);
            }

            if (position.Z < field.TopMm + 220f)
            {
                repulsion.Z += field.TopMm + 220f - position.Z;
            }
            else if (position.Z > field.BottomMm - 220f)
            {
                repulsion.Z -= position.Z - (field.BottomMm - 220f);
            }

            return repulsion;
        }

        #region adapters: 平台数据 -> 纯几何模块

        private static Vec2 ToVec2(xna.Vector3 v)
        {
            return new Vec2(v.X, v.Z);
        }

        private static xna.Vector3 ToVector3(Vec2 v)
        {
            return new xna.Vector3(v.X, 0, v.Z);
        }

        private static Arena BuildArena(Mission mission)
        {
            Field field = mission.EnvRef.FieldInfo;
            return new Arena(field.LeftMm, field.RightMm, field.TopMm, field.BottomMm);
        }

        // 障碍若有旋转，取旋转后矩形的轴对齐外接盒（保守）。
        private static Box[] BuildObstacles(Mission mission)
        {
            Box[] boxes = new Box[mission.EnvRef.ObstaclesRect.Count];
            for (int i = 0; i < boxes.Length; i++)
            {
                RectangularObstacle o = mission.EnvRef.ObstaclesRect[i];
                float c = Math.Abs((float)Math.Cos(o.DirectionRad));
                float s = Math.Abs((float)Math.Sin(o.DirectionRad));
                float hl = o.LengthMm * 0.5f;
                float hw = o.WidthMm * 0.5f;
                boxes[i] = new Box(o.PositionMm.X, o.PositionMm.Z, c * hl + s * hw, s * hl + c * hw);
            }

            return boxes;
        }

        #endregion

        private float SelectCorridorZ(float preferredZ, float opponentDefenderZ)
        {
            float[] lanes = new float[] { -1050f, -350f, 350f, 1050f };
            float bestLane = lanes[0];
            float bestScore = float.MaxValue;

            for (int i = 0; i < lanes.Length; i++)
            {
                float lane = lanes[i];
                float score = Math.Abs(lane - preferredZ) + 0.55f * Math.Abs(lane - opponentDefenderZ);
                if (score < bestScore)
                {
                    bestScore = score;
                    bestLane = lane;
                }
            }

            return bestLane;
        }

        private bool IsCurrentTeamFishCaught(Mission mission, Team<RoboFish> myTeam, int fishIndex)
        {
            string teamColor = GetTeamColor(mission, myTeam.Para.MyHalfCourt);
            return IsFishCaught(mission, teamColor, fishIndex + 1);
        }

        private bool IsFishCaught(Mission mission, string color, int fishNumber)
        {
            string key = "Is" + color + "Fish" + fishNumber.ToString() + "Caught";
            if (!mission.HtMissionVariables.ContainsKey(key))
            {
                return false;
            }

            object value = mission.HtMissionVariables[key];
            try
            {
                return Convert.ToInt32(value) != 0;
            }
            catch
            {
                string text = value == null ? "0" : value.ToString();
                return text != "0";
            }
        }

        private string GetTeamColor(Mission mission, HalfCourt halfCourt)
        {
            bool leftIsYellow = mission.CommonPara.IsExchangedHalfCourt;
            if (halfCourt == HalfCourt.LEFT)
            {
                return leftIsYellow ? "Yellow" : "Red";
            }

            return leftIsYellow ? "Red" : "Yellow";
        }

        private static xna.Vector3 VelocityVector(RoboFish fish, float seconds)
        {
            return new xna.Vector3(
                fish.VelocityMmPs * (float)Math.Cos(fish.VelocityDirectionRad) * seconds,
                0,
                fish.VelocityMmPs * (float)Math.Sin(fish.VelocityDirectionRad) * seconds);
        }

        private static xna.Vector3 ClampToField(Mission mission, xna.Vector3 target, float margin)
        {
            Field field = mission.EnvRef.FieldInfo;
            target.X = Clamp(target.X, field.LeftMm + margin, field.RightMm - margin);
            target.Z = Clamp(target.Z, field.TopMm + margin, field.BottomMm - margin);
            target.Y = 0;
            return target;
        }

        private static float Distance2D(xna.Vector3 a, xna.Vector3 b)
        {
            float dx = a.X - b.X;
            float dz = a.Z - b.Z;
            return (float)Math.Sqrt(dx * dx + dz * dz);
        }

        private float DistanceToNearestObstacle(Mission mission, xna.Vector3 point)
        {
            float best = float.MaxValue;
            foreach (RectangularObstacle obstacle in mission.EnvRef.ObstaclesRect)
            {
                float dx = Math.Max(0f, Math.Abs(point.X - obstacle.PositionMm.X) - obstacle.LengthMm * 0.5f);
                float dz = Math.Max(0f, Math.Abs(point.Z - obstacle.PositionMm.Z) - obstacle.WidthMm * 0.5f);
                float distance = (float)Math.Sqrt(dx * dx + dz * dz);
                if (distance < best)
                {
                    best = distance;
                }
            }

            return best;
        }

        private float DistanceToNearestFieldEdge(Mission mission, xna.Vector3 point)
        {
            Field field = mission.EnvRef.FieldInfo;
            float left = Math.Abs(point.X - field.LeftMm);
            float right = Math.Abs(field.RightMm - point.X);
            float top = Math.Abs(point.Z - field.TopMm);
            float bottom = Math.Abs(field.BottomMm - point.Z);
            return Math.Min(Math.Min(left, right), Math.Min(top, bottom));
        }

        private static float DirectionTo(xna.Vector3 vector)
        {
            if (vector.Length() < 1f)
            {
                return 0f;
            }

            return (float)Math.Atan2(vector.Z, vector.X);
        }

        private static xna.Vector3 Normalize2D(xna.Vector3 vector)
        {
            vector.Y = 0;
            float length = (float)Math.Sqrt(vector.X * vector.X + vector.Z * vector.Z);
            if (length < 1e-4f)
            {
                return xna.Vector3.Zero;
            }

            return new xna.Vector3(vector.X / length, 0, vector.Z / length);
        }

        private static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                return min;
            }

            if (value > max)
            {
                return max;
            }

            return value;
        }
    }
}
