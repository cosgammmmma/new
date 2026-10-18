# 仿真水中搬运策略

依据根目录 `A07-智慧海洋赛道-水中机器人仿真组比赛规则及评审（裁判）说明.pdf` 第 10-11 页科目二：
标准场地 3000 x 2000 mm、单队两条鱼、6 个编号球分别进入同编号地标，每球只计 1 分，
10 分钟结束；每次得分由裁判确认并继续比赛，比赛中最多可申请更换策略 2 次。

平台实现是 `Match/Match1V1Moving.cs`，并非名称相近的 `MatchTransfer.cs`（后者是生存挑战）。
其六个目标中心依次是 `(0,0)`、`(-240,-160)`、`(-240,160)`、
`(-480,-320)`、`(-480,0)`、`(-480,320)`，括号内为 X、Z 坐标（mm）。
**实际计分要求球心与目标中心距离严格小于 22 mm**，比规则地标半径 80 mm 严格。
策略使用 `Ball0InHole` 到 `Ball5InHole` 标志追踪真正得分，重载后可以接续。

## 构建及测试

在 PowerShell 中运行：

```powershell
& "2D仿真平台/URWPGSim2D/Strategy/StrategyWaterTransport/build.ps1"
& "2D仿真平台/URWPGSim2D/Strategy/StrategyWaterTransport/build.ps1" -Test
& "2D仿真平台/URWPGSim2D/Strategy/StrategyWaterTransport/build.ps1" -Test -ReloadCycle 3000
```

编译输出：`bin/Release/StrategyWaterTransport.dll`，.NET Framework 3.5 x86。
选择服务端的“水中搬运”项目并加载该 DLL；策略入口为
`URWPGSim2D.Strategy.Strategy : IStrategy`，加载后队名是 `WaterTransport`。
测试在 `Tests/out/` 使用真实平台 `Match1V1Moving` 的运动、碰撞和判分逻辑，
检查错误队伍、满分、到时、编号与 22 mm 边界。测试退出码 2 表示比赛未得满分，
但 DLL 已构建且测试执行完成；完整日志在 `Tests/out/run-reload-*.log`。

目前平台 `URWPGSim2D/bin` 中缺少 `URWPGSim2D.Common.dll` 和
`URWPGSim2D.StrategyLoader.dll`；应先确认平台运行时自身能找到这两个依赖。
依用户要求，本项目构建和测试只使用 `Common/obj/Release` 与
`StrategyLoader/obj/Release` 中已有且与测试副本哈希相同的文件，**不修改平台 bin**。

## 当前实测

2026-09-30：10 分钟模拟，最多观测到 **5/6** 的平台实际得分；
在第 3000 周期重新加载策略后，一次完整测试仍得到 **5/6**，第 5 分发生于
519.5 秒。**6/6 尚未验证**，尤其靠近目标后可能偏离严格的 22 mm 得分圈；
不能将球移动距离或 DLL 编译成功视作满分。测试日志保留各球每 100 周期坐标，
可用于继续修正末段推球。
