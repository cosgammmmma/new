// 这是一个示例文件，展示如何在 Dribblehometest1 方法中集成避障逻辑
// 不要直接运行此文件，而是参考其中的代码片段

// ============================================
// 集成位置：Dribblehometest1 方法中
// ============================================

// 找到原代码中判断球在中场的部分（大约在 num > -1300 的判断）
// 原代码类似：
/*
bool flag30 = num > -1300.0;
if (flag30) {
    this.Dribble(whichfish, whichball, num, (double)(num8 * 1000));
}
*/

// 修改为以下代码：
bool flag30 = num > -1300.0;
if (flag30) {
    // ========== 新增：避障检测 ==========
    int blockingOppId;
    double detourAngle;
    bool isBlocked = this.IsOpponentBlocking(whichfish, whichball, out blockingOppId, out detourAngle);
    
    // 如果检测到对手阻挡且当前不在绕行状态
    if (isBlocked && GlobalVar.detour_stage[whichfish] == 0) {
        GlobalVar.detour_stage[whichfish] = 1;
        GlobalVar.detour_target_opp[whichfish] = blockingOppId;
        DebugRecord.ceshi(0, "检测到对手阻挡，开始绕行", (float)blockingOppId);
    }
    
    // 如果正在绕行
    if (GlobalVar.detour_stage[whichfish] == 1) {
        // 执行绕行动作
        this.DetourAroundOpponent(whichfish, whichball, GlobalVar.detour_target_opp[whichfish], detourAngle);
        
        // 检查是否完成绕行（已经接近球）
        double myFishX = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
        double myFishZ = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
        double ballX = (double)GlobalVar.balls[whichball].PositionMm.X;
        double ballZ = (double)GlobalVar.balls[whichball].PositionMm.Z;
        double distToBall = Compute.GetDistance(myFishX, myFishZ, ballX, ballZ);
        
        if (distToBall < 150.0) {
            // 已经接近球，结束绕行，恢复正常状态
            GlobalVar.detour_stage[whichfish] = 0;
            DebugRecord.ceshi(0, "绕行完成，恢复正常带球");
        }
    }
    else {
        // 正常带球逻辑（原代码）
        this.Dribble(whichfish, whichball, num, (double)(num8 * 1000));
    }
    // ========== 避障检测结束 ==========
}

// ============================================
// 可选：在其他位置也可以添加避障检测
// ============================================

// 例如在边界运球之前也可以检测：
/*
bool flag_at_boundary = num2 * (double)num8 > 500.0;
if (flag_at_boundary) {
    // 先检测是否有对手阻挡
    int blockingOppId;
    double detourAngle;
    bool isBlocked = this.IsOpponentBlocking(whichfish, whichball, out blockingOppId, out detourAngle);
    
    if (isBlocked) {
        // 绕行优先于边界运球
        this.DetourAroundOpponent(whichfish, whichball, blockingOppId, detourAngle);
    }
    else {
        // 正常边界运球
        this.Dribbleboundary(whichfish, whichball);
    }
}
*/

// ============================================
// 初始化：在 GlobalVar.Init() 中添加
// ============================================

// 在 GlobalVar.cs 的 Init() 方法中添加：
/*
public static void Init()
{
    // ... 原有的初始化代码 ...
    
    // 新增：初始化避障状态
    detour_stage[0] = 0;
    detour_stage[1] = 0;
    detour_target_opp[0] = -1;
    detour_target_opp[1] = -1;
}
*/
