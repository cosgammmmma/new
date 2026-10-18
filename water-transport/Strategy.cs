using System;
using System.Collections.Generic;
using URWPGSim2D.Common;
using URWPGSim2D.Core;
using URWPGSim2D.StrategyLoader;
using System.Globalization;
using FrameDiagnostics;
using Microsoft.Xna.Framework;

namespace URWPGSim2D.Strategy
{
    public sealed class Strategy : MarshalByRefObject, IStrategy
    {
        private static readonly Vector3[] Goals = {
            new Vector3(0, 0, 0), new Vector3(-240, 0, -160),
            new Vector3(-240, 0, 160), new Vector3(-480, 0, -320),
            new Vector3(-480, 0, 0), new Vector3(-480, 0, 320)
        };
        private static readonly int[][] Orders = { new int[] { 5, 2, 4 }, new int[] { 3, 1, 0 } };
        private readonly int[] targets = { -1, -1 };
        private readonly bool[] pushing = new bool[2];
        private readonly List<Vector3>[] routes = { new List<Vector3>(), new List<Vector3>() };
        private readonly Vector3[] routeGoals = new Vector3[2];
        private readonly int[] routeAge = new int[2];
        private int lastRemaining = -1;
        private int lastScore;
        private static FrameLogger _diagLogger;
        private static int _diagLastRemaining = -1;
        private static readonly string[] DiagFields = new[] { "cycle", "fish_id", "vcode", "tcode", "x", "z", "body_dir", "target_ball", "pushing" };

        public override object InitializeLifetimeService() { return null; }
        public string GetTeamName() { return "WaterTransport"; }

        public Decision[] GetDecision(Mission mission, int teamId)
        {
            int count = mission == null ? 2 : mission.CommonPara.FishCntPerTeam;
            try { EnsureDiagnostics(mission, teamId); } catch { }
            Decision[] output = new Decision[count];
            for (int i = 0; i < count; i++) output[i].TCode = 7;
            if (mission == null || teamId < 0 || teamId >= mission.TeamsRef.Count
                || count != 2 || mission.CommonPara.TeamCount != 1 || mission.EnvRef.Balls.Count != 6
                || mission.CommonPara.RemainingCycles <= 0) { WriteDiagFrame(mission, teamId, output); return output; }
            // Mission variables survive a strategy reload; never infer completion from proximity.
            for (int b = 0; b < 6; b++)
                if (!mission.HtMissionVariables.ContainsKey("Ball" + b + "InHole")) { WriteDiagFrame(mission, teamId, output); return output; }

            int score = mission.TeamsRef[teamId].Para.Score;
            if (mission.CommonPara.RemainingCycles > lastRemaining || score < lastScore)
                for (int i = 0; i < 2; i++) { targets[i] = -1; pushing[i] = false; routes[i].Clear(); }
            lastRemaining = mission.CommonPara.RemainingCycles;
            lastScore = score;
            for (int i = 0; i < 2; i++)
            {
                int next = -1;
                foreach (int b in Orders[i])
                    if (!Scored(mission, b)) { next = b; break; }
                if (next != targets[i])
                {
                    targets[i] = next;
                    pushing[i] = false;
                    routes[i].Clear();
                }
            }
            for (int i = 0; i < 2; i++)
            {
                if (targets[i] < 0) continue;
                output[i] = Carry(mission, teamId, i, targets[i]);
            }
            WriteDiagFrame(mission, teamId, output);
            return output;
        }

        private void WriteDiagFrame(Mission m, int tid, Decision[] outp)
        {
            try
            {
                if (_diagLogger == null) return;
                int cycle = 0;
                if (m != null && m.CommonPara != null)
                    cycle = m.CommonPara.TotalSeconds * 1000 / m.CommonPara.MsPerCycle - m.CommonPara.RemainingCycles;
                string cycleStr = cycle.ToString(CultureInfo.InvariantCulture);
                List<string[]> rows = new List<string[]>();
                int fishCount = (m != null && m.TeamsRef != null && tid >= 0 && tid < m.TeamsRef.Count) ? m.TeamsRef[tid].Fishes.Count : 0;
                for (int i = 0; i < fishCount && i < outp.Length; i++)
                {
                    RoboFish fish = m.TeamsRef[tid].Fishes[i];
                    string xs = fish.PositionMm.X.ToString("F4", CultureInfo.InvariantCulture);
                    string zs = fish.PositionMm.Z.ToString("F4", CultureInfo.InvariantCulture);
                    string ds = fish.BodyDirectionRad.ToString("F4", CultureInfo.InvariantCulture);
                    string vcode = outp[i].VCode.ToString(CultureInfo.InvariantCulture);
                    string tcode = outp[i].TCode.ToString(CultureInfo.InvariantCulture);
                    string tb = (targets[i] >= 0) ? targets[i].ToString(CultureInfo.InvariantCulture) : "-1";
                    string push = pushing[i] ? "1" : "0";
                    rows.Add(new string[] { cycleStr, i.ToString(CultureInfo.InvariantCulture), vcode, tcode, xs, zs, ds, tb, push });
                }
                if (rows.Count > 0)
                {
                    FrameRow[] frameRows = new FrameRow[rows.Count];
                    for (int i = 0; i < rows.Count; i++)
                        frameRows[i] = new FrameRow(rows[i]);
                    _diagLogger.WriteFrame(frameRows);
                }
            }
            catch
            {
            }
        }

        private static void EnsureDiagnostics(Mission mission, int teamId)
        {
            int remaining = 0;
            if (mission != null && mission.CommonPara != null)
                remaining = mission.CommonPara.RemainingCycles;
            bool isNewMatch = false;
            if (remaining > 0 && _diagLastRemaining > remaining)
                isNewMatch = true;
            if (isNewMatch)
            {
                if (_diagLogger != null)
                    _diagLogger.Dispose();
                _diagLogger = null;
            }
            if (_diagLogger == null)
            {
                string dirPath = @"E:\progaram\URWPGSim2D\logs";
                System.IO.Directory.CreateDirectory(dirPath);
                FrameLoggerOptions opts = new FrameLoggerOptions();
                opts.DirectoryPath = dirPath;
                if (mission != null && mission.CommonPara != null)
                    _diagLastRemaining = mission.CommonPara.RemainingCycles;
                else
                    _diagLastRemaining = 0;
                opts.Mission = "water-transport";
                opts.TeamId = teamId.ToString(CultureInfo.InvariantCulture);
                opts.FileNamePrefix = "water_transport";
                opts.Enabled = true;
                _diagLogger = new FrameLogger(opts);
                _diagLogger.Begin(DiagFields);
            }
        }

        ~Strategy()
        {
            if (_diagLogger != null)
            {
                _diagLogger.Dispose();
                _diagLogger = null;
            }
        }

        private static bool Scored(Mission m, int b)
        {
            return Convert.ToString(m.HtMissionVariables["Ball" + b + "InHole"]) == "1";
        }

        private Decision Carry(Mission m, int team, int index, int ballIndex)
        {
            RoboFish fish = m.TeamsRef[team].Fishes[index];
            Ball ball = m.EnvRef.Balls[ballIndex];
            Vector3 b = ball.PositionMm;
            Vector3 f = fish.PositionMm;
            Vector3 goal = Goals[ballIndex];
            float distance = Dist(f, b), remaining = Dist(b, goal);
            float goalAngle = Angle(goal - b);
            float towardBall = Angle(b - f);
            float delta = Wrap(goalAngle - towardBall);
            float headingError = Wrap(goalAngle - fish.BodyDirectionRad);
            if (pushing[index] && (Math.Abs(delta) > 1.25f || distance > 450))
                pushing[index] = false;
            if (!pushing[index] && distance < 380 && Math.Abs(delta) < 0.5f)
            {
                pushing[index] = true;
                routes[index].Clear();
            }
            if (!pushing[index])
            {
                Vector3 behind = b - Unit(goalAngle) * 275;
                if (Dist(f, behind) < 65 && Math.Abs(delta) < 0.32f)
                    return Steer(fish, goalAngle, Math.Abs(headingError) < 0.25f ? 2 : 1);
                Vector3 waypoint = Navigate(m, index, f, behind, ballIndex);
                float e = Wrap(Angle(waypoint - f) - fish.BodyDirectionRad);
                int speed = Math.Abs(e) > 0.6f ? 1 : Math.Abs(e) > 0.25f ? 2 : 5;
                if (Dist(f, waypoint) < 110) speed = Math.Min(speed, 3);
                return Steer(fish, Angle(waypoint - f), speed);
            }

            // Aiming beyond the ball on the opposite side of the lateral error restores the push line.
            float aim = towardBall - Clamp(delta * 0.5f, -0.45f, 0.45f);
            float err = Wrap(aim - fish.BodyDirectionRad);
            int v = remaining > 220 ? 4 : remaining > 85 ? 3 : 2;
            if (distance > 240 && remaining > 85) v = 5;
            if (Math.Abs(err) > 0.55f) v = 1;
            else if (Math.Abs(err) > 0.22f || Math.Abs(delta) > 0.3f) v = Math.Min(v, 2);
            return Steer(fish, aim, v);
        }

        private static Decision Steer(RoboFish fish, float angle, int speed)
        {
            float error = Wrap(angle - fish.BodyDirectionRad - fish.AngularVelocityRadPs * 0.1f);
            float wanted = Clamp(error * 1.8f, -0.4f, 0.4f);
            int turn = 7;
            float best = float.MaxValue;
            for (int t = 0; t <= 14; t++)
            {
                float next = fish.AngularVelocityRadPs * 0.9f + DataBasedOnExperiment.TCodeAndAngularVelocityTable[t] * 0.1f;
                float cost = Math.Abs(next - wanted);
                if (cost < best) { best = cost; turn = t; }
            }
            Decision d = new Decision();
            d.TCode = Math.Max(0, Math.Min(14, turn));
            d.VCode = speed;
            return d;
        }

        private Vector3 Navigate(Mission m, int index, Vector3 start, Vector3 goal, int target)
        {
            List<Vector3> route = routes[index];
            while (route.Count > 0 && Dist(start, route[0]) < 65) route.RemoveAt(0);
            if (++routeAge[index] > 30 || Dist(goal, routeGoals[index]) > 50
                || route.Count == 0 || !Clear(m, start, route[0], target))
            {
                route.Clear();
                route.AddRange(Plan(m, start, goal, target));
                routeGoals[index] = goal;
                routeAge[index] = 0;
            }
            while (route.Count > 1 && Clear(m, start, route[1], target)) route.RemoveAt(0);
            // A local escape gives movement even when a displaced ball encloses the starting point.
            if (route.Count == 0)
            {
                Vector3 away = Vector3.Zero;
                foreach (Ball ball in m.EnvRef.Balls)
                    if (Dist(start, ball.PositionMm) < 240)
                        away += (start - ball.PositionMm) / Math.Max(1, Dist(start, ball.PositionMm));
                if (away.LengthSquared() > 0.01f) return start + Vector3.Normalize(away) * 180;
                return goal;
            }
            return route[0];
        }

        private static List<Vector3> Plan(Mission m, Vector3 start, Vector3 goal, int target)
        {
            List<Vector3> nodes = new List<Vector3>();
            nodes.Add(start); nodes.Add(goal);
            for (int b = 0; b < 6; b++)
                for (int k = 0; k < 16; k++)
                {
                    Vector3 p = m.EnvRef.Balls[b].PositionMm + Unit(k * (float)Math.PI / 8) * 245;
                    if (Inside(m, p) && Clear(m, p, p, target)) nodes.Add(p);
                }
            int n = nodes.Count;
            float[] costs = new float[n];
            int[] previous = new int[n];
            bool[] used = new bool[n];
            for (int i = 0; i < n; i++) { costs[i] = float.MaxValue; previous[i] = -1; }
            costs[0] = 0;
            for (int step = 0; step < n; step++)
            {
                int best = -1;
                for (int i = 0; i < n; i++)
                    if (!used[i] && costs[i] < float.MaxValue && (best < 0 || costs[i] < costs[best])) best = i;
                if (best < 0 || best == 1) break;
                used[best] = true;
                for (int j = 1; j < n; j++)
                {
                    float cost = costs[best] + Dist(nodes[best], nodes[j]);
                    if (!used[j] && cost < costs[j] && Clear(m, nodes[best], nodes[j], target))
                    { costs[j] = cost; previous[j] = best; }
                }
            }
            List<Vector3> path = new List<Vector3>();
            if (previous[1] < 0) return path;
            for (int i = 1; i != 0; i = previous[i]) path.Add(nodes[i]);
            path.Reverse();
            return path;
        }

        private static bool Clear(Mission m, Vector3 a, Vector3 b, int target)
        {
            if (!Inside(m, b)) return false;
            for (int i = 0; i < 6; i++)
            {
                Vector3 center = m.EnvRef.Balls[i].PositionMm;
                float radius = 220;
                float initial = Dist(a, center);
                // Permit a strictly outward escape, never crossing through a ball.
                if (initial < radius && Vector3.Dot(b - a, a - center) > 0) continue;
                if (SegmentDistance(center, a, b) < radius) return false;
            }
            return true;
        }

        private static bool Inside(Mission m, Vector3 p)
        {
            Field f = m.EnvRef.FieldInfo;
            return p.X > f.LeftMm + 120 && p.X < f.RightMm - 120
                && p.Z > f.TopMm + 120 && p.Z < f.BottomMm - 120;
        }

        private static float SegmentDistance(Vector3 p, Vector3 a, Vector3 b)
        {
            Vector3 v = b - a;
            float t = v.LengthSquared() < 0.01f ? 0 : Clamp(Vector3.Dot(p - a, v) / v.LengthSquared(), 0, 1);
            return Dist(p, a + v * t);
        }
        private static float Dist(Vector3 a, Vector3 b) { return (a - b).Length(); }
        private static float Angle(Vector3 v) { return (float)Math.Atan2(v.Z, v.X); }
        private static Vector3 Unit(float a) { return new Vector3((float)Math.Cos(a), 0, (float)Math.Sin(a)); }
        private static float Clamp(float v, float lo, float hi) { return Math.Max(lo, Math.Min(hi, v)); }
        private static float Wrap(float a)
        {
            while (a > Math.PI) a -= (float)(2 * Math.PI);
            while (a < -Math.PI) a += (float)(2 * Math.PI);
            return a;
        }
    }
}
