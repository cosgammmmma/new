using System;

namespace URWPGSim2D.Strategy
{
    // 纯几何类型：不依赖平台/XNA，便于脱离仿真器单测。坐标约定与平台一致（X 横向，Z 纵向，单位 mm）。
    internal struct Vec2
    {
        public float X;
        public float Z;

        public Vec2(float x, float z)
        {
            X = x;
            Z = z;
        }

        public static Vec2 operator +(Vec2 a, Vec2 b) { return new Vec2(a.X + b.X, a.Z + b.Z); }
        public static Vec2 operator -(Vec2 a, Vec2 b) { return new Vec2(a.X - b.X, a.Z - b.Z); }
        public static Vec2 operator *(Vec2 a, float k) { return new Vec2(a.X * k, a.Z * k); }

        public float Length { get { return (float)Math.Sqrt(X * X + Z * Z); } }

        public Vec2 Normalized
        {
            get
            {
                float len = Length;
                return len < 1e-4f ? new Vec2(0f, 0f) : new Vec2(X / len, Z / len);
            }
        }

        public static float Distance(Vec2 a, Vec2 b) { return (a - b).Length; }

        public override string ToString() { return "(" + X.ToString("0.0") + ", " + Z.ToString("0.0") + ")"; }
    }

    // 轴对齐矩形（障碍物的外接盒）。
    internal struct Box
    {
        public float CX;
        public float CZ;
        public float HalfX;
        public float HalfZ;

        public Box(float cx, float cz, float halfX, float halfZ)
        {
            CX = cx;
            CZ = cz;
            HalfX = halfX;
            HalfZ = halfZ;
        }

        public float MinX { get { return CX - HalfX; } }
        public float MaxX { get { return CX + HalfX; } }
        public float MinZ { get { return CZ - HalfZ; } }
        public float MaxZ { get { return CZ + HalfZ; } }

        public Box Inflate(float margin) { return new Box(CX, CZ, HalfX + margin, HalfZ + margin); }

        public bool Contains(Vec2 p)
        {
            return Math.Abs(p.X - CX) < HalfX && Math.Abs(p.Z - CZ) < HalfZ;
        }

        public bool Overlaps(Box o)
        {
            return Math.Abs(CX - o.CX) < HalfX + o.HalfX && Math.Abs(CZ - o.CZ) < HalfZ + o.HalfZ;
        }

        public static Box FromBounds(float minX, float maxX, float minZ, float maxZ)
        {
            return new Box((minX + maxX) * 0.5f, (minZ + maxZ) * 0.5f, (maxX - minX) * 0.5f, (maxZ - minZ) * 0.5f);
        }

        // 点到矩形边界的最短距离（在内部时为 0）。
        public float DistanceTo(Vec2 p)
        {
            float dx = Math.Max(0f, Math.Abs(p.X - CX) - HalfX);
            float dz = Math.Max(0f, Math.Abs(p.Z - CZ) - HalfZ);
            return (float)Math.Sqrt(dx * dx + dz * dz);
        }

        // 线段 a→b 是否穿过矩形内部（slab 法）。
        public bool IntersectsSegment(Vec2 a, Vec2 b)
        {
            float t0 = 0f;
            float t1 = 1f;
            if (!Slab(a.X, b.X - a.X, MinX, MaxX, ref t0, ref t1)) return false;
            if (!Slab(a.Z, b.Z - a.Z, MinZ, MaxZ, ref t0, ref t1)) return false;
            return t1 - t0 > 1e-4f;
        }

        private static bool Slab(float start, float delta, float min, float max, ref float t0, ref float t1)
        {
            if (Math.Abs(delta) < 1e-6f)
            {
                return start > min && start < max;
            }

            float ta = (min - start) / delta;
            float tb = (max - start) / delta;
            if (ta > tb)
            {
                float tmp = ta;
                ta = tb;
                tb = tmp;
            }

            t0 = Math.Max(t0, ta);
            t1 = Math.Min(t1, tb);
            return t0 < t1;
        }
    }

    // 场地边界。
    internal struct Arena
    {
        public float Left;
        public float Right;
        public float Top;
        public float Bottom;

        public Arena(float left, float right, float top, float bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public Vec2 Clamp(Vec2 p, float margin)
        {
            return new Vec2(
                Math.Max(Left + margin, Math.Min(Right - margin, p.X)),
                Math.Max(Top + margin, Math.Min(Bottom - margin, p.Z)));
        }

        public bool Inside(Vec2 p, float margin)
        {
            return p.X >= Left + margin && p.X <= Right - margin && p.Z >= Top + margin && p.Z <= Bottom - margin;
        }

        public float DistanceToEdge(Vec2 p)
        {
            return Math.Min(Math.Min(p.X - Left, Right - p.X), Math.Min(p.Z - Top, Bottom - p.Z));
        }
    }

    // 绕障导航：给出下一航点，保证 起点→航点 的线段不穿过膨胀后的障碍。
    // 做法：障碍按 clearance 膨胀，相互重叠的合并成簇（场上三块障碍间隙只有 300mm，膨胀后成一堵墙），
    // 被挡时在簇的四个外角中选 “起点可见 + 剩余路程最短” 的一个作为航点。
    internal static class Navigator
    {
        private const float CornerSlack = 40f;
        private const float EscapeSlack = 60f;
        private const float ReachedCorner = 30f;
        private const float UnreachablePenalty = 2000f;

        public static Vec2 NextWaypoint(Vec2 from, Vec2 to, Box[] obstacles, Arena arena, float clearance)
        {
            Box[] inflated = InflateAll(obstacles, clearance);
            to = arena.Clamp(to, clearance);

            for (int i = 0; i < inflated.Length; i++)
            {
                if (inflated[i].Contains(from))
                {
                    return arena.Clamp(PushOut(Cluster(inflated, i), from), clearance);
                }
            }

            for (int i = 0; i < inflated.Length; i++)
            {
                if (inflated[i].Contains(to))
                {
                    to = arena.Clamp(PushOut(Cluster(inflated, i), to), clearance);
                    break;
                }
            }

            int blocker = NearestBlocker(from, to, inflated);
            if (blocker < 0)
            {
                return to;
            }

            Box cluster = Cluster(inflated, blocker).Inflate(CornerSlack);
            Vec2[] corners = new Vec2[]
            {
                new Vec2(cluster.MinX, cluster.MinZ),
                new Vec2(cluster.MaxX, cluster.MinZ),
                new Vec2(cluster.MinX, cluster.MaxZ),
                new Vec2(cluster.MaxX, cluster.MaxZ),
            };

            int best = -1;
            float bestCost = float.MaxValue;
            for (int i = 0; i < corners.Length; i++)
            {
                Vec2 c = corners[i];
                if (!arena.Inside(c, clearance) || Vec2.Distance(from, c) < ReachedCorner || !Visible(from, c, inflated))
                {
                    continue;
                }

                float cost = Vec2.Distance(from, c) + CostToGoal(i, corners, to, inflated, arena, clearance);
                if (cost < bestCost)
                {
                    bestCost = cost;
                    best = i;
                }
            }

            if (best >= 0)
            {
                return corners[best];
            }

            // 兜底：没有可见外角（簇贴墙等极端情况），退回最近的外角。
            Vec2 fallback = corners[0];
            for (int i = 1; i < corners.Length; i++)
            {
                if (Vec2.Distance(from, corners[i]) < Vec2.Distance(from, fallback)) fallback = corners[i];
            }

            return arena.Clamp(fallback, clearance);
        }

        // 沿航点折线估算实际路程，用于目标选择。
        public static float EstimatePathLength(Vec2 from, Vec2 to, Box[] obstacles, Arena arena, float clearance)
        {
            float total = 0f;
            Vec2 p = from;
            for (int step = 0; step < 5; step++)
            {
                Vec2 w = NextWaypoint(p, to, obstacles, arena, clearance);
                total += Vec2.Distance(p, w);
                if (Vec2.Distance(w, p) < 1f || Vec2.Distance(w, arena.Clamp(to, clearance)) < 1f)
                {
                    return total;
                }

                p = w;
            }

            return total + Vec2.Distance(p, to);
        }

        public static bool Visible(Vec2 a, Vec2 b, Box[] inflated)
        {
            for (int i = 0; i < inflated.Length; i++)
            {
                if (inflated[i].IntersectsSegment(a, b)) return false;
            }

            return true;
        }

        public static Box[] InflateAll(Box[] obstacles, float clearance)
        {
            Box[] result = new Box[obstacles.Length];
            for (int i = 0; i < obstacles.Length; i++)
            {
                result[i] = obstacles[i].Inflate(clearance);
            }

            return result;
        }

        private static float CostToGoal(int index, Vec2[] corners, Vec2 to, Box[] inflated, Arena arena, float clearance)
        {
            Vec2 c = corners[index];
            if (Visible(c, to, inflated))
            {
                return Vec2.Distance(c, to);
            }

            float best = float.MaxValue;
            for (int j = 0; j < corners.Length; j++)
            {
                if (j == index || !arena.Inside(corners[j], clearance)) continue;
                if (Visible(c, corners[j], inflated) && Visible(corners[j], to, inflated))
                {
                    best = Math.Min(best, Vec2.Distance(c, corners[j]) + Vec2.Distance(corners[j], to));
                }
            }

            return best == float.MaxValue ? Vec2.Distance(c, to) + UnreachablePenalty : best;
        }

        private static int NearestBlocker(Vec2 from, Vec2 to, Box[] inflated)
        {
            int best = -1;
            float bestDist = float.MaxValue;
            for (int i = 0; i < inflated.Length; i++)
            {
                if (!inflated[i].IntersectsSegment(from, to)) continue;
                float d = inflated[i].DistanceTo(from);
                if (d < bestDist)
                {
                    bestDist = d;
                    best = i;
                }
            }

            return best;
        }

        // 把与 seed 相连（重叠或贴边）的膨胀障碍合并成一个外接盒。
        private static Box Cluster(Box[] inflated, int seed)
        {
            Box cluster = inflated[seed];
            bool[] used = new bool[inflated.Length];
            used[seed] = true;
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i < inflated.Length; i++)
                {
                    if (used[i] || !cluster.Inflate(1f).Overlaps(inflated[i])) continue;
                    Box o = inflated[i];
                    cluster = Box.FromBounds(
                        Math.Min(cluster.MinX, o.MinX), Math.Max(cluster.MaxX, o.MaxX),
                        Math.Min(cluster.MinZ, o.MinZ), Math.Max(cluster.MaxZ, o.MaxZ));
                    used[i] = true;
                    changed = true;
                }
            }

            return cluster;
        }

        // 沿穿透最浅的方向推出盒子。
        private static Vec2 PushOut(Box box, Vec2 p)
        {
            float toLeft = p.X - box.MinX;
            float toRight = box.MaxX - p.X;
            float toTop = p.Z - box.MinZ;
            float toBottom = box.MaxZ - p.Z;
            float min = Math.Min(Math.Min(toLeft, toRight), Math.Min(toTop, toBottom));

            if (min == toLeft) return new Vec2(box.MinX - EscapeSlack, p.Z);
            if (min == toRight) return new Vec2(box.MaxX + EscapeSlack, p.Z);
            if (min == toTop) return new Vec2(p.X, box.MinZ - EscapeSlack);
            return new Vec2(p.X, box.MaxZ + EscapeSlack);
        }
    }

    // 目标选择：进攻时在未被捕的躲避手中挑一条。
    internal static class TargetSelector
    {
        public static int Pick(Vec2 hunter, Vec2 defender, Vec2[] preys, bool[] caught, int currentTarget,
            Box[] obstacles, Arena arena, float clearance)
        {
            int best = -1;
            float bestScore = float.MaxValue;
            for (int i = 0; i < preys.Length; i++)
            {
                if (caught[i]) continue;

                float score = Score(hunter, defender, preys[i], obstacles, arena, clearance);
                if (i == currentTarget)
                {
                    score -= StickyBonus;
                }

                if (score < bestScore)
                {
                    bestScore = score;
                    best = i;
                }
            }

            return best;
        }

        private const float StickyBonus = 250f;
        private const float ShieldRadius = 260f;
        private const float ShieldPenalty = 900f;
        private const float GuardRadius = 600f;
        private const float EdgeRadius = 500f;

        // 分数越小越好：实际路程 + 被防御手遮挡/贴身保护的代价 − 贴墙易围堵的收益。
        public static float Score(Vec2 hunter, Vec2 defender, Vec2 prey, Box[] obstacles, Arena arena, float clearance)
        {
            float score = Navigator.EstimatePathLength(hunter, prey, obstacles, arena, clearance);

            float shieldDist = DistanceToSegment(defender, hunter, prey);
            if (shieldDist < ShieldRadius && ProjectionT(defender, hunter, prey) > 0.1f)
            {
                score += ShieldPenalty * (1f - shieldDist / ShieldRadius);
            }

            float guardDist = Vec2.Distance(defender, prey);
            if (guardDist < GuardRadius)
            {
                score += 0.8f * (GuardRadius - guardDist);
            }

            float edge = arena.DistanceToEdge(prey);
            if (edge < EdgeRadius)
            {
                score -= 0.8f * (EdgeRadius - edge);
            }

            return score;
        }

        private static float ProjectionT(Vec2 p, Vec2 a, Vec2 b)
        {
            Vec2 ab = b - a;
            float len2 = ab.X * ab.X + ab.Z * ab.Z;
            if (len2 < 1e-4f) return 0f;
            return ((p.X - a.X) * ab.X + (p.Z - a.Z) * ab.Z) / len2;
        }

        public static float DistanceToSegment(Vec2 p, Vec2 a, Vec2 b)
        {
            float t = Math.Max(0f, Math.Min(1f, ProjectionT(p, a, b)));
            return Vec2.Distance(p, a + (b - a) * t);
        }
    }

    // 躲避点：防守时躲避手的下一个目标点。
    internal static class DodgePlanner
    {
        public static Vec2 Plan(Vec2 fish, Vec2 home, Vec2 attacker, Vec2 attackerVelocity,
            Box[] obstacles, Arena arena, float clearance)
        {
            Vec2 threat = attacker + attackerVelocity * LeadSeconds;
            float threatDist = Vec2.Distance(fish, threat);
            if (threatDist > DangerRange)
            {
                return arena.Clamp(home, clearance);
            }

            Box[] inflated = Navigator.InflateAll(obstacles, clearance);
            Vec2 best = arena.Clamp(fish + (fish - threat).Normalized * StepRadius, clearance);
            float bestScore = float.MinValue;
            for (int i = 0; i < Directions; i++)
            {
                double angle = 2.0 * Math.PI * i / Directions;
                Vec2 c = arena.Clamp(fish + new Vec2((float)Math.Cos(angle), (float)Math.Sin(angle)) * StepRadius, clearance);
                if (!Navigator.Visible(fish, c, inflated) || InsideAny(c, inflated))
                {
                    continue;
                }

                float score = Vec2.Distance(c, threat);

                // 墙边和角落是死路。
                float edge = arena.DistanceToEdge(c);
                if (edge < WallRange)
                {
                    score -= 1.2f * (WallRange - edge);
                }

                // 路线不能从捉捕手身边擦过。
                float pass = TargetSelector.DistanceToSegment(threat, fish, c);
                if (pass < threatDist)
                {
                    score -= 2f * (threatDist - pass);
                }

                score -= HomeWeight * Vec2.Distance(c, home);

                if (score > bestScore)
                {
                    bestScore = score;
                    best = c;
                }
            }

            return best;
        }

        private const float LeadSeconds = 0.4f;
        private const float DangerRange = 900f;
        private const float StepRadius = 500f;
        private const int Directions = 16;
        private const float WallRange = 600f;
        private const float HomeWeight = 0.15f;

        private static bool InsideAny(Vec2 p, Box[] inflated)
        {
            for (int i = 0; i < inflated.Length; i++)
            {
                if (inflated[i].Contains(p)) return true;
            }

            return false;
        }
    }
}
