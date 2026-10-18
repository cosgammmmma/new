using System;
using System.Collections.Generic;

using xna = Microsoft.Xna.Framework;
using URWPGSim2D.Common;
using URWPGSim2D.StrategyLoader;
using System.Globalization;
using FrameDiagnostics;

namespace URWPGSim2D.Strategy
{
    public class Strategy : MarshalByRefObject, IStrategy
    {
        private const int HostageCount = 2;
        private const int StopVCode = 0;
        private const int StraightTCode = 7;
        private const int AttackFastVCode = 12;
        private const int AttackCruiseVCode = 10;
        private const int AttackTrimVCode = 9;
        private const float BallPushDistance = 155f;
        private const float FishNoseOffset = 105f;
        private const float NoseContactDistance = 160f;
        private const float NoseContactLostDistance = 300f;
        private const float ContactHoldDistance = 380f;
        private const float PushAlignmentThreshold = 0.52f;
        private const int DefenseFastVCode = 11;
        private const float GoalX = 2050f;
        private const float GoalHalfHeight = 420f;
        private const float FieldMargin = 150f;
        private const float ObstaclePadding = 90f;
        private const float SupportDistance = 210f;
        private const float PushThroughDistance = 180f;
        private const float PushSwitchDistance = 420f;
        private const float SupportLockDistance = 280f;
        private const float RepositionDistance = 380f;
        private const float BallWaypointReachDistance = 170f;
        private const float FishGuideReachDistance = 180f;
        private const float BehindAlignmentThreshold = 0.85f;
        private const float BehindAcquireDistance = 220f;
        private const float PathRetargetDistance = 180f;
        private const int CarrierRecoveryDuration = 12;
        private const float OrbitSideDistance = 180f;
        private const float OrbitRearDistance = 260f;
        private const float FishRoutePadding = 85f;
        private const float BallRoutePadding = 95f;
        private const float NavigationGridStep = 100f;
        private const float NavigationNeighborDistance = 250f;
        private const float NavigationAnchorDistance = 1000f;
        private const float CorridorOuterZ = 950f;
        private const float CorridorInnerZ = 700f;
        private const float CorridorEntryX = -900f;
        private const float CorridorTurnX = 900f;
        private const float CorridorGoalX = 1550f;
        private const float WaypointReachDistance = 120f;
        private const string DebugSessionId = "rescue-dribble-wall";
        private const string DebugRunId = "pre-fix";
        private const string DebugServerUrl = "http://127.0.0.1:7777/event";

        private static FrameLogger _diagLogger;
        private static int _diagLastRemaining = -1;
        private static readonly string[] DiagFields = new string[] { "cycle", "fish_id", "vcode", "tcode", "x", "z", "body_dir", "debug_phase", "carrier_idx", "carrier_staged" };

        // 调试用：每条鱼当前运球控制的状态串，供 Harness 打印（诊断 push/orbit/reverse 分支）。
        public static readonly string[] DebugPhase = new string[8];

        private Decision[] decisions;
        private readonly int[] carrierFishIndex = { -1, -1 };
        private readonly int[] carrierRouteIndex = new int[HostageCount];
        private readonly int[] carrierPhase = new int[HostageCount];
        private readonly bool[] carrierHasContact = new bool[HostageCount];
        private readonly bool[] carrierStaged = new bool[HostageCount];

        private readonly float[] carrierRouteSide = new float[HostageCount];
        private readonly float[] blockerSide = new float[HostageCount];
        private readonly xna.Vector3[] carrierLastBallPosition = new xna.Vector3[HostageCount];
        private readonly bool[] carrierBallPositionInitialized = new bool[HostageCount];
        private readonly int[] carrierStalledCycles = new int[HostageCount];
        private readonly int[] carrierRecoveryCycles = new int[HostageCount];
        
        private readonly List<xna.Vector3>[] cachedFishPath = new List<xna.Vector3>[HostageCount];
        private readonly xna.Vector3[] cachedPathTarget = new xna.Vector3[HostageCount];
        private readonly int[] cachedPathWaypointIndex = new int[HostageCount];

        private struct ObstacleBox
        {
            public float MinX;
            public float MaxX;
            public float MinZ;
            public float MaxZ;
        }

        #region reserved code never be changed or removed
        public override object InitializeLifetimeService()
        {
            return null;
        }
        #endregion

        public string GetTeamName()
        {
            return "NEU666";
        }

        public Decision[] GetDecision(Mission mission, int teamId)
        {
            EnsureDecisionBuffer(mission);
            EnsureDiagnostics(mission, teamId);
            ResetDecisions();

            int attackerTeamId = ReadMissionInt(mission, "CurrentAttackerTeam", 0);
            #region debug-point C:decision-context
            if (ShouldEmitDebug(mission, -1))
            {
                ReportDebug("C", "StrategyQuickRescue.cs:GetDecision", "[DEBUG] decision context",
                    "{\"teamId\":" + teamId
                    + ",\"attackerTeamId\":" + attackerTeamId
                    + ",\"remainingCycles\":" + mission.CommonPara.RemainingCycles
                    + ",\"teamHalf\":" + (int)mission.TeamsRef[teamId].Para.MyHalfCourt
                    + ",\"fish0X\":" + ToInt(mission.TeamsRef[teamId].Fishes[0].PositionMm.X)
                    + ",\"fish0Z\":" + ToInt(mission.TeamsRef[teamId].Fishes[0].PositionMm.Z)
                    + "}");
            }
            #endregion
            if (teamId == attackerTeamId)
            {
                RunAttackStrategy(mission, teamId);
            }
            else
            {
                RunDefenseStrategy(mission, teamId, attackerTeamId);
            }

            WriteDiagFrame(mission, teamId);
            return decisions;
        }

        private void EnsureDecisionBuffer(Mission mission)
        {
            if (decisions == null || decisions.Length != mission.CommonPara.FishCntPerTeam)
            {
                decisions = new Decision[mission.CommonPara.FishCntPerTeam];
            }
        }

        private void ResetDecisions()
        {
            for (int i = 0; i < decisions.Length; i++)
            {
                decisions[i].VCode = StopVCode;
                decisions[i].TCode = StraightTCode;
            }
        }

        private void RunAttackStrategy(Mission mission, int teamId)
        {
            List<int> activeHostages = GetActiveHostages(mission, teamId);
            if (activeHostages.Count == 0)
            {
                for (int i = 0; i < decisions.Length; i++)
                {
                    xna.Vector3 standby = new xna.Vector3(1100f, 0, i == 0 ? 300f : -300f);
                    DriveFishAlongPath(mission, teamId, i, standby, AttackTrimVCode);
                }
                return;
            }

            int fishCount = Math.Min(decisions.Length, mission.TeamsRef[teamId].Fishes.Count);
            if (fishCount <= 0)
            {
                return;
            }

            for (int i = 0; i < HostageCount; i++)
            {
                carrierFishIndex[i] = -1;
            }

            int[] assignment = AssignHostagesToAttackers(mission, teamId, activeHostages, fishCount);
            for (int fishIndex = 0; fishIndex < fishCount; fishIndex++)
            {
                int hostageIndex = assignment[fishIndex];
                if (hostageIndex < 0 && UseEscort && activeHostages.Count == 1 && mission.TeamsRef.Count > 1
                    && mission.TeamsRef[1 - teamId].Fishes.Count > 0)
                {
                    // 只剩一个球：空闲鱼去顶开防守鱼，目标点取防守鱼靠球一侧，把它从球边挤走。
                    RoboFish defender = mission.TeamsRef[1 - teamId].Fishes[0];
                    xna.Vector3 bp = mission.EnvRef.Balls[activeHostages[0]].PositionMm;
                    xna.Vector3 target = defender.PositionMm + Normalize2D(bp - defender.PositionMm) * EscortLead;
                    DriveFishAlongPath(mission, teamId, fishIndex, ClampAndAvoidObstacles(mission, target), ReliableMaxVCode);
                    DebugPhase[fishIndex] = "ESCORT";
                    continue;
                }
                if (hostageIndex < 0)
                {
                    DriveFishToPoint(mission, teamId, fishIndex, new xna.Vector3(1100f, 0, fishIndex == 0 ? 300f : -300f), AttackTrimVCode);
                    continue;
                }

                carrierFishIndex[hostageIndex] = fishIndex;
                float lateralOffset = 0f;

                ControlAttacker(mission, teamId, fishIndex, hostageIndex, lateralOffset);
            }
        }

        private void RunDefenseStrategy(Mission mission, int teamId, int attackerTeamId)
        {
            if (mission.TeamsRef[teamId].Fishes.Count == 0)
            {
                return;
            }

            int targetHostageIndex = SelectDefenseTarget(mission, attackerTeamId);
            Ball hostage = mission.EnvRef.Balls[targetHostageIndex];
            xna.Vector3 goalPoint = BuildRescueGoal(hostage.PositionMm);
            xna.Vector3 blockDirection = Normalize2D(goalPoint - hostage.PositionMm);
            xna.Vector3 blockPoint = hostage.PositionMm + blockDirection * 260f;

            if (mission.TeamsRef[attackerTeamId].Fishes.Count > 0)
            {
                RoboFish attacker = mission.TeamsRef[attackerTeamId].Fishes[0];
                if (Distance2D(attacker.PositionMm, hostage.PositionMm) < 460f)
                {
                    blockPoint = (attacker.PositionMm + hostage.PositionMm) * 0.5f;
                }
            }

            defenseDriving = true;
            DriveFishAlongPath(mission, teamId, 0, ClampAndAvoidObstacles(mission, blockPoint), DefenseFastVCode);
            defenseDriving = false;
            for (int i = 1; i < decisions.Length; i++)
            {
                decisions[i].VCode = StopVCode;
                decisions[i].TCode = StraightTCode;
            }
        }

        // 推球接触相关几何：球半径 80、鱼头偏移 ~105，鱼心到球心约 185 时接触。
        private const float PushAimAhead = 220f;         // 推球时照准点在球前方多少 mm
        private const float LineupDistance = 300f;       // 整列点落在推球直线后方多远
        private const float SideGateOffset = 340f;       // 绕球时侧向让开距离
        private const float SideGateBack = 220f;         // 绕球侧后点相对球的后退量

        private void ControlAttacker(Mission mission, int teamId, int fishIndex, int hostageIndex, float lateralOffset)
        {
            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            Ball hostage = mission.EnvRef.Balls[hostageIndex];
            xna.Vector3 ballPos = hostage.PositionMm;
            xna.Vector3 fishPos = fish.PositionMm;

            if (carrierRouteSide[hostageIndex] == 0f)
            {
                carrierRouteSide[hostageIndex] = ballPos.Z >= 0f ? 1f : -1f;
            }

            // 选取当前应把球推向的航点，得到推球方向。
            List<xna.Vector3> route = BuildTransportRoute(carrierRouteSide[hostageIndex]);
            int routeIndex = SelectRouteTargetIndex(route, ballPos, carrierRouteIndex[hostageIndex],
                UseRouteVisibility ? GetObstacleBoxes(mission, 0f) : null);
            carrierRouteIndex[hostageIndex] = routeIndex;
            // 推球方向取路线上“球投影点前方 350mm”的追踪点：拐角处推向渐变，不会因航点切换突跳
            // (实测航点切换瞬间 dev 突增、PUSH 立即退出)，同时自带横向纠偏。
            xna.Vector3 routeTarget = UseVisibleCarrot
                ? GetVisibleCarrot(mission, route, routeIndex, ballPos)
                : GetRouteCarrot(route, routeIndex, ballPos, CarrotLookAhead);
            xna.Vector3 pushDir = Normalize2D(routeTarget - ballPos);
            if (UseFaceSlide) pushDir = SlideAlongPillarFace(mission, ballPos, pushDir);
            // 过右柱后是开阔直道，安全区 Z∈[-500,500]，不必把球拉回 Z=0：|Z|≤OPZ 时纯 +X 推。
            // (实测 vis3 球在 (903,384) 时推向指向 (1700,0)，鱼在缝内侧 dl≈-1.5 绕球 150 周期。)
            if (UseOpenStraight && ballPos.X > OpenStraightX)
            {
                float tz = Math.Max(-OpenStraightZ, Math.Min(OpenStraightZ, ballPos.Z));
                pushDir = Normalize2D(new xna.Vector3(2100f, 0, tz) - ballPos);
            }
            // 过右柱后安全区 Z∈[-500,500] 很宽：鱼→球方向只要落在“球→安全区两端”夹角内就直接按它推，
            // 不必绕到固定推线后方(实测 rvs21 X>900 段球每 10 周期仅进 17mm，鱼大半时间在 ORB 重新对位)。
            if (UseGoalCone && ballPos.X > GoalConeX)
            {
                float aLo = (float)Math.Atan2(-GoalConeZ - ballPos.Z, 1980f - ballPos.X);
                float aHi = (float)Math.Atan2(GoalConeZ - ballPos.Z, 1980f - ballPos.X);
                float aFb = (float)Math.Atan2(ballPos.Z - fishPos.Z, ballPos.X - fishPos.X);
                float a = Math.Max(aLo, Math.Min(aHi, aFb));
                pushDir = new xna.Vector3((float)Math.Cos(a), 0, (float)Math.Sin(a));
            }
            // 球落在侧柱西面、缝高之外（occ1 b0 c1760-c2160 停在 (390..442,410..574)）：
            // 前视点已在缝后，直推会把球钉在柱面。先把球朝缝口 (柱西面-80, ±FNZ) 送。
            if (UseGapFunnel)
            {
                float[] faceX = { -500f, 500f };
                for (int k = 0; k < faceX.Length; k++)
                {
                    if (ballPos.X > faceX[k] - FunnelDepth && ballPos.X < faceX[k] - 60f
                        && Math.Abs(ballPos.Z) > FunnelMinZ && Math.Abs(ballPos.Z) < 1400f)
                    {
                        float s = ballPos.Z >= 0f ? 1f : -1f;
                        float tx = Math.Min(ballPos.X + 100f, faceX[k] - 80f);
                        pushDir = Normalize2D(new xna.Vector3(tx, 0, s * FunnelZ) - ballPos);
                        break;
                    }
                }
            }

            if (UseDefAvoid && mission.TeamsRef.Count > 1)
                pushDir = AvoidBlocker(mission, teamId, hostageIndex, ballPos, pushDir);

            if (HandleFishStuck(mission, teamId, fishIndex, ballPos))
            {
                carrierStaged[hostageIndex] = false;
                return;
            }
            float dist = Distance2D(fishPos, ballPos);
            float ballMovement = carrierBallPositionInitialized[hostageIndex]
                ? Distance2D(carrierLastBallPosition[hostageIndex], ballPos)
                : 0f;
            bool recentBallMotion = ballMovement > 3f;
            bool obstacleZone = IsNearTransportObstacle(mission, ballPos);

            // 以球为原点、pushDir 为正方向建立局部坐标：
            // along<0 表示鱼在球后方（远离球门一侧，正确的可推侧）；along>0 表示鱼跑到球前方；
            // perp 为横向偏离“推球直线”的距离，绝对值越小越对准。
            xna.Vector3 perpDir = new xna.Vector3(-pushDir.Z, 0, pushDir.X);
            float relX = fishPos.X - ballPos.X;
            float relZ = fishPos.Z - ballPos.Z;
            float along = relX * pushDir.X + relZ * pushDir.Z;
            float perp = relX * perpDir.X + relZ * perpDir.Z;
            float absPerp = Math.Abs(perp);

            // ================= 运球控制（轴对齐路线：绕到正后方 + 沿推线穿心推）=================
            // 关键物理约束：鱼是非完整约束体，转向时同时前进、无法原地掉头；鱼撞球是一次冲量，
            // 球被弹出后滑行减速，不是持续刚性接触。因此要“连续贴球、低速稳推”，且推向必须与
            // pushDir 一致，否则球会被侧向弹开。配合轴对齐路线(BuildTransportRoute)，每次穿柱缝
            // 都是纯 +X 推进，球不会蹭到柱边被弹回。（接触距离≈185mm=鱼心到球心）

            // 历史最大问题是“导航抖动”：REV 最近段回退 / 每周期 Dijkstra 重规划会让目标航点来回
            // 跳，鱼原地打转、接近球耗掉一半以上预算(实测 ~1700 周期才贴近球)。现统一改用
            // NavigateStable：一次规划、缓存路径、单调推进航点，仅当目标移动超阈值或鱼偏离路径才
            // 重规划，彻底消除抖动。远程接近与近距离归位共用同一稳定导航。

            // ============ 显式 staging 状态机（carrierStaged 记忆）============
            // 历史顽疾“绕球极限环”：两态滞回里 PUSH/APP 每几十周期翻转，鱼在球周围乱绕、从各种
            // 角度乱撞把冲量互相抵消，球原地不动。根因：鱼是非完整约束体、有最小转弯半径，一旦
            // 带着横向偏差(perp)去推，转向就会绕过球心。破解思路——强制“先彻底到位，再推”：
            //   STAGE 态：稳定导航到“球正后方很远(420mm)的入口点”，只有当鱼真正到达该点附近
            //             (<160mm)且航向已大致对准 pushDir(|Δ|<0.6) 时才切到 PUSH，避免半途乱撞。
            //   PUSH  态：沿推线做低速纯追踪(低速=转弯半径小=能收敛不越轨)，瞄准“球前方”的
            //             前视点；一旦跑到球侧/前方或严重偏轴就退回 STAGE 重新绕后。
            // 鱼与球隔柱：DriveDribble 只看几何角度，会隔着柱子对球反复 HLP/ORB
            // (实测 aprb3 球停在中柱东面 (108,411)、鱼在西面 (-154,410)，c1740-c3000 球不动)。
            // 此时改为导航到球周围一个与球互相可见的入口点。
            bool occluded = UseOccludedStage && dist < 600f && !IsSegmentClear(fishPos, ballPos, GetObstacleBoxes(mission, 0f));
            // 鱼在球前方/对侧时近球 ORB 绕行很慢（occc3 f0 c400-c960 绕球 560 周期球不动）：
            // 离球还不太近时改走 STAGE，以较高速绕到球后 420mm 入口点再进 DRB。
            bool farStage = false;
            if (UseFarStage && dist < 600f && !occluded && ballPos.X < FarStageMaxX)
            {
                float dlNow = Math.Abs(NormalizeAngle((float)Math.Atan2(ballPos.Z - fishPos.Z, ballPos.X - fishPos.X)
                    - (float)Math.Atan2(pushDir.Z, pushDir.X)));
                if (dlNow > FarStageEnter && dist > FarStageMinDist) farStageLatch[fishIndex] = true;
                else if (dlNow < FarStageExit || dist < FarStageMinDist - 60f) farStageLatch[fishIndex] = false;
                farStage = farStageLatch[fishIndex];
            }
            else farStageLatch[fishIndex] = false;
            if (dist < 600f && !occluded && !farStage)
            {
                carrierStaged[hostageIndex] = false;
                DriveDribble(mission, teamId, fishIndex, hostageIndex, pushDir, routeIndex);
                return;
            }
            if (occluded)
            {
                carrierStaged[hostageIndex] = false;
                xna.Vector3 entryVis = FindVisibleEntry(mission, ballPos, pushDir);
                DebugPhase[fishIndex] = string.Format("OCC ri={0} d={1} tgt=({2:F0},{3:F0})",
                    routeIndex, (int)dist, entryVis.X, entryVis.Z);
                NavigateStable(mission, teamId, fishIndex, hostageIndex, entryVis, ballPos, 280f, 6);
                UpdateCarrierStallState(hostageIndex, ballPos, false);
                return;
            }

            float alignToPush = Math.Abs(NormalizeAngle(
                (float)Math.Atan2(pushDir.Z, pushDir.X) - fish.BodyDirectionRad));

            if (carrierStaged[hostageIndex])
            {
                // 丢失推球位姿：跑到球前/侧、或严重偏轴、或离球太远 → 退回 STAGE
                float devNow = Math.Abs(NormalizeAngle((float)Math.Atan2(-perp, -along)));
                if (along > -20f || dist > 600f || devNow > 1.2f)
                    carrierStaged[hostageIndex] = false;
            }
            else
            {
                // 到位判据：鱼落在球正后方的“漏斗锥”内(越靠后允许的横向偏差越大)且航向大致对准
                // → 进入 PUSH。不要求精确停在某个点上(鱼停不下来，精确点目标会让它绕点打圈)。
                float devEnter = Math.Abs(NormalizeAngle((float)Math.Atan2(-perp, -along)));
                if (along < -60f && dist < 450f && devEnter < 0.9f && alignToPush < 0.9f)
                    carrierStaged[hostageIndex] = true;
            }

            if (carrierStaged[hostageIndex])
            {
                // 沿推线低速纯追踪穿心推。前视点取“鱼在推线上的投影再往前 260mm”，但不超过球前
                // 150mm——前视足够长以平滑收敛(避免直角切轨越轨)，低速保证转弯半径小、不绕球。
                // 球的运动方向≈接触法线(鱼→球)。dev = 鱼→球方向与推球方向的夹角；
                // 期望航向 = 鱼→球方向再向偏离侧多转 dev：鱼会绕到球的偏离侧后方，使接触法线回到推线。
                float pushAngle = (float)Math.Atan2(pushDir.Z, pushDir.X);
                float thetaB = (float)Math.Atan2(ballPos.Z - fishPos.Z, ballPos.X - fishPos.X);
                float dev = NormalizeAngle(thetaB - pushAngle);
                // 增益取 0.4：鱼转向滞后大，增益过高会在推线两侧来回振荡(实测 ae 在 ±1.5 间摆动)。
                float contactAngle = thetaB + Clamp(dev * 0.4f, -0.5f, 0.5f);
                // 未接触时先沿推线收敛(前视距离随离球距离增大)，否则鱼会以大交角直冲球心、
                // 接触时航向差 >1 rad，随后从球侧滑过(实测 c1040: dev=0.03 但 ae=1.16)。
                float lookAhead = 150f + 0.5f * Math.Max(0f, -along - 150f);
                float lineAngle = pushAngle - (float)Math.Atan2(perp, lookAhead);
                float w = Clamp((dist - 150f) / 150f, 0f, 1f);
                float desiredAngle = contactAngle + w * NormalizeAngle(lineAngle - contactAngle);
                float angleError = NormalizeAngle(desiredAngle - fish.BodyDirectionRad);
                decisions[fishIndex].TCode = DirectionToTCode(angleError);
                float absDev = Math.Abs(dev);
                float absAe = Math.Abs(angleError);
                int ps;
                if (absAe > 1.0f) ps = 1;
                else if (absAe > 0.5f) ps = 3;
                else if (absDev > 0.4f) ps = 4;
                else ps = 6;
                decisions[fishIndex].VCode = ps;
                // 每段 PUSH 结束后鱼所在的侧不同，绕行方向须重新按短弧选择(实测沿用旧方向会绕远 ~300 周期)。
                orbitDirMemory[fishIndex] = 0;
                DebugPhase[fishIndex] = string.Format("PUSH ri={0} along={1} perp={2} d={3} V={4} dev={5:F2} ae={6:F2}",
                    routeIndex, (int)along, (int)perp, (int)dist, ps, dev, angleError);
                UpdateCarrierStallState(hostageIndex, ballPos, true);
            }
            else
            {
                // STAGE：稳定导航到球正后方 420mm 的入口点(把球当圆障碍绕行)。远时全速，近时
                // 降速缩小转弯半径以拐上推线。入口点离球足够远 → 有长直道让航向/perp 收敛。
                Field fieldInfo = mission.EnvRef.FieldInfo;
                xna.Vector3 entry = new xna.Vector3(
                    Clamp(ballPos.X - pushDir.X * 420f, fieldInfo.LeftMm + 170f, fieldInfo.RightMm - 170f), 0,
                    Clamp(ballPos.Z - pushDir.Z * 420f, fieldInfo.TopMm + 170f, fieldInfo.BottomMm - 170f));
                float dEntry = Distance2D(fishPos, entry);
                int speed;
                if (dEntry > 900f) speed = obstacleZone ? 9 : AttackFastVCode;
                else if (dEntry > 500f) speed = obstacleZone ? 7 : 9;
                else if (dEntry > 260f) speed = 6;
                else speed = 4;
                if (dist < 600f && !farStage)
                {
                    // 近球丢失推球位姿：就地绕球回到正后方，避免全局规划把球当障碍绕远路。
                    DebugPhase[fishIndex] = string.Format("ORBIT ri={0} along={1} perp={2} d={3}",
                        routeIndex, (int)along, (int)perp, (int)dist);
                    DriveFishOrbit(mission, teamId, fishIndex, ballPos,
                        (float)Math.Atan2(pushDir.Z, pushDir.X), 6);
                    UpdateCarrierStallState(hostageIndex, ballPos, false);
                    return;
                }
                orbitDirMemory[fishIndex] = 0;
                DebugPhase[fishIndex] = string.Format("{4} ri={0} along={1} perp={2} d={3}",
                    routeIndex, (int)along, (int)perp, (int)dist, farStage ? "FSTG" : "STAGE");

                // 远程接近：鱼与入口点隔柱时沿本球运输路线反向走（中柱绕球所在侧）。
                // 实测 rvs21 f0 的 Dijkstra 路径在中柱南北两侧近似等长，重规划时翻到对侧，接球耗时约 480 周期。
                // 做法：在中柱与“球对侧”场边之间加一道虚拟墙，让 Dijkstra 只能走球所在侧。
                approachWallSide = (UseApproachRoute && dist > 900f) ? carrierRouteSide[hostageIndex] : 0f;
                NavigateStable(mission, teamId, fishIndex, hostageIndex, entry, ballPos, 280f, speed);
                approachWallSide = 0f;
                UpdateCarrierStallState(hostageIndex, ballPos, false);
            }
        }

        // 近球运球（参考 Strategy666 BaseAction.dribble4，比赛验证过的做法）：不分“绕球/推球”状态，
        // 始终让鱼头奔向“球后方贴球点” P = 球 - r·goalDir。
        //   - 鱼→球方向与 goalDir 夹角 δ 超过 ±90° 时把 goalDir 限到 鱼→球 ±90°：P 落在球侧面，鱼自然从侧面绕过；
        //   - r 随 |δ| 增大(30~100 基准，按球半径 80/58 放大)，偏得越多越从远处兜回；
        //   - 近处航向偏差大且航向线打不中球时用 V1 近乎原地转，否则中高速顶球。
        // 位置按 0.1s 预测，抵消控制滞后。
        private bool defenseDriving;
        private readonly bool[] dribbleNearP = new bool[4];
        private readonly bool[] dribbleOrbit = new bool[4];

        private void DriveDribble(Mission mission, int teamId, int fishIndex, int hostageIndex,
            xna.Vector3 pushDir, int routeIndex)
        {
            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            Ball ball = mission.EnvRef.Balls[hostageIndex];
            const float Scale = 80f / 58f;
            const float HalfPi = (float)(Math.PI / 2.0);

            float heading = fish.BodyDirectionRad + fish.AngularVelocityRadPs * 0.1f;
            float fx = fish.PositionMm.X + fish.VelocityMmPs * (float)Math.Cos(fish.VelocityDirectionRad) * 0.1f;
            float fz = fish.PositionMm.Z + fish.VelocityMmPs * (float)Math.Sin(fish.VelocityDirectionRad) * 0.1f;
            float bx = ball.PositionMm.X + ball.VelocityMmPs * (float)Math.Cos(ball.VelocityDirectionRad) * 0.1f;
            float bz = ball.PositionMm.Z + ball.VelocityMmPs * (float)Math.Sin(ball.VelocityDirectionRad) * 0.1f;
            float headOffset = Distance2D(fish.PolygonVertices[0], fish.PositionMm);
            float hx = fx + headOffset * (float)Math.Cos(heading);
            float hz = fz + headOffset * (float)Math.Sin(heading);

            float goalAngle = (float)Math.Atan2(pushDir.Z, pushDir.X);
            float fishToBall = (float)Math.Atan2(bz - fz, bx - fx);
            float delta = NormalizeAngle(goalAngle - fishToBall);
            // 鱼在球侧前方：δ 在 ±π 附近翻转，钳位选边随之来回跳，鱼在 TURN 里抖动并把球往回拱
            // (实测 dl 恒为 ±1.57、ball0.X 从 -1405 退到 -1556)。改为带方向记忆的绕球。
            // 滞回：>2.0 进入绕球，<1.3 退出(实测单阈值 1.5 时 dl 在 1.51~1.62 间长期抖动)。
            if (Math.Abs(delta) > OrbitEnter) dribbleOrbit[fishIndex] = true;
            else if (Math.Abs(delta) < OrbitExit) dribbleOrbit[fishIndex] = false;
            if (dribbleOrbit[fishIndex])
            {
                DriveFishOrbit(mission, teamId, fishIndex, ball.PositionMm, goalAngle, 5);
                dribbleNearP[fishIndex] = false;
                DebugPhase[fishIndex] = string.Format("DRB-ORB ri={0} dl={1:F2} V={2}",
                    routeIndex, delta, decisions[fishIndex].VCode);
                UpdateCarrierStallState(hostageIndex, ball.PositionMm, false);
                return;
            }
            orbitDirMemory[fishIndex] = 0;
            if (delta > HalfPi) { goalAngle = fishToBall + HalfPi; delta = HalfPi; }
            else if (delta < -HalfPi) { goalAngle = fishToBall - HalfPi; delta = -HalfPi; }

            // HLP 后撤点仅在球心后 40mm，鱼从远处带侧偏直冲球会把球沿侧向推走（occd2 f0 c560-c750
            // dl≈-0.7..1.3 V6，球先被推向南墙再推向西北，X 几乎不动）。离球尚远且有侧偏时改走
            // 位姿镇定矢量场 φ = goal - 2δ：沿与推线相切于球心的圆弧切入，接触时航向已对准推向。
            if (UseArcApproach && Distance2D(fish.PositionMm, ball.PositionMm) > ArcMinDist
                && Math.Abs(delta) > ArcMinDelta)
            {
                float arcErr = NormalizeAngle(goalAngle - 2f * delta - fish.BodyDirectionRad);
                decisions[fishIndex].TCode = DirectionToTCode(arcErr);
                float absArc = Math.Abs(arcErr);
                decisions[fishIndex].VCode = absArc > 0.8f ? ArcTurnVCode : (absArc > 0.4f ? 4 : ReliableMaxVCode);
                DebugPhase[fishIndex] = string.Format("DRB-ARC ri={0} dl={1:F2} V={2} T={3}",
                    routeIndex, delta, decisions[fishIndex].VCode, decisions[fishIndex].TCode);
                UpdateCarrierStallState(hostageIndex, ball.PositionMm, false);
                return;
            }

            if (UseHelperDribble)
            {
                // 侧位(|δ|大)时后撤点拉远，让鱼先绕到球后再推，避免横推(实测 δ=-1.57 时球被横推 ~700mm 卡到柱后)。
                float backR = HelperBackR + HelperBackK * delta * delta;
                xna.Vector3 back = new xna.Vector3(bx - backR * (float)Math.Cos(goalAngle), 0,
                    bz - backR * (float)Math.Sin(goalAngle));
                // 远离柱子的开阔区（起点区、右柱之后的直道）放开速度上限，缩短直线推球耗时。
                bool openZone = bx < OpenZoneLeftX || bx > OpenZoneRightX;
                int hv1 = openZone ? OpenZoneVCode : HelperV1;
                int hv2 = openZone ? OpenZoneVCode : HelperV2;
                int hcap = openZone ? OpenZoneVCode : HelperVCap;
                URWPGSim2D.StrategyHelper.Helpers.Dribble(ref decisions[fishIndex], fish, back, goalAngle,
                    HelperTheta1, HelperTheta2, 150f, hv1, hv2, HelperCycles, 100, false);
                if (decisions[fishIndex].VCode > hcap) decisions[fishIndex].VCode = hcap;
                // 近球时航向与推向偏差大仍 V6 冲球会带着惯性滑过球（nodefa2 f0 c660-c740 V6 横冲后 V1 漂过球 150mm）。
                if (HeadingBrakeAngle < 9f && Distance2D(fish.PositionMm, ball.PositionMm) < HeadingBrakeDist
                    && Math.Abs(NormalizeAngle(fish.BodyDirectionRad - goalAngle)) > HeadingBrakeAngle
                    && decisions[fishIndex].VCode > HeadingBrakeVCode)
                    decisions[fishIndex].VCode = HeadingBrakeVCode;
                // 贴球侧转向时 V1 的转弯圆大于鱼-球间距，鱼绕着球转却对不准（occc1 f0 c1870-c1940 V1 T14 70 周期球不动）。
                if (UseTurnInPlace && decisions[fishIndex].VCode == 1
                    && Distance2D(fish.PositionMm, ball.PositionMm) < TurnInPlaceDist)
                    decisions[fishIndex].VCode = TurnInPlaceVCode;
                // 侧位高速顶球会把球沿鱼航向直线送走（occ1 f0 c830-c860 dl 0.82→1.39 仍 V=6，
                // 球出左缝后沿 Z≈175 平推 430mm 顶到中柱前）。偏角大时降速，让鱼先转回球后。
                if (Math.Abs(delta) > DeltaSlowAngle && decisions[fishIndex].VCode > DeltaSlowVCode)
                    decisions[fishIndex].VCode = DeltaSlowVCode;
                DebugPhase[fishIndex] = string.Format("DRB-HLP ri={0} dl={1:F2} V={2} T={3}",
                    routeIndex, delta, decisions[fishIndex].VCode, decisions[fishIndex].TCode);
                UpdateCarrierStallState(hostageIndex, ball.PositionMm, true);
                return;
            }

            float k = Math.Abs(delta) / 1.5f + 0.2f;
            float r = (30f + k * k * 35f) * Scale;
            float px = bx - r * (float)Math.Cos(goalAngle);
            float pz = bz - r * (float)Math.Sin(goalAngle);

            float headDist = (float)Math.Sqrt((px - hx) * (px - hx) + (pz - hz) * (pz - hz));
            // 鱼头已贴近 P 时“鱼头→P”方向退化成噪声(实测 hd=9~70 时 he 在 -0.3~-2.7 间乱跳)，
            // 改为直接对准推向。
            // 带滞回的锁存，避免在阈值附近两种误差符号相反来回切换而原地僵住(实测 hd≈82 时 he 在 ±1.1 间翻转 500 周期)。
            if (headDist < 50f * Scale) dribbleNearP[fishIndex] = true;
            else if (headDist > 110f * Scale) dribbleNearP[fishIndex] = false;
            // 贴球时只对准推向会让鱼沿直线滑过球侧(实测 PUSH he≈0 时 dl 0.12→0.87 后丢球)。
            // 改为顶着球心、再向推线反侧多偏 0.8δ(限 ±0.6)，使鱼→球连线逐步转回推向。
            float nearAim = fishToBall - Math.Max(-0.6f, Math.Min(0.6f, 0.8f * delta));
            float headErr = dribbleNearP[fishIndex]
                ? NormalizeAngle(nearAim - heading)
                : NormalizeAngle((float)Math.Atan2(pz - hz, px - hx) - heading);

            // 航向线是否打得中球：球心到航向线的横向距离；航向与 goalDir 是否大致一致(±35°)。
            float cosH = (float)Math.Cos(heading), sinH = (float)Math.Sin(heading);
            float lateralMiss = Math.Abs((bx - fx) * -sinH + (bz - fz) * cosH);
            bool headingAligned = Math.Abs(NormalizeAngle(heading - goalAngle)) < 0.6f;
            float absHeadErr = Math.Abs(headErr);

            // d23: 推向与鱼→球方向之差；d24: 鱼→球方向与航向之差(同号表示正在往正确侧兜)。
            float d23 = NormalizeAngle(goalAngle - fishToBall);
            float d24 = NormalizeAngle(fishToBall - heading);

            string mode;
            int v;
            // V1 满舵仅 ~0.035 rad/cyc，0.26 的阈值会让鱼长时间停在 TURN；只在大误差时原地转。
            if ((headDist < 150f * Scale && absHeadErr > 0.6f && (lateralMiss > 54f * Scale || !headingAligned))
                || absHeadErr > HalfPi)
            {
                mode = "TURN"; v = 1;
            }
            else if (headDist < 150f * Scale && absHeadErr > 0.26f)
            {
                mode = "ADJ"; v = 3;
            }
            else if (headDist < 300f * Scale && Math.Abs(d23) > 0.35f && Math.Abs(d23) < 1.92f
                && d23 * d24 > 0f && Math.Abs(d24) < 0.52f)
            {
                mode = "CURVE"; v = Math.Abs(d23) < HalfPi ? 4 : 5;
            }
            else if (headDist < 150f)
            {
                mode = "PUSH"; v = 6;
            }
            else
            {
                mode = "APPR"; v = -1;
            }

            if (v < 0)
            {
                DriveFishToPoint(mission, teamId, fishIndex, new xna.Vector3(px, 0, pz), 6);
                v = decisions[fishIndex].VCode;
            }
            else
            {
                decisions[fishIndex].TCode = DirectionToTCode(headErr);
                decisions[fishIndex].VCode = v;
            }

            DebugPhase[fishIndex] = string.Format("DRB-{0} ri={1} hd={2} he={3:F2} dl={4:F2} V={5}",
                mode, routeIndex, (int)headDist, headErr, delta, v);
            UpdateCarrierStallState(hostageIndex, ball.PositionMm, mode == "PUSH");
        }

        // 让鱼沿以球为圆心、半径 R(略大于接触距离)的圆弧朝“球正后方(pushAngle+PI)”摆位，
        // 始终贴在球边而不跑远。关键：绕行方向强制走“中心侧”(远离最近场墙)——上半场的球绕
        // 下方、下半场的球绕上方，避免鱼被挤进“球与场墙之间”的窄缝里卡死。
        private void DriveFishOrbit(Mission mission, int teamId, int fishIndex,
            xna.Vector3 ballPos, float pushAngle, int maxVCode)
        {
            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            float behindAngle = pushAngle + (float)Math.PI;
            float relX = fish.PositionMm.X - ballPos.X;
            float relZ = fish.PositionMm.Z - ballPos.Z;
            float thetaFish = (float)Math.Atan2(relZ, relX);

            const float TwoPi = (float)(Math.PI * 2.0);
            // 鱼在球前方时加大绕行半径，避免绕行途中撞球把球打回。
            float alongP = relX * (float)Math.Cos(pushAngle) + relZ * (float)Math.Sin(pushAngle);
            float R = alongP > -50f ? 380f : 280f;

            // CCW(角度增大)从 thetaFish 扫到 behindAngle 需要多少弧度(0..2π)，CW 为其补角。
            float ccwSweep = behindAngle - thetaFish;
            while (ccwSweep < 0f) ccwSweep += TwoPi;
            while (ccwSweep >= TwoPi) ccwSweep -= TwoPi;
            float cwSweep = TwoPi - ccwSweep;

            // 选方向：弧线上有采样点出界/进柱则视为被挡；两边都通或都挡时走短弧。
            // 记忆上次方向，避免在两弧长度接近时来回翻转。
            List<ObstacleBox> boxes = GetObstacleBoxes(mission, 40f);
            bool ccwBlocked = IsOrbitArcBlocked(mission, ballPos, thetaFish, ccwSweep, 1, R, boxes);
            bool cwBlocked = IsOrbitArcBlocked(mission, ballPos, thetaFish, cwSweep, -1, R, boxes);
            int dir = orbitDirMemory[fishIndex];
            if (dir == 0 || (dir > 0 ? ccwBlocked && !cwBlocked : cwBlocked && !ccwBlocked))
            {
                if (ccwBlocked != cwBlocked) dir = ccwBlocked ? -1 : 1;
                else dir = ccwSweep <= cwSweep ? 1 : -1;
            }
            orbitDirMemory[fishIndex] = dir;
            float remaining = dir > 0 ? ccwSweep : cwSweep;
            if (remaining > TwoPi - 0.3f) remaining = 0f; // 已越过正后方一点点：视为到位

            // 后半平面：位姿镇定矢量场 φ = pushAngle + 2α（α = 鱼→球方向与推向的夹角）。
            // 该场的流线都以切线方向 pushAngle 汇入球心，鱼到达球后方时航向已对准推线
            // (实测旧的“收敛到推线”场让鱼以 ~90° 横穿球后方，c1510 along=-151 perp=-110 却无法进 PUSH，
            // 随后又绕满一圈 ~270 周期)。
            float psi = (float)Math.Atan2(-relZ, -relX);
            float alpha = NormalizeAngle(psi - pushAngle);
            if (Math.Abs(alpha) < 1.5f)
            {
                float desired = NormalizeAngle(pushAngle + 2f * alpha);
                float err = NormalizeAngle(desired - fish.BodyDirectionRad);
                decisions[fishIndex].TCode = DirectionToTCode(err);
                // 大误差用 V1 近乎原地转(实测 V2 仍以 ~8mm/cyc 滑行，转弯半径 ~450mm，绕一大圈 ~250 周期)。
                decisions[fishIndex].VCode = Math.Abs(err) > 0.8f ? 1 : (Math.Abs(err) > 0.4f ? 3 : 6);
                return;
            }

            float step = Math.Min(remaining, 0.7f) * dir;
            float aim = thetaFish + step;
            xna.Vector3 orbitTarget = new xna.Vector3(
                ballPos.X + R * (float)Math.Cos(aim), 0, ballPos.Z + R * (float)Math.Sin(aim));
            orbitTarget = ClampAndAvoidObstacles(mission, orbitTarget);
            DriveFishToPoint(mission, teamId, fishIndex, orbitTarget, maxVCode);
        }

        // 卡死脱困：鱼头顶住立柱/场墙时低速转向无效(实测在 (-705,568) 顶住左柱 650 周期不动)。
        // 40 周期内位移 <25mm 视为卡死，朝“远离最近障碍/场墙”的方向中速满舵脱离 40 周期。
        private readonly xna.Vector3[] stuckRefPos = new xna.Vector3[4];
        private readonly int[] stuckCycles = new int[4];
        private readonly float[] stuckRefHeading = new float[4];
        private readonly int[] escapeCycles = new int[4];
        private readonly float[] escapeHeading = new float[4];

        private bool HandleFishStuck(Mission mission, int teamId, int fishIndex, xna.Vector3 ballPos)
        {
            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            xna.Vector3 pos = fish.PositionMm;
            if (escapeCycles[fishIndex] > 0)
            {
                escapeCycles[fishIndex]--;
                float err = NormalizeAngle(escapeHeading[fishIndex] - fish.BodyDirectionRad);
                decisions[fishIndex].TCode = DirectionToTCode(err);
                decisions[fishIndex].VCode = 5;
                DebugPhase[fishIndex] = string.Format("ESC hd={0:F2} err={1:F2}", escapeHeading[fishIndex], err);
                stuckRefPos[fishIndex] = pos;
                stuckCycles[fishIndex] = 0;
                return true;
            }

            // 原地转向(DRB-TURN 用 V1)位移很小但航向在变，不算卡死。
            if (Distance2D(pos, stuckRefPos[fishIndex]) > 25f
                || Math.Abs(NormalizeAngle(fish.BodyDirectionRad - stuckRefHeading[fishIndex])) > 0.3f)
            {
                stuckRefPos[fishIndex] = pos;
                stuckRefHeading[fishIndex] = fish.BodyDirectionRad;
                stuckCycles[fishIndex] = 0;
                return false;
            }
            if (++stuckCycles[fishIndex] < 40) return false;

            // 找鱼头附近最近的障碍点(立柱或场墙)，脱困方向 = 该点指向鱼心。
            xna.Vector3 nose = new xna.Vector3(
                pos.X + 150f * (float)Math.Cos(fish.BodyDirectionRad), 0,
                pos.Z + 150f * (float)Math.Sin(fish.BodyDirectionRad));
            Field field = mission.EnvRef.FieldInfo;
            float best = float.MaxValue;
            xna.Vector3 nearest = ballPos;
            foreach (ObstacleBox b in GetObstacleBoxes(mission, 0f))
            {
                xna.Vector3 q = new xna.Vector3(Clamp(nose.X, b.MinX, b.MaxX), 0, Clamp(nose.Z, b.MinZ, b.MaxZ));
                float d = Distance2D(q, nose);
                if (d < best) { best = d; nearest = q; }
            }
            xna.Vector3[] walls =
            {
                new xna.Vector3(field.LeftMm, 0, nose.Z), new xna.Vector3(field.RightMm, 0, nose.Z),
                new xna.Vector3(nose.X, 0, field.TopMm), new xna.Vector3(nose.X, 0, field.BottomMm)
            };
            foreach (xna.Vector3 q in walls)
            {
                float d = Distance2D(q, nose);
                if (d < best) { best = d; nearest = q; }
            }
            // 附近没有障碍/场墙：不是顶墙卡死(多半是在球边转向)，不脱困，免得把鱼带离球。
            if (best > 250f) { stuckCycles[fishIndex] = 0; return false; }
            escapeHeading[fishIndex] = (float)Math.Atan2(pos.Z - nearest.Z, pos.X - nearest.X);
            escapeCycles[fishIndex] = 40;
            stuckCycles[fishIndex] = 0;
            return false;
        }

        private bool IsOrbitArcBlocked(Mission mission, xna.Vector3 center, float startAngle, float sweep,
            int dir, float radius, List<ObstacleBox> boxes)
        {
            Field field = mission.EnvRef.FieldInfo;
            for (float s = 0.2f; s < sweep; s += 0.2f)
            {
                float a = startAngle + s * dir;
                xna.Vector3 p = new xna.Vector3(
                    center.X + radius * (float)Math.Cos(a), 0, center.Z + radius * (float)Math.Sin(a));
                if (p.X < field.LeftMm + 110f || p.X > field.RightMm - 110f
                    || p.Z < field.TopMm + 110f || p.Z > field.BottomMm - 110f)
                    return true;
                if (!IsPointClear(p, boxes)) return true;
            }
            return false;
        }

        private int[] AssignHostagesToAttackers(Mission mission, int teamId, List<int> activeHostages, int fishCount)
        {
            int[] result = new int[fishCount];
            if (activeHostages.Count == 1)
            {
                // 剩下的球仍交给原来负责它的鱼（鱼 i ↔ 球 i）。原先固定交给 0 号鱼，
                // ball0 先获救时正在推 ball1 的 1 号鱼会被换下，0 号鱼要从安全区游回约 2000mm 接手。
                int owner = activeHostages[0] < fishCount ? activeHostages[0] : 0;
                for (int i = 0; i < fishCount; i++)
                {
                    result[i] = i == owner ? activeHostages[0] : -1;
                }
                return result;
            }

            for (int fishIndex = 0; fishIndex < fishCount; fishIndex++)
            {
                int preferredHostage = Math.Min(fishIndex, HostageCount - 1);
                result[fishIndex] = activeHostages.Contains(preferredHostage)
                    ? preferredHostage
                    : activeHostages[0];
            }
            return result;
        }

        private List<int> GetActiveHostages(Mission mission, int attackerTeamId)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < mission.EnvRef.Balls.Count && i < HostageCount; i++)
            {
                string key = string.Format("Team{0}Hostage{1}Rescued", attackerTeamId, i);
                if (ReadMissionInt(mission, key, 0) == 0)
                {
                    result.Add(i);
                }
            }

            result.Sort(delegate(int left, int right)
            {
                return DistanceToGoal(mission.EnvRef.Balls[left].PositionMm)
                    .CompareTo(DistanceToGoal(mission.EnvRef.Balls[right].PositionMm));
            });
            return result;
        }

        private int SelectDefenseTarget(Mission mission, int attackerTeamId)
        {
            List<int> activeHostages = GetActiveHostages(mission, attackerTeamId);
            if (activeHostages.Count == 0)
            {
                return 0;
            }

            int bestIndex = activeHostages[0];
            float bestScore = float.MaxValue;
            for (int i = 0; i < activeHostages.Count; i++)
            {
                int hostageIndex = activeHostages[i];
                Ball hostage = mission.EnvRef.Balls[hostageIndex];
                float score = DistanceToGoal(hostage.PositionMm);
                for (int fishIndex = 0; fishIndex < mission.TeamsRef[attackerTeamId].Fishes.Count && fishIndex < 2; fishIndex++)
                {
                    score -= Distance2D(hostage.PositionMm, mission.TeamsRef[attackerTeamId].Fishes[fishIndex].PositionMm) * 0.2f;
                }

                if (score < bestScore)
                {
                    bestScore = score;
                    bestIndex = hostageIndex;
                }
            }

            return bestIndex;
        }

        private int GetRouteWaypointIndex(List<xna.Vector3> route, xna.Vector3 hostagePosition)
        {
            return AdvanceRouteIndex(route, 0, hostagePosition);
        }

        // 依据球在路线上的实际投影选择推球目标航点。
        // 关键修复：运球不精确，球会大幅偏离规划路线(实测可偏离近 1000mm)。旧逻辑要求球必须
        // “贴着当前路段线(cross<140)”才允许指针前进，一旦球被推偏，指针就卡在早期航点，pushDir
        // 反指后方→鱼把球往回推、永远卡死。现改为：在 previousIndex 及其之后的路段里，找“离球
        // 最近的那条路段”，把它的远端航点作为目标(球已贴近该航点则再进一格)。指针单调不回退，
        // 因此即使球被弹偏，也总是朝“它当前所在路段的下一个航点”推进，能自然把球带回路线并前进。
        private int SelectRouteTargetIndex(List<xna.Vector3> route, xna.Vector3 ballPosition, int previousIndex,
            List<ObstacleBox> boxes)
        {
            if (route.Count < 2)
            {
                return route.Count - 1;
            }

            int startIndex = ClampInt(previousIndex, 1, route.Count - 1);
            // 球出缝时被弹回柱西面（rvs27 b0 c1420-c1700），当前段起点已隔柱不可见：回退到可见的路段。
            while (boxes != null && startIndex > 1 && !IsSegmentClear(ballPosition, route[startIndex - 1], boxes))
            {
                startIndex--;
            }

            // 在 startIndex..end 的路段中找到离球最近的一条(以其远端航点索引表示)。
            int nearest = startIndex;
            float nearestDist = float.MaxValue;
            for (int i = startIndex; i <= route.Count - 1; i++)
            {
                // 球被顶到左柱西面上段时，隔柱的下一段反而“更近”，索引单调前进后推向直指柱面、
                // 球被钉在 X≈-658 数百周期（w030 b0 c1120-c1900）。起点隔柱不可见的后续路段不参与选择。
                if (boxes != null && i > startIndex && !IsSegmentClear(ballPosition, route[i - 1], boxes)) continue;
                float d = DistancePointToSegment(ballPosition, route[i - 1], route[i]);
                if (d < nearestDist)
                {
                    nearestDist = d;
                    nearest = i;
                }
            }

            // 若球已很接近该航点，则前进到下一个航点(避免停在已到达的航点上原地打转)。
            int target = nearest;
            while (target < route.Count - 1 && Distance2D(ballPosition, route[target]) < 130f)
            {
                target++;
            }

            return ClampInt(Math.Max(target, startIndex), 1, route.Count - 1);
        }

        private xna.Vector3 GetRouteCarrot(List<xna.Vector3> route, int segIndex, xna.Vector3 ball, float lookAhead)
        {
            xna.Vector3 a = route[segIndex - 1], b = route[segIndex];
            float dx = b.X - a.X, dz = b.Z - a.Z;
            float len = (float)Math.Sqrt(dx * dx + dz * dz);
            float t = len < 1e-3f ? len : Clamp(((ball.X - a.X) * dx + (ball.Z - a.Z) * dz) / len, 0f, len);
            float remain = lookAhead;
            int i = segIndex;
            while (true)
            {
                a = route[i - 1]; b = route[i];
                dx = b.X - a.X; dz = b.Z - a.Z;
                len = (float)Math.Sqrt(dx * dx + dz * dz);
                if (t + remain <= len || i == route.Count - 1)
                {
                    float s = len < 1e-3f ? 0f : Math.Min(t + remain, len) / len;
                    return new xna.Vector3(a.X + dx * s, 0, a.Z + dz * s);
                }
                remain -= len - t;
                t = 0f;
                i++;
            }
        }

        // 前视点跨过柱端拐角时会“抄近路”：实测球在 (-124,-601) 时 350mm 前视点落到 (125,-592)，
        // 推向变成纯 +X、直接顶进中柱左面，球长期卡在 X=-108。这里逐步缩短前视，直到
        // “球→前视点”连线不比球当前位置更贴近任何柱子（或不低于 CarrotClear）。
        private xna.Vector3 GetVisibleCarrot(Mission mission, List<xna.Vector3> route, int segIndex, xna.Vector3 ball)
        {
            List<ObstacleBox> boxes = GetObstacleBoxes(mission, 0f);
            float startClear = DistanceToBoxes(ball, boxes);
            float required = Math.Min(CarrotClear, startClear) - 2f;
            for (float look = CarrotLookAhead; look > CarrotMinLook; look -= 40f)
            {
                xna.Vector3 carrot = GetRouteCarrot(route, segIndex, ball, look);
                if (MinClearanceAlong(ball, carrot, boxes) >= required)
                {
                    return carrot;
                }
            }
            return GetRouteCarrot(route, segIndex, ball, CarrotMinLook);
        }

        private float MinClearanceAlong(xna.Vector3 from, xna.Vector3 to, List<ObstacleBox> boxes)
        {
            float len = Distance2D(from, to);
            int steps = Math.Max(1, (int)(len / 20f));
            float best = float.MaxValue;
            for (int k = 1; k <= steps; k++)
            {
                float s = (float)k / steps;
                xna.Vector3 p = new xna.Vector3(from.X + (to.X - from.X) * s, 0, from.Z + (to.Z - from.Z) * s);
                best = Math.Min(best, DistanceToBoxes(p, boxes));
            }
            return best;
        }

        private static float DistanceToBoxes(xna.Vector3 p, List<ObstacleBox> boxes)
        {
            float best = float.MaxValue;
            for (int i = 0; i < boxes.Count; i++)
            {
                ObstacleBox b = boxes[i];
                float dx = Math.Max(Math.Max(b.MinX - p.X, 0f), p.X - b.MaxX);
                float dz = Math.Max(Math.Max(b.MinZ - p.Z, 0f), p.Z - b.MaxZ);
                best = Math.Min(best, (float)Math.Sqrt(dx * dx + dz * dz));
            }
            return best;
        }

        private float DistancePointToSegment(xna.Vector3 point, xna.Vector3 segStart, xna.Vector3 segEnd)
        {
            float dx = segEnd.X - segStart.X;
            float dz = segEnd.Z - segStart.Z;
            float lengthSquared = dx * dx + dz * dz;
            if (lengthSquared < 1e-3f)
            {
                return Distance2D(point, segStart);
            }

            float t = ((point.X - segStart.X) * dx + (point.Z - segStart.Z) * dz) / lengthSquared;
            t = Clamp(t, 0f, 1f);
            xna.Vector3 projection = new xna.Vector3(segStart.X + t * dx, 0, segStart.Z + t * dz);
            return Distance2D(point, projection);
        }

        private int AdvanceRouteIndex(List<xna.Vector3> route, int currentIndex, xna.Vector3 hostagePosition)
        {
            if (currentIndex >= route.Count - 1) return currentIndex;

            xna.Vector3 target = route[currentIndex];
            xna.Vector3 prev = currentIndex > 0 ? route[currentIndex - 1] : route[0];

            float dx = target.X - prev.X;
            float dz = target.Z - prev.Z;

            if (Distance2D(hostagePosition, target) < 85f)
            {
                return AdvanceRouteIndex(route, currentIndex + 1, hostagePosition);
            }

            const float passTolerance = 35f;
            const float crossTrackTolerance = 75f;
            if (Math.Abs(dx) > Math.Abs(dz))
            {
                bool alignedWithSegment = Math.Abs(hostagePosition.Z - target.Z) < crossTrackTolerance;
                if (alignedWithSegment && dx > 0 && hostagePosition.X > target.X + passTolerance) return AdvanceRouteIndex(route, currentIndex + 1, hostagePosition);
                if (alignedWithSegment && dx < 0 && hostagePosition.X < target.X - passTolerance) return AdvanceRouteIndex(route, currentIndex + 1, hostagePosition);
            }
            else
            {
                bool alignedWithSegment = Math.Abs(hostagePosition.X - target.X) < crossTrackTolerance;
                if (alignedWithSegment && dz > 0 && hostagePosition.Z > target.Z + passTolerance) return AdvanceRouteIndex(route, currentIndex + 1, hostagePosition);
                if (alignedWithSegment && dz < 0 && hostagePosition.Z < target.Z - passTolerance) return AdvanceRouteIndex(route, currentIndex + 1, hostagePosition);
            }

            return currentIndex;
        }

        private bool HasReachedOrPassedWaypoint(List<xna.Vector3> route, int waypointIndex, xna.Vector3 currentPosition)
        {
            xna.Vector3 waypoint = route[waypointIndex];
            if (Distance2D(currentPosition, waypoint) < BallWaypointReachDistance)
            {
                return true;
            }

            if (waypointIndex <= 0)
            {
                return false;
            }

            xna.Vector3 previous = route[waypointIndex - 1];
            xna.Vector3 delta = waypoint - previous;
            const float passTolerance = 60f;
            if (Math.Abs(delta.X) > Math.Abs(delta.Z))
            {
                return delta.X >= 0f
                    ? currentPosition.X >= waypoint.X - passTolerance
                    : currentPosition.X <= waypoint.X + passTolerance;
            }

            return delta.Z >= 0f
                ? currentPosition.Z >= waypoint.Z - passTolerance
                : currentPosition.Z <= waypoint.Z + passTolerance;
        }

        private xna.Vector3 GetRouteDirection(List<xna.Vector3> route, int routeIndex, xna.Vector3 hostagePosition)
        {
            xna.Vector3 target = route[routeIndex];
            if (Distance2D(hostagePosition, target) < BallWaypointReachDistance && routeIndex < route.Count - 1)
            {
                target = route[routeIndex + 1];
            }

            return Normalize2D(target - hostagePosition);
        }

        private xna.Vector3 BuildSupportPoint(Mission mission, xna.Vector3 hostagePosition, xna.Vector3 pathDirection, xna.Vector3 sideDirection, float lateralOffset)
        {
            xna.Vector3 supportPoint = hostagePosition - pathDirection * SupportDistance + sideDirection * lateralOffset;
            return ClampAndAvoidObstacles(mission, supportPoint);
        }

        private xna.Vector3 BuildGuidePoint(Mission mission, List<xna.Vector3> route, int routeIndex, xna.Vector3 hostagePosition, float lateralOffset)
        {
            int guideIndex = Math.Min(route.Count - 1, Math.Max(1, routeIndex));
            xna.Vector3 guidePoint = route[guideIndex];
            if (route.Count > 2 && guideIndex == 1 && hostagePosition.X > route[1].X)
            {
                guidePoint = route[Math.Min(2, route.Count - 1)];
            }

            guidePoint.Z += lateralOffset * 0.9f;
            return ClampAndAvoidObstacles(mission, guidePoint);
        }

        private xna.Vector3 BuildOrbitPoint(Mission mission, xna.Vector3 fishPosition, xna.Vector3 hostagePosition, xna.Vector3 pathDirection, xna.Vector3 sideDirection, float lateralOffset)
        {
            xna.Vector3 fishToBall = hostagePosition - fishPosition;
            float cross = fishToBall.X * pathDirection.Z - fishToBall.Z * pathDirection.X;
            float sideSign;
            if (Math.Abs(lateralOffset) > 1f)
            {
                sideSign = Math.Sign(lateralOffset);
            }
            else
            {
                sideSign = cross >= 0 ? 1f : -1f;
            }

            xna.Vector3 orbitPoint = hostagePosition
                - pathDirection * OrbitRearDistance
                + sideDirection * sideSign * OrbitSideDistance;
            return ClampAndAvoidObstacles(mission, orbitPoint);
        }

        private List<xna.Vector3> BuildTransportRoute(float routeSide)
        {
            // 障碍(实测，每根 100(X)×1100(Z))：
            //   中央柱 obs1 X∈[-50,50]  Z∈[-550,550]
            //   左柱   obs3/5 X∈[-600,-500] 上段 Z∈[400,1500] 下段 Z∈[-1500,-400]，缝 |Z|<400
            //   右柱   obs2/4 X∈[500,600]   同上，缝 |Z|<400
            // 场地无任何直通走廊，必须蛇形。为让“穿缝”尽量可靠：
            //   - 只在“水平段(+X)”里穿过左/中/右柱，穿缝时 Z 固定在缝内(gapZ)、越柱时 Z 固定在柱顶外(peakZ)；
            //   - 相邻穿越之间用“竖直段(±Z)”提前把球的 Z 调到位；
            //   这样每次穿越都是纯 +X 推进，球不会因斜推蹭到柱边被弹回。
            float sign = routeSide >= 0f ? 1f : -1f;
            List<xna.Vector3> route = new List<xna.Vector3>();
            // 实测：纯竖直段(远离墙推)要求鱼站到球与墙之间(入口点 Z≈±1470 已出界)，球在该段长期停滞。
            // 改为斜线段：推球方向始终带 +X 分量或背离墙，入口点都落在场内。
            route.Add(new xna.Vector3(-1350f, 0, sign * 1050f)); // 0 球初始位置(近角落)
            // 实测：67° 的急抬升段需要反复绕球重新摆位。改为约 45° 的平缓折线，
            // 已校核球(半径 80)经过各柱边时仍有 >=28mm 余量。
            // 实测起点推向 ≈-54°，后撤点落在球与南/北墙之间，鱼绕到球西侧后 HLP 从球下方滑过、
            // 反复 ORB（opnb9 b0 c400-c1340 球几乎不动）。先沿墙近 +X 推一小段，后撤点落在球西侧开阔处。
            if (UseStartWaypoint) route.Add(new xna.Vector3(StartW0X, 0, sign * StartW0Z));
            route.Add(new xna.Vector3(RouteW1X, 0, sign * RouteW1Z));   // 1 斜推到左柱缝前
            route.Add(new xna.Vector3(-450f, 0, sign * RouteW2Z));   // 2 穿过左柱缝
            if (UseFlatTop)
            {
                // 实测：斜线 (-450,260)->(0,720) 在中柱侧面(x=±108)处 Z≈609，仅比柱端+球半径高 1mm，
                // 球大量卡死在 (±108,*)。改为先抬到柱顶外、水平越过、再下降。
                route.Add(new xna.Vector3(-MidTopX, 0, sign * MidTopZ));
                route.Add(new xna.Vector3(MidTopX, 0, sign * MidTopZ));
            }
            else
            {
                // 斜推越过中央柱顶。Z=720 时两条斜线离柱角 (±50,±550) 仅 83mm(球半径 80)，
                // 实测 gcn29 b1 贴柱西面 (-108,-537) 卡 200+ 周期。MPZ 可抬高峰值加大余量。
                route.Add(new xna.Vector3(0f, 0, sign * MidPeakZ));
            }
            route.Add(new xna.Vector3(450f, 0, sign * 260f));    // 斜推降回右柱缝
            route.Add(new xna.Vector3(850f, 0, sign * 180f));    // 穿过右柱缝
            route.Add(new xna.Vector3(1700f, 0, 0f));            // 出障碍区，回到中线
            route.Add(new xna.Vector3(2100f, 0, 0f));            // 安全区中心
            return route;
        }

        private void UpdateCarrierStallState(int hostageIndex, xna.Vector3 ballPosition, bool isPushing)
        {
            if (!carrierBallPositionInitialized[hostageIndex])
            {
                carrierLastBallPosition[hostageIndex] = ballPosition;
                carrierBallPositionInitialized[hostageIndex] = true;
                return;
            }

            float movement = Distance2D(carrierLastBallPosition[hostageIndex], ballPosition);
            carrierLastBallPosition[hostageIndex] = ballPosition;
            if (isPushing && movement < 4f)
            {
                carrierStalledCycles[hostageIndex]++;
                if (carrierStalledCycles[hostageIndex] >= 35)
                {
                    carrierStalledCycles[hostageIndex] = 0;
                    carrierRecoveryCycles[hostageIndex] = CarrierRecoveryDuration;
                }
            }
            else
            {
                carrierStalledCycles[hostageIndex] = 0;
            }
        }

        private bool IsNearTransportObstacle(Mission mission, xna.Vector3 ballPosition)
        {
            List<ObstacleBox> boxes = GetObstacleBoxes(mission, BallRoutePadding + 80f);
            for (int i = 0; i < boxes.Count; i++)
            {
                ObstacleBox box = boxes[i];
                if (ballPosition.X >= box.MinX && ballPosition.X <= box.MaxX
                    && ballPosition.Z >= box.MinZ && ballPosition.Z <= box.MaxZ)
                {
                    return true;
                }
            }
            return false;
        }

        private xna.Vector3 BuildTransportWaypoint(xna.Vector3 hostagePosition)
        {
            float sign = hostagePosition.Z >= 0 ? 1f : -1f;
            float signedZ = hostagePosition.Z * sign;

            if (hostagePosition.X < -900f)
            {
                return new xna.Vector3(-900f, 0, sign * 980f);
            }
            if (hostagePosition.X < -600f)
            {
                return new xna.Vector3(-900f, 0, 0f);
            }
            if (hostagePosition.X < -250f && signedZ > 180f)
            {
                return new xna.Vector3(-250f, 0, 0f);
            }
            if (hostagePosition.X < -250f)
            {
                return new xna.Vector3(-250f, 0, sign * 900f);
            }
            if (hostagePosition.X < 250f && signedZ > 180f)
            {
                return new xna.Vector3(250f, 0, sign * 900f);
            }
            if (hostagePosition.X < 250f)
            {
                return new xna.Vector3(250f, 0, 0f);
            }
            if (hostagePosition.X < 900f)
            {
                return new xna.Vector3(900f, 0, 0f);
            }
            if (hostagePosition.X < 1500f)
            {
                return new xna.Vector3(1500f, 0, sign * 180f);
            }

            return new xna.Vector3(GoalX, 0, sign * 80f);
        }



        private xna.Vector3 BuildApproachWaypoint(Mission mission, xna.Vector3 fishPosition, xna.Vector3 hostagePosition, xna.Vector3 supportPoint)
        {
            float sign = hostagePosition.Z >= 0 ? 1f : -1f;
            if (fishPosition.X > 950f)
            {
                return new xna.Vector3(900f, 0, sign * 700f);
            }
            if (fishPosition.X > 350f)
            {
                return new xna.Vector3(300f, 0, sign * 700f);
            }
            if (fishPosition.X > -150f)
            {
                return new xna.Vector3(-300f, 0, sign * 700f);
            }
            if (fishPosition.X > -950f)
            {
                return new xna.Vector3(-900f, 0, sign * 700f);
            }

            return ClampAndAvoidObstacles(mission, supportPoint);
        }



        private float ComputeBehindAlignment(xna.Vector3 fishPosition, xna.Vector3 hostagePosition, xna.Vector3 pathDirection)
        {
            xna.Vector3 relative = Normalize2D(fishPosition - hostagePosition);
            xna.Vector3 desiredRear = new xna.Vector3(-pathDirection.X, 0, -pathDirection.Z);
            return relative.X * desiredRear.X + relative.Z * desiredRear.Z;
        }

        private void EmitCarrierDebug(Mission mission, int fishIndex, int hostageIndex,
            RoboFish fish, Ball hostage, xna.Vector3 pushDirection, string phase, float controlDistance)
        {
            #region debug-point E:carrier-control
            if (ShouldEmitDebug(mission, fishIndex))
            {
                float desiredDirection = (float)Math.Atan2(pushDirection.Z, pushDirection.X);
                ReportDebug("E", "StrategyQuickRescue.cs:ControlAttacker", "[DEBUG] carrier control",
                    "{\"fishIndex\":" + fishIndex
                    + ",\"hostageIndex\":" + hostageIndex
                    + ",\"phase\":\"" + phase + "\""
                    + ",\"fishX\":" + ToInt(fish.PositionMm.X)
                    + ",\"fishZ\":" + ToInt(fish.PositionMm.Z)
                    + ",\"ballX\":" + ToInt(hostage.PositionMm.X)
                    + ",\"ballZ\":" + ToInt(hostage.PositionMm.Z)
                    + ",\"controlDistance\":" + ToInt(controlDistance)
                    + ",\"headingError\":" + ToDebugFloat(NormalizeAngle(desiredDirection - fish.BodyDirectionRad))
                    + ",\"routeIndex\":" + carrierRouteIndex[hostageIndex]
                    + ",\"hasContact\":" + (carrierHasContact[hostageIndex] ? "true" : "false")
                    + ",\"tCode\":" + decisions[fishIndex].TCode
                    + ",\"vCode\":" + decisions[fishIndex].VCode
                    + "}");
            }
            #endregion
        }

        private void DriveFishAlongPath(Mission mission, int teamId, int fishIndex, xna.Vector3 targetPoint, int maxVCode)
        {
            if (fishIndex >= mission.TeamsRef[teamId].Fishes.Count)
            {
                return;
            }

            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            // 每周期重新规划一条绕开障碍的可见性路径，然后朝第一个未到达的航点直行。
            // 不再缓存航点：缓存会导致“追身后旧点 / 穿过障碍后停住”，这是之前停滞的根源。
            List<xna.Vector3> fishPath = BuildVisibilityPath(mission, fish.PositionMm, targetPoint, FishRoutePadding);
            xna.Vector3 navPoint = GetNextWaypoint(fishPath, fish.PositionMm);
            DriveFishToPoint(mission, teamId, fishIndex, navPoint, maxVCode);
        }

        // 归位专用导航：把球（可选）当作半径 ballKeep 的方形障碍加入避障，
        // 规划一条从球外侧绕行到 target（球正后方整列点）的稳定路径，避免鱼穿过球顶偏它。
        private void DriveFishToBehind(Mission mission, int teamId, int fishIndex, xna.Vector3 target, int maxVCode, xna.Vector3 ballPos, float ballKeep)
        {
            if (fishIndex >= mission.TeamsRef[teamId].Fishes.Count)
            {
                return;
            }

            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            List<ObstacleBox> boxes = GetObstacleBoxes(mission, FishRoutePadding);
            if (ballKeep > 0f)
            {
                ObstacleBox ballBox = new ObstacleBox();
                ballBox.MinX = ballPos.X - ballKeep;
                ballBox.MaxX = ballPos.X + ballKeep;
                ballBox.MinZ = ballPos.Z - ballKeep;
                ballBox.MaxZ = ballPos.Z + ballKeep;
                boxes.Add(ballBox);
            }

            List<xna.Vector3> path = BuildVisibilityPathFromBoxes(mission, fish.PositionMm, target, boxes);
            xna.Vector3 navPoint = GetNextWaypoint(path, fish.PositionMm);
            DriveFishToPoint(mission, teamId, fishIndex, navPoint, maxVCode);
        }

        // 稳定导航（消除抖动的核心）：一次规划、缓存路径、单调推进航点。只有在下列情况才重规划：
        //   (1) 尚无缓存路径；(2) 目标点移动超过 160mm（球被推进/转角 pushDir 旋转）；
        //   (3) 航点已消耗完；(4) 鱼明显偏离当前路段(>260mm，说明被撞偏需重规划)。
        // 把球当半径 ballKeep 的方形障碍加入避障，让鱼绕过球而不是穿球顶。这样鱼沿固定路径
        // 平滑推进，不再每周期因“最近段/最短路”翻转而来回打转。
        private void NavigateStable(Mission mission, int teamId, int fishIndex, int hostageIndex,
            xna.Vector3 target, xna.Vector3 ballPos, float ballKeep, int maxVCode)
        {
            if (fishIndex >= mission.TeamsRef[teamId].Fishes.Count)
            {
                return;
            }

            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            xna.Vector3 fishPos = fish.PositionMm;

            List<xna.Vector3> path = cachedFishPath[hostageIndex];
            int wp = cachedPathWaypointIndex[hostageIndex];

            bool needReplan = path == null || path.Count < 2
                || Distance2D(cachedPathTarget[hostageIndex], target) > 160f
                || wp >= path.Count;
            if (!needReplan)
            {
                xna.Vector3 a = path[Math.Max(0, wp - 1)];
                xna.Vector3 b = path[Math.Min(path.Count - 1, wp)];
                if (DistancePointToSegment(fishPos, a, b) > 260f)
                {
                    needReplan = true;
                }
                // 实测：鱼切角后“鱼→当前航点”直线穿过立柱，鱼被顶死在柱边上千周期。此时必须重规划。
                else if (!IsSegmentClear(fishPos, b, GetObstacleBoxes(mission, 30f)))
                {
                    needReplan = true;
                }
            }

            if (needReplan)
            {
                List<ObstacleBox> boxes = GetObstacleBoxes(mission, FishRoutePadding);
                // 起点已在墙内(鱼正处于中柱 X 范围的球对侧)时不加墙，否则规划必失败。
                if (Math.Abs(fishPos.X) > 50f + FishRoutePadding || fishPos.Z * approachWallSide > 0f) AddApproachWall(boxes);
                // 鱼已贴近球时起点会落在球框内导致规划失败，此时收缩球框使起点在框外。
                float fishBallDist = Distance2D(fishPos, ballPos);
                if (ballKeep > fishBallDist * 0.7f - 10f) ballKeep = fishBallDist * 0.7f - 10f;
                if (ballKeep > 0f)
                {
                    ObstacleBox ballBox = new ObstacleBox();
                    ballBox.MinX = ballPos.X - ballKeep;
                    ballBox.MaxX = ballPos.X + ballKeep;
                    ballBox.MinZ = ballPos.Z - ballKeep;
                    ballBox.MaxZ = ballPos.Z + ballKeep;
                    boxes.Add(ballBox);
                }
                path = BuildVisibilityPathFromBoxes(mission, fishPos, target, boxes);
                if (lastPlanSource == "fallback")
                {
                    // 实测：走廊回退路径沿 Z=±950 直穿侧柱，鱼被顶死。先去掉球框、再缩小障碍余量重试。
                    path = BuildVisibilityPathFromBoxes(mission, fishPos, target, GetObstacleBoxes(mission, FishRoutePadding));
                    if (lastPlanSource == "fallback")
                    {
                        path = BuildVisibilityPathFromBoxes(mission, fishPos, target, GetObstacleBoxes(mission, 40f));
                    }
                }
                cachedFishPath[hostageIndex] = path;
                cachedPathTarget[hostageIndex] = target;
                wp = 1;
            }

            // 单调推进航点：到达当前航点(140mm 内)则前进，绝不回退。
            List<ObstacleBox> hardBoxes = GetObstacleBoxes(mission, 30f);
            while (wp < path.Count - 1 && Distance2D(fishPos, path[wp]) < 140f
                && IsSegmentClear(fishPos, path[wp + 1], hardBoxes))
            {
                wp++;
            }
            cachedPathWaypointIndex[hostageIndex] = wp;

            xna.Vector3 navPoint = path[Math.Min(wp, path.Count - 1)];
            // 速度按“剩余路径总长”而非到下一航点的距离决定，避免中间航点把鱼压成低速。
            float remaining = Distance2D(fishPos, navPoint);
            for (int k = wp; k < path.Count - 1; k++) remaining += Distance2D(path[k], path[k + 1]);
            xna.Vector3 delta = navPoint - fishPos;
            float angleError = NormalizeAngle((float)Math.Atan2(delta.Z, delta.X) - fish.BodyDirectionRad);
            decisions[fishIndex].TCode = DirectionToTCode(angleError);
            decisions[fishIndex].VCode = DistanceAndHeadingToVCode(remaining, angleError, maxVCode);
            DebugPhase[fishIndex] = (DebugPhase[fishIndex] ?? "") + string.Format(
                " nav=({0},{1}) wp={2}/{3} rp={4} V={5} T={6} src={7} tgt=({8},{9})", (int)navPoint.X, (int)navPoint.Z, wp, path.Count,
                needReplan ? 1 : 0, decisions[fishIndex].VCode, decisions[fishIndex].TCode, lastPlanSource,
                (int)target.X, (int)target.Z);
        }

        // 远程接近专用导航（防打圈）：鱼与球被立柱隔开时调用。沿“已验证无碰撞的运输路线”
        // 反向逐段回退到球侧，用固定航点逐格推进，杜绝每周期 Dijkstra 重规划在立柱前来回摆动。
        private void DriveFishApproachAlongRoute(Mission mission, int teamId, int fishIndex,
            List<xna.Vector3> route, xna.Vector3 ballPos, int maxVCode)
        {
            if (fishIndex >= mission.TeamsRef[teamId].Fishes.Count)
            {
                return;
            }

            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            xna.Vector3 fishPos = fish.PositionMm;

            // 找到离鱼最近的路段，目标取其低索引端，逐格回退（索引单调递减，始终朝球方向前进）。
            int nearestSeg = 1;
            float bestDist = float.MaxValue;
            for (int i = 1; i < route.Count; i++)
            {
                float d = DistancePointToSegment(fishPos, route[i - 1], route[i]);
                if (d < bestDist)
                {
                    bestDist = d;
                    nearestSeg = i;
                }
            }

            int targetIdx = nearestSeg - 1;
            while (targetIdx > 1 && Distance2D(fishPos, route[targetIdx]) < 150f)
            {
                targetIdx--;
            }
            xna.Vector3 navPoint = route[Math.Max(1, targetIdx)];
            DriveFishToPoint(mission, teamId, fishIndex, navPoint, maxVCode);
        }

        // 非 0 时 NavigateStable 规划会在中柱 X 范围内、球对侧(Z 符号 = -approachWallSide)加一道到场边的虚拟墙。
        private float approachWallSide;

        private void AddApproachWall(List<ObstacleBox> boxes)
        {
            if (approachWallSide == 0f) return;
            ObstacleBox wall = new ObstacleBox();
            wall.MinX = -50f - FishRoutePadding;
            wall.MaxX = 50f + FishRoutePadding;
            wall.MinZ = approachWallSide > 0f ? -1600f : 0f;
            wall.MaxZ = approachWallSide > 0f ? 0f : 1600f;
            boxes.Add(wall);
        }

        // 与 BuildVisibilityPath 相同的 Dijkstra 可见性图求解，但直接使用调用方给定的障碍框
        // （用于把球临时当障碍）。无路径时回退到走廊路径。
        private List<xna.Vector3> BuildVisibilityPathFromBoxes(Mission mission, xna.Vector3 start, xna.Vector3 target, List<ObstacleBox> boxes)
        {
            start = ClampToField(mission, start, FieldMargin);
            // 鱼贴柱角时起点落在膨胀柱框内，Dijkstra 必失败并回退走廊路径
            // (occ2 c280 鱼在 (-81,569)，回退点 (-300,950) 让鱼兜圈约 370 周期)。起点也推出框外。
            if (UseStartPushOut) start = PushOutOfBoxes(start, boxes);
            target = PushOutOfBoxes(ClampToField(mission, target, FieldMargin), boxes);

            if (IsSegmentClear(start, target, boxes))
            {
                lastPlanSource = "direct";
                List<xna.Vector3> directPath = new List<xna.Vector3>();
                directPath.Add(start);
                directPath.Add(target);
                return directPath;
            }

            List<xna.Vector3> nodes = BuildNavigationNodes(mission, boxes, start, target);
            int nodeCount = nodes.Count;
            float[] dist = new float[nodeCount];
            int[] prev = new int[nodeCount];
            bool[] visited = new bool[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                dist[i] = float.MaxValue;
                prev[i] = -1;
            }
            dist[0] = 0f;

            for (int step = 0; step < nodeCount; step++)
            {
                int current = -1;
                float bestDistance = float.MaxValue;
                for (int i = 0; i < nodeCount; i++)
                {
                    if (!visited[i] && dist[i] < bestDistance)
                    {
                        bestDistance = dist[i];
                        current = i;
                    }
                }

                if (current == -1 || current == 1)
                {
                    break;
                }

                visited[current] = true;
                for (int next = 0; next < nodeCount; next++)
                {
                    if (next == current || visited[next])
                    {
                        continue;
                    }
                    if (!CanConnectNavigationNode(current, next, nodes, boxes))
                    {
                        continue;
                    }
                    float candidate = dist[current] + Distance2D(nodes[current], nodes[next]);
                    if (candidate < dist[next])
                    {
                        dist[next] = candidate;
                        prev[next] = current;
                    }
                }
            }

            if (prev[1] == -1)
            {
                lastPlanSource = "fallback";
                return BuildCorridorFallbackPath(mission, start, target);
            }

            lastPlanSource = "graph";
            List<xna.Vector3> path = new List<xna.Vector3>();
            int cursor = 1;
            while (cursor != -1)
            {
                path.Add(nodes[cursor]);
                cursor = prev[cursor];
            }
            path.Reverse();
            return SmoothPath(path, boxes);
        }

        private string lastPlanSource = "";
        private readonly int[] orbitDirMemory = new int[4];

        // 目标点落在障碍框内（如 entry 点被球框/柱框覆盖）时 Dijkstra 必然失败，把它推到最近框边外 10mm。
        private xna.Vector3 PushOutOfBoxes(xna.Vector3 p, List<ObstacleBox> boxes)
        {
            for (int iter = 0; iter < 4; iter++)
            {
                bool moved = false;
                for (int i = 0; i < boxes.Count; i++)
                {
                    ObstacleBox b = boxes[i];
                    if (p.X > b.MinX - 1f && p.X < b.MaxX + 1f && p.Z > b.MinZ - 1f && p.Z < b.MaxZ + 1f)
                    {
                        float dl = p.X - b.MinX, dr = b.MaxX - p.X, dt = p.Z - b.MinZ, db = b.MaxZ - p.Z;
                        float m = Math.Min(Math.Min(dl, dr), Math.Min(dt, db));
                        if (m == dl) p.X = b.MinX - 10f;
                        else if (m == dr) p.X = b.MaxX + 10f;
                        else if (m == dt) p.Z = b.MinZ - 10f;
                        else p.Z = b.MaxZ + 10f;
                        moved = true;
                    }
                }
                if (!moved) break;
            }
            return p;
        }

        // 拉绳平滑：网格 Dijkstra 得到的是 100mm 锯齿路径，航点密集导致鱼频繁转向、始终低速。
        // 从每个航点出发跳到最远的可直视航点，得到只在障碍拐角处转折的少量长直段。
        private List<xna.Vector3> SmoothPath(List<xna.Vector3> path, List<ObstacleBox> boxes)
        {
            if (path.Count <= 2) return path;
            List<xna.Vector3> result = new List<xna.Vector3>();
            result.Add(path[0]);
            int i = 0;
            while (i < path.Count - 1)
            {
                int j = path.Count - 1;
                while (j > i + 1 && !IsSegmentClear(path[i], path[j], boxes)) j--;
                result.Add(path[j]);
                i = j;
            }
            return result;
        }

        private void DriveFishToPoint(Mission mission, int teamId, int fishIndex, xna.Vector3 targetPoint, int maxVCode)
        {
            RoboFish fish = mission.TeamsRef[teamId].Fishes[fishIndex];
            xna.Vector3 delta = targetPoint - fish.PositionMm;
            float distance = Distance2D(fish.PositionMm, targetPoint);
            float desiredDirection = (float)Math.Atan2(delta.Z, delta.X);
            float angleError = NormalizeAngle(desiredDirection - fish.BodyDirectionRad);

            decisions[fishIndex].TCode = DirectionToTCode(angleError);
            decisions[fishIndex].VCode = DistanceAndHeadingToVCode(distance, angleError, maxVCode);
        }

        private List<xna.Vector3> BuildVisibilityPath(Mission mission, xna.Vector3 start, xna.Vector3 target, float obstaclePadding)
        {
            start = ClampToField(mission, start, FieldMargin);
            target = ClampToField(mission, target, FieldMargin);

            List<ObstacleBox> boxes = GetObstacleBoxes(mission, obstaclePadding);
            if (IsSegmentClear(start, target, boxes))
            {
                #region debug-point A:direct-path
                if (ShouldEmitDebug(mission, -1))
                {
                    ReportDebug("A", "StrategyQuickRescue.cs:BuildVisibilityPath", "[DEBUG] direct path",
                        "{\"padding\":" + ToInt(obstaclePadding)
                        + ",\"startX\":" + ToInt(start.X)
                        + ",\"startZ\":" + ToInt(start.Z)
                        + ",\"targetX\":" + ToInt(target.X)
                        + ",\"targetZ\":" + ToInt(target.Z)
                        + "}");
                }
                #endregion
                List<xna.Vector3> directPath = new List<xna.Vector3>();
                directPath.Add(start);
                directPath.Add(target);
                return directPath;
            }

            List<xna.Vector3> nodes = BuildNavigationNodes(mission, boxes, start, target);

            int nodeCount = nodes.Count;
            float[] dist = new float[nodeCount];
            int[] prev = new int[nodeCount];
            bool[] visited = new bool[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                dist[i] = float.MaxValue;
                prev[i] = -1;
            }
            dist[0] = 0f;

            for (int step = 0; step < nodeCount; step++)
            {
                int current = -1;
                float bestDistance = float.MaxValue;
                for (int i = 0; i < nodeCount; i++)
                {
                    if (!visited[i] && dist[i] < bestDistance)
                    {
                        bestDistance = dist[i];
                        current = i;
                    }
                }

                if (current == -1 || current == 1)
                {
                    break;
                }

                visited[current] = true;
                for (int next = 0; next < nodeCount; next++)
                {
                    if (next == current || visited[next])
                    {
                        continue;
                    }

                    if (!CanConnectNavigationNode(current, next, nodes, boxes))
                    {
                        continue;
                    }

                    float candidate = dist[current] + Distance2D(nodes[current], nodes[next]);
                    if (candidate < dist[next])
                    {
                        dist[next] = candidate;
                        prev[next] = current;
                    }
                }
            }

            List<xna.Vector3> path = new List<xna.Vector3>();
            if (prev[1] == -1)
            {
                if (obstaclePadding > 120f)
                {
                    return BuildVisibilityPath(mission, start, target, obstaclePadding - 40f);
                }
                #region debug-point D:path-fallback
                if (ShouldEmitDebug(mission, -1))
                {
                    ReportDebug("D", "StrategyQuickRescue.cs:BuildVisibilityPath", "[DEBUG] path fallback",
                        "{\"padding\":" + ToInt(obstaclePadding)
                        + ",\"nodeCount\":" + nodeCount
                        + ",\"startX\":" + ToInt(start.X)
                        + ",\"startZ\":" + ToInt(start.Z)
                        + ",\"targetX\":" + ToInt(target.X)
                        + ",\"targetZ\":" + ToInt(target.Z)
                        + "}");
                }
                #endregion
                return BuildCorridorFallbackPath(mission, start, target);
            }

            int cursor = 1;
            while (cursor != -1)
            {
                path.Add(nodes[cursor]);
                cursor = prev[cursor];
            }
            path.Reverse();
            #region debug-point D:path-planned
            if (ShouldEmitDebug(mission, -1))
            {
                ReportDebug("D", "StrategyQuickRescue.cs:BuildVisibilityPath", "[DEBUG] path planned",
                    "{\"padding\":" + ToInt(obstaclePadding)
                    + ",\"nodeCount\":" + nodeCount
                    + ",\"pathCount\":" + path.Count
                    + ",\"firstX\":" + ToInt(path[0].X)
                    + ",\"firstZ\":" + ToInt(path[0].Z)
                    + ",\"lastX\":" + ToInt(path[path.Count - 1].X)
                    + ",\"lastZ\":" + ToInt(path[path.Count - 1].Z)
                    + "}");
            }
            #endregion
            return path;
        }

        private List<xna.Vector3> BuildCorridorFallbackPath(Mission mission, xna.Vector3 start, xna.Vector3 target)
        {
            float sign = Math.Abs(start.Z) >= Math.Abs(target.Z)
                ? (start.Z >= 0 ? 1f : -1f)
                : (target.Z >= 0 ? 1f : -1f);
            List<xna.Vector3> path = new List<xna.Vector3>();
            path.Add(start);

            float[] corridorXs = new float[] { -1500f, -900f, -300f, 300f, 900f, 1500f };
            if (target.X >= start.X)
            {
                for (int i = 0; i < corridorXs.Length; i++)
                {
                    if (corridorXs[i] > start.X && corridorXs[i] < target.X)
                    {
                        path.Add(ClampAndAvoidObstacles(mission, new xna.Vector3(corridorXs[i], 0, sign * CorridorOuterZ)));
                    }
                }
            }
            else
            {
                for (int i = corridorXs.Length - 1; i >= 0; i--)
                {
                    if (corridorXs[i] < start.X && corridorXs[i] > target.X)
                    {
                        path.Add(ClampAndAvoidObstacles(mission, new xna.Vector3(corridorXs[i], 0, sign * CorridorOuterZ)));
                    }
                }
            }

            if (Math.Abs(sign * CorridorOuterZ - target.Z) > 180f)
            {
                path.Add(ClampAndAvoidObstacles(mission, new xna.Vector3(target.X, 0, sign * CorridorInnerZ)));
            }

            path.Add(target);
            return path;
        }

        private List<xna.Vector3> BuildNavigationNodes(Mission mission, List<ObstacleBox> boxes, xna.Vector3 start, xna.Vector3 target)
        {
            List<xna.Vector3> nodes = new List<xna.Vector3>();
            nodes.Add(start);
            nodes.Add(target);

            Field field = mission.EnvRef.FieldInfo;
            for (float x = field.LeftMm + FieldMargin; x <= field.RightMm - FieldMargin; x += NavigationGridStep)
            {
                for (float z = field.TopMm + FieldMargin; z <= field.BottomMm - FieldMargin; z += NavigationGridStep)
                {
                    xna.Vector3 node = new xna.Vector3(x, 0, z);
                    if (IsPointClear(node, boxes))
                    {
                        nodes.Add(node);
                    }
                }
            }

            return nodes;
        }

        private bool CanConnectNavigationNode(int current, int next, List<xna.Vector3> nodes, List<ObstacleBox> boxes)
        {
            float distance = Distance2D(nodes[current], nodes[next]);
            bool isAnchorEdge = current < 2 || next < 2;
            float maxDistance = isAnchorEdge ? NavigationAnchorDistance : NavigationNeighborDistance;
            if (distance > maxDistance)
            {
                return false;
            }

            return IsSegmentClear(nodes[current], nodes[next], boxes);
        }

        private List<ObstacleBox> GetObstacleBoxes(Mission mission, float obstaclePadding)
        {
            List<ObstacleBox> result = new List<ObstacleBox>();
            for (int i = 0; i < mission.EnvRef.ObstaclesRect.Count; i++)
            {
                RectangularObstacle obstacle = mission.EnvRef.ObstaclesRect[i];
                float halfX = obstacle.LengthMm * 0.5f + obstaclePadding;
                float halfZ = obstacle.WidthMm * 0.5f + obstaclePadding;
                ObstacleBox box = new ObstacleBox();
                box.MinX = obstacle.PositionMm.X - halfX;
                box.MaxX = obstacle.PositionMm.X + halfX;
                box.MinZ = obstacle.PositionMm.Z - halfZ;
                box.MaxZ = obstacle.PositionMm.Z + halfZ;
                result.Add(box);
            }
            return result;
        }

        // 球贴近柱面且推向指向柱内时，去掉法向分量，让球沿柱面滑向缝隙/出口，避免被顶死在柱面上。
        private xna.Vector3 SlideAlongPillarFace(Mission mission, xna.Vector3 ballPos, xna.Vector3 pushDir)
        {
            List<ObstacleBox> boxes = GetObstacleBoxes(mission, FaceSlidePadding);
            for (int i = 0; i < boxes.Count; i++)
            {
                ObstacleBox box = boxes[i];
                if (ballPos.X <= box.MinX || ballPos.X >= box.MaxX || ballPos.Z <= box.MinZ || ballPos.Z >= box.MaxZ)
                {
                    continue;
                }

                // 取离得最近的面作为接触面。
                float dLeft = ballPos.X - box.MinX, dRight = box.MaxX - ballPos.X;
                float dTop = ballPos.Z - box.MinZ, dBottom = box.MaxZ - ballPos.Z;
                float nx = 0f, nz = 0f;
                float best = Math.Min(Math.Min(dLeft, dRight), Math.Min(dTop, dBottom));
                if (best == dLeft) nx = -1f;
                else if (best == dRight) nx = 1f;
                else if (best == dTop) nz = -1f;
                else nz = 1f;

                float dot = pushDir.X * nx + pushDir.Z * nz;
                if (dot >= 0f)
                {
                    return pushDir;
                }

                xna.Vector3 slide = new xna.Vector3(pushDir.X - dot * nx, 0f, pushDir.Z - dot * nz);
                if (slide.X * slide.X + slide.Z * slide.Z < 0.04f)
                {
                    // 几乎正对柱面：X 面朝 |Z| 变小（缝隙）滑，Z 面朝 +X（安全区）滑。
                    slide = nx != 0f
                        ? new xna.Vector3(0f, 0f, ballPos.Z >= 0f ? -1f : 1f)
                        : new xna.Vector3(1f, 0f, 0f);
                }
                return Normalize2D(slide);
            }
            return pushDir;
        }

        // 球周围 300mm 圆上、从“球正后方”向两侧交替搜索第一个满足：在场内、不在柱内、与球之间无柱遮挡的点。
        private xna.Vector3 FindVisibleEntry(Mission mission, xna.Vector3 ballPos, xna.Vector3 pushDir)
        {
            Field field = mission.EnvRef.FieldInfo;
            List<ObstacleBox> solid = GetObstacleBoxes(mission, 0f);
            List<ObstacleBox> padded = GetObstacleBoxes(mission, 90f);
            float behind = (float)Math.Atan2(-pushDir.Z, -pushDir.X);
            float R = OccEntryR;
            for (int k = 0; k <= 10; k++)
            {
                for (int s = -1; s <= 1; s += 2)
                {
                    if (k == 0 && s > 0) continue;
                    float a = behind + s * k * 0.3f;
                    xna.Vector3 p = new xna.Vector3(ballPos.X + R * (float)Math.Cos(a), 0, ballPos.Z + R * (float)Math.Sin(a));
                    if (p.X < field.LeftMm + 150f || p.X > field.RightMm - 150f
                        || p.Z < field.TopMm + 150f || p.Z > field.BottomMm - 150f) continue;
                    if (!IsPointClear(p, padded) || !IsSegmentClear(p, ballPos, solid)) continue;
                    return p;
                }
            }
            return ballPos - pushDir * R;
        }

        private bool IsPointClear(xna.Vector3 point, List<ObstacleBox> boxes)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                ObstacleBox box = boxes[i];
                if (point.X > box.MinX && point.X < box.MaxX && point.Z > box.MinZ && point.Z < box.MaxZ)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSegmentClear(xna.Vector3 start, xna.Vector3 end, List<ObstacleBox> boxes)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                if (SegmentIntersectsBox(start, end, boxes[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool SegmentIntersectsBox(xna.Vector3 start, xna.Vector3 end, ObstacleBox box)
        {
            float tMin = 0f;
            float tMax = 1f;
            float dx = end.X - start.X;
            float dz = end.Z - start.Z;

            if (!ClipSegment(start.X, dx, box.MinX, box.MaxX, ref tMin, ref tMax))
            {
                return false;
            }
            if (!ClipSegment(start.Z, dz, box.MinZ, box.MaxZ, ref tMin, ref tMax))
            {
                return false;
            }

            return tMax >= tMin && tMax >= 0f && tMin <= 1f;
        }

        private bool ClipSegment(float start, float delta, float minValue, float maxValue, ref float tMin, ref float tMax)
        {
            if (Math.Abs(delta) < 0.001f)
            {
                return start >= minValue && start <= maxValue;
            }

            float t1 = (minValue - start) / delta;
            float t2 = (maxValue - start) / delta;
            if (t1 > t2)
            {
                float tmp = t1;
                t1 = t2;
                t2 = tmp;
            }

            if (t1 > tMin)
            {
                tMin = t1;
            }
            if (t2 < tMax)
            {
                tMax = t2;
            }

            return tMin <= tMax;
        }

        private xna.Vector3 GetNextWaypoint(List<xna.Vector3> path, xna.Vector3 currentPosition)
        {
            for (int i = 1; i < path.Count; i++)
            {
                if (Distance2D(currentPosition, path[i]) > WaypointReachDistance)
                {
                    return path[i];
                }
            }
            return path[path.Count - 1];
        }

        private xna.Vector3 GetNextCachedWaypoint(List<xna.Vector3> path, ref int waypointIndex, xna.Vector3 currentPosition)
        {
            while (waypointIndex < path.Count - 1)
            {
                xna.Vector3 waypoint = path[waypointIndex];
                xna.Vector3 nextWaypoint = path[waypointIndex + 1];
                float segmentLength = Distance2D(waypoint, nextWaypoint);
                float distanceToWaypoint = Distance2D(currentPosition, waypoint);
                if (distanceToWaypoint <= WaypointReachDistance
                    || segmentLength > 0f
                    && Distance2D(currentPosition, nextWaypoint) < distanceToWaypoint
                    && distanceToWaypoint > WaypointReachDistance * 1.8f)
                {
                    waypointIndex++;
                }
                else
                {
                    break;
                }
            }
            return path[waypointIndex];
        }

        private xna.Vector3 GetRouteTarget(List<xna.Vector3> route, xna.Vector3 currentPosition)
        {
            for (int i = 1; i < route.Count - 1; i++)
            {
                if (Distance2D(currentPosition, route[i]) > WaypointReachDistance)
                {
                    return route[i];
                }
            }
            return route[route.Count - 1];
        }

        // 对方鱼挡在球前方推线上（实测 occb1 c1950-c2100 防守鱼停在球前 ~250mm，鱼绕球 150 周期不进）：
        // 推向朝远离挡路鱼的一侧偏转 DAA，偏转后球的前进段不能碰柱，否则试另一侧，都不行则保持原推向。
        private xna.Vector3 AvoidBlocker(Mission mission, int teamId, int hostageIndex, xna.Vector3 ballPos, xna.Vector3 pushDir)
        {
            xna.Vector3 perpDir = new xna.Vector3(-pushDir.Z, 0, pushDir.X);
            List<RoboFish> opp = mission.TeamsRef[1 - teamId].Fishes;
            for (int i = 0; i < opp.Count; i++)
            {
                xna.Vector3 rel = opp[i].PositionMm - ballPos;
                float along = rel.X * pushDir.X + rel.Z * pushDir.Z;
                float lat = rel.X * perpDir.X + rel.Z * perpDir.Z;
                if (along <= 0f || along > DefAvoidAhead || Math.Abs(lat) > DefAvoidLat)
                {
                    continue;
                }
                // 挡路鱼几乎正对时沿用上次偏转侧，防止左右来回切换
                float side = lat >= 0f ? -1f : 1f;
                if (blockerSide[hostageIndex] != 0f && Math.Abs(lat) < 60f) side = blockerSide[hostageIndex];
                List<ObstacleBox> boxes = GetObstacleBoxes(mission, 90f);
                float baseAngle = (float)Math.Atan2(pushDir.Z, pushDir.X);
                for (int k = 0; k < 2; k++, side = -side)
                {
                    float a = baseAngle + side * DefAvoidAngle;
                    xna.Vector3 cand = new xna.Vector3((float)Math.Cos(a), 0, (float)Math.Sin(a));
                    xna.Vector3 ahead = ClampToField(mission, ballPos + cand * 350f, FieldMargin);
                    if (IsSegmentClear(ballPos, ahead, boxes) && Distance2D(ahead, ballPos) > 300f)
                    {
                        blockerSide[hostageIndex] = side;
                        return cand;
                    }
                }
                return pushDir;
            }
            blockerSide[hostageIndex] = 0f;
            return pushDir;
        }

        private xna.Vector3 BuildRescueGoal(xna.Vector3 hostagePosition)
        {
            float goalZ = Clamp(hostagePosition.Z * 0.25f, -GoalHalfHeight, GoalHalfHeight);
            return new xna.Vector3(GoalX, 0, goalZ);
        }

        private int DirectionToTCode(float angleError)
        {
            // 实测(TURNPROBE)：V<=6 时转向速率随 T 单调，每档约 0.005 rad/cyc，满舵约 ±0.04 rad/cyc。
            // 增益取 0.1 rad/档，误差 0.7 rad 即满舵，避免大误差时只给 T=3/4 导致几乎不转。
            float normalized = Clamp(angleError / 0.1f, -7f, 7f);
            int offset = (int)Math.Round(normalized);
            return ClampInt(StraightTCode + offset, 0, 14);
        }

        // 实测 V>=8 时同一 (V,T) 的转向方向不可复现（随内部尾鳍状态翻转），因此速度上限取 6。
        private const int ReliableMaxVCode = 6;
        // 官方 Helpers.Dribble 推球（N=40 有防守实测均值 913，base 版约 -183）。
        private static readonly bool UseHelperDribble = Environment.GetEnvironmentVariable("HLP") != "0";
        private static readonly bool UseEscort = Environment.GetEnvironmentVariable("ESC2") != "0";
        private static readonly float EscortLead = EnvF("ESL", 0f);
        private static readonly float HelperBackR = EnvF("HBR", 40f), HelperTheta1 = EnvF("HT1", 10f),
            HelperTheta2 = EnvF("HT2", 30f);
        private static readonly float HelperBackK = EnvF("HBK", 0f);
        private static readonly bool UseFlatTop = Environment.GetEnvironmentVariable("MID") == "1";
        private static readonly float MidTopX = EnvF("MTX", 200f), MidTopZ = EnvF("MTZ", 720f);
        private static readonly bool UseFaceSlide = Environment.GetEnvironmentVariable("FSL") == "1";
        private static readonly bool UseVisibleCarrot = Environment.GetEnvironmentVariable("VIS") == "1";
        private static readonly float CarrotClear = EnvF("CCL", 85f), CarrotMinLook = EnvF("CML", 60f);
        private static readonly float FaceSlidePadding = EnvF("FSP", 90f);
        private static readonly bool UseOpenStraight = Environment.GetEnvironmentVariable("OPN") == "1";
        private static readonly float OpenStraightX = EnvF("OPNX", 720f), OpenStraightZ = EnvF("OPZ", 300f);
        private static readonly bool UseGoalCone = Environment.GetEnvironmentVariable("GCN") != "0";
        private static readonly float GoalConeX = EnvF("GCX", 720f), GoalConeZ = EnvF("GCZ", 380f);
        private static readonly bool UseApproachRoute = Environment.GetEnvironmentVariable("APR") != "0";
        private static readonly float MidPeakZ = EnvF("MPZ", 720f);
        private static readonly bool UseOccludedStage = Environment.GetEnvironmentVariable("OCC") != "0";
        private static readonly float OccEntryR = EnvF("OCR", 300f);
        private static readonly float DeltaSlowAngle = EnvF("DVC", 99f);
        private static readonly int DeltaSlowVCode = (int)EnvF("DVV", 3f);
        private static readonly bool UseGapFunnel = Environment.GetEnvironmentVariable("FNL") == "1";
        private static readonly bool UseStartPushOut = Environment.GetEnvironmentVariable("PSO") == "1";
        private static readonly bool UseFarStage = Environment.GetEnvironmentVariable("FST") == "1";
        private static readonly float FarStageEnter = EnvF("FSI", 2.0f), FarStageExit = EnvF("FSO", 1.0f),
            FarStageMinDist = EnvF("FSR", 300f), FarStageMaxX = EnvF("FSX", 9999f);
        private readonly bool[] farStageLatch = new bool[4];
        private static readonly bool UseDefAvoid = Environment.GetEnvironmentVariable("DAV") == "1";
        private static readonly float DefAvoidAngle = EnvF("DAA", 0.6f), DefAvoidAhead = EnvF("DAH", 450f),
            DefAvoidLat = EnvF("DAL", 220f);
        private static readonly float FunnelDepth = EnvF("FND", 300f), FunnelMinZ = EnvF("FNM", 320f),
            FunnelZ = EnvF("FNZ", 240f);
        private static readonly float TurnFarDist = EnvF("TFD", 1e9f);
        private static readonly int OpenZoneVCode = (int)EnvF("OPV", 6f);
        private static readonly float OpenZoneLeftX = EnvF("OPL", -800f), OpenZoneRightX = EnvF("OPR", 700f);
        private static readonly int TurnFarVCode = (int)EnvF("TFV", 6f);
        private static readonly float RouteW1X = EnvF("W1X", -750f), RouteW1Z = EnvF("W1Z", 230f),
            RouteW2Z = EnvF("W2Z", 260f), CarrotLookAhead = EnvF("CAR", 350f);
        private static readonly bool UseRouteVisibility = Environment.GetEnvironmentVariable("RVS") != "0";
        private static readonly bool UseStartWaypoint = Environment.GetEnvironmentVariable("W0") == "1";
        private static readonly float StartW0X = EnvF("W0X", -1050f), StartW0Z = EnvF("W0Z", 1000f);
        private static readonly int TransitMaxVCode = (int)EnvF("TRV", ReliableMaxVCode);
        private static readonly float TransitAngle = EnvF("TRA", 0.3f), TransitMinDist = EnvF("TRD", 600f);
        private static readonly int HelperCycles = (int)EnvF("HCY", 10);
        private static readonly bool UseArcApproach = Environment.GetEnvironmentVariable("ARC") != "0";
        private static readonly float ArcMinDist = EnvF("ARD", 280f), ArcMinDelta = EnvF("ARL", 0.35f);
        private static readonly int ArcTurnVCode = (int)EnvF("ARV", 1f);
        private static readonly bool UseTurnInPlace = Environment.GetEnvironmentVariable("TIP") == "1";
        private static readonly float TurnInPlaceDist = EnvF("TPD", 170f);
        private static readonly int TurnInPlaceVCode = (int)EnvF("TPV", 0f);
        private static readonly float HeadingBrakeAngle = EnvF("HBA", 99f), HeadingBrakeDist = EnvF("HBD", 350f);
        private static readonly int HeadingBrakeVCode = (int)EnvF("HBV", 3f);
        private static readonly int HelperVCap = (int)EnvF("HCAP", ReliableMaxVCode);
        private static readonly float OrbitEnter = EnvF("ORI", 1.4f), OrbitExit = EnvF("ORO", 0.9f);
        private static readonly int HelperV1 = (int)EnvF("HV1", 6), HelperV2 = (int)EnvF("HV2", 6);
        private static float EnvF(string name, float def)
        {
            float v;
            string s = Environment.GetEnvironmentVariable(name);
            return (s != null && float.TryParse(s, out v)) ? v : def;
        }

        private int DistanceAndHeadingToVCode(float distance, float angleError, int maxVCode)
        {
            float absAngle = Math.Abs(angleError);
            // 高 V 只影响转向可复现性；航向已对准的远距离直线巡航允许提速。
            if (!defenseDriving && absAngle < TransitAngle && distance > TransitMinDist)
            {
                return Math.Min(maxVCode, TransitMaxVCode);
            }
            maxVCode = Math.Min(maxVCode, ReliableMaxVCode);
            if (distance < 60f)
            {
                return 2;
            }
            // 实测：所有 V 满舵转速都只有约 0.04 rad/cyc，V=4 转弯半径约 225mm，近距离大角度时会绕目标点
            // 打圈上百周期。近距离大角度改用 V=1(半径约 70~200mm)先转向。
            if (absAngle > 0.8f && distance < 450f)
            {
                return 1;
            }
            if (absAngle > 0.5f)
            {
                // 转速与 V 无关，远距离大角度时用更高 V 边转边走，半径变大但目标够远不会绕圈。
                if (!defenseDriving && distance > TurnFarDist)
                {
                    return Math.Min(maxVCode, TurnFarVCode);
                }
                return Math.Min(maxVCode, 4);
            }
            if (distance > 1200f)
            {
                return maxVCode;
            }
            if (distance > 700f)
            {
                return Math.Min(maxVCode, 10);
            }
            if (distance > 300f)
            {
                return Math.Min(maxVCode, 8);
            }
            return Math.Min(maxVCode, 6);
        }

        private bool IsNearFieldWall(Mission mission, xna.Vector3 point, float distance)
        {
            Field field = mission.EnvRef.FieldInfo;
            return point.X < field.LeftMm + distance
                || point.X > field.RightMm - distance
                || point.Z < field.TopMm + distance
                || point.Z > field.BottomMm - distance;
        }

        private xna.Vector3 ClampAndAvoidObstacles(Mission mission, xna.Vector3 point)
        {
            point = ClampToField(mission, point, FieldMargin);
            List<ObstacleBox> boxes = GetObstacleBoxes(mission, ObstaclePadding);
            for (int pass = 0; pass < 2; pass++)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    ObstacleBox box = boxes[i];
                    if (point.X > box.MinX && point.X < box.MaxX && point.Z > box.MinZ && point.Z < box.MaxZ)
                    {
                        float dxToMin = Math.Abs(point.X - box.MinX);
                        float dxToMax = Math.Abs(box.MaxX - point.X);
                        float dzToMin = Math.Abs(point.Z - box.MinZ);
                        float dzToMax = Math.Abs(box.MaxZ - point.Z);
                        if (Math.Min(dxToMin, dxToMax) < Math.Min(dzToMin, dzToMax))
                        {
                            point.X = dxToMin < dxToMax ? box.MinX - 40f : box.MaxX + 40f;
                        }
                        else
                        {
                            point.Z = dzToMin < dzToMax ? box.MinZ - 40f : box.MaxZ + 40f;
                        }
                    }
                }
                point = ClampToField(mission, point, FieldMargin);
            }
            return point;
        }

        private xna.Vector3 ClampToField(Mission mission, xna.Vector3 point, float margin)
        {
            Field field = mission.EnvRef.FieldInfo;
            point.X = Clamp(point.X, field.LeftMm + margin, field.RightMm - margin);
            point.Z = Clamp(point.Z, field.TopMm + margin, field.BottomMm - margin);
            return point;
        }

        private int ReadMissionInt(Mission mission, string key, int fallback)
        {
            if (!mission.HtMissionVariables.ContainsKey(key))
            {
                return fallback;
            }

            int value;
            if (Int32.TryParse(mission.HtMissionVariables[key].ToString(), out value))
            {
                return value;
            }

            return fallback;
        }

        private static float DistanceToGoal(xna.Vector3 point)
        {
            return Distance2D(point, new xna.Vector3(GoalX, 0, 0));
        }

        private static float Distance2D(xna.Vector3 a, xna.Vector3 b)
        {
            float dx = a.X - b.X;
            float dz = a.Z - b.Z;
            return (float)Math.Sqrt(dx * dx + dz * dz);
        }

        private static xna.Vector3 Normalize2D(xna.Vector3 vector)
        {
            float length = (float)Math.Sqrt(vector.X * vector.X + vector.Z * vector.Z);
            if (length < 0.001f)
            {
                return new xna.Vector3(1f, 0, 0);
            }

            return new xna.Vector3(vector.X / length, 0, vector.Z / length);
        }

        private static float NormalizeAngle(float angle)
        {
            while (angle > Math.PI)
            {
                angle -= (float)(Math.PI * 2.0);
            }
            while (angle < -Math.PI)
            {
                angle += (float)(Math.PI * 2.0);
            }
            return angle;
        }

        private static float Clamp(float value, float minValue, float maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }
            if (value > maxValue)
            {
                return maxValue;
            }
            return value;
        }

        private static int ClampInt(int value, int minValue, int maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }
            if (value > maxValue)
            {
                return maxValue;
            }
            return value;
        }

        private bool ShouldEmitDebug(Mission mission, int fishIndex)
        {
            int slot = fishIndex < 0 ? 0 : fishIndex * 5;
            return mission.CommonPara.RemainingCycles % 20 == slot;
        }

        private static int ToInt(float value)
        {
            return (int)Math.Round(value);
        }

        private static string ToDebugFloat(float value)
        {
            return value.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture);
        }

        private static void ReportDebug(string hypothesisId, string location, string msg, string dataJson)
        {
            #region debug-point network-report
            try { string payload = "{\"sessionId\":\"" + DebugSessionId + "\",\"runId\":\"" + DebugRunId + "\",\"hypothesisId\":\"" + hypothesisId + "\",\"location\":\"" + location + "\",\"msg\":\"" + msg + "\",\"data\":" + dataJson + "}"; byte[] body = System.Text.Encoding.UTF8.GetBytes(payload); System.Threading.ThreadPool.QueueUserWorkItem(delegate { try { System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(DebugServerUrl); request.Method = "POST"; request.ContentType = "application/json"; request.ContentLength = body.Length; using (System.IO.Stream stream = request.GetRequestStream()) { stream.Write(body, 0, body.Length); } using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse()) { } } catch { } }); } catch { }
            #endregion
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
                    opts.Mission = "quick-rescue";
                    opts.TeamId = teamId.ToString(CultureInfo.InvariantCulture);
                    opts.FileNamePrefix = "quick_rescue";
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
                int fishCnt = mission.CommonPara.FishCntPerTeam;
                int cycle = mission.CommonPara.TotalSeconds * 1000 / mission.CommonPara.MsPerCycle - mission.CommonPara.RemainingCycles;
                List<FrameRow> rows = new List<FrameRow>(fishCnt);
                for (int i = 0; i < fishCnt; i++)
                {
                    Decision dec = decisions[i];
                    RoboFish fish = mission.TeamsRef[teamId].Fishes[i];
                    string phase = (DebugPhase[i] != null) ? DebugPhase[i] : "";
                    string cidx = (i < HostageCount && carrierFishIndex[i] >= 0) ? carrierFishIndex[i].ToString(CultureInfo.InvariantCulture) : "";
                    string staged = (i < HostageCount && carrierStaged[i]) ? "1" : "0";
                    rows.Add(new FrameRow(new string[] {
                        cycle.ToString(CultureInfo.InvariantCulture),
                        i.ToString(CultureInfo.InvariantCulture),
                        dec.VCode.ToString(CultureInfo.InvariantCulture),
                        dec.TCode.ToString(CultureInfo.InvariantCulture),
                        fish.PositionMm.X.ToString("F3", CultureInfo.InvariantCulture),
                        fish.PositionMm.Z.ToString("F3", CultureInfo.InvariantCulture),
                        fish.BodyDirectionRad.ToString("F4", CultureInfo.InvariantCulture),
                        phase,
                        cidx,
                        staged
                    }));
                }
                _diagLogger.WriteFrame(rows);
            }
            catch { }
        }
    }
}
