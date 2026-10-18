# NEU222pro 对手冻结与命名变更记录

## 新对手基线

- 原始文件：`D:/仿生机器人/NEU222pro.dll`
- 冻结文件：`NEU222pro基线/冻结产物/NEU222pro.dll`
- 文件大小：204800 bytes
- SHA-256：`06ABB28B771C05485264507ED0C593DDF6BD511C2999DDD45F36E37B9FC603D5`
- 用途：后续抢球博弈的新对标程序；不得用旧 `NEU222.dll` 的比赛结果替代本对手的基线或资格测试。

## 主线命名变更

- 主线仍为 `2024-RST-水中机器人仿真组（2D）11.12/2D仿真平台/URWPGSim2D/Strategy666/StrategyNew2V2`。
- `Strategy.GetTeamName()`：`NEU666` 改为 `牢龚888`，控制仿真计分牌队名。
- `StrategyNew2V2.csproj` 的 `AssemblyName`：`StrategyNew2V2` 改为 `牢龚888`，控制新构建的策略 DLL 文件名和程序集名。
- 工程目录、项目文件名、根命名空间和战术代码未重命名；这样不破坏旧式项目引用，也不影响已冻结的阶段 9 提交包。

## 构建结果

- Debug|x86：`bin/Debug/牢龚888.dll`，211968 bytes，SHA-256 `3014554826BC6094E78CA31B9DC236DD65CAC8C6AA1418B219C9DDE46D70A1BE`。
- Release|x86：`bin/Release/牢龚888.dll`，181760 bytes，SHA-256 `5CB0F618FB215A0F50084312B1519C7B9B24AFD297884E6BDBC5A1B8F6A30CD2`。
- Release 程序集名、程序集标题和产品名均为 `牢龚888`；处理器架构：x86；CLR：`v2.0.50727`；目标框架仍为 `.NET Framework 3.5`。
- 构建结果：0 个错误；7 个既有遗留警告。

## 平台加载烟测

- 对局：`PRO-NAME-FINAL-L`，1 分钟，仅用于加载/命名验证，不用于判断新对手强弱。
- 加载：我方 `牢龚888.dll` SHA-256 `5CB0F618FB215A0F50084312B1519C7B9B24AFD297884E6BDBC5A1B8F6A30CD2`；对手 `NEU222pro.dll` SHA-256 `06ABB28B771C05485264507ED0C593DDF6BD511C2999DDD45F36E37B9FC603D5`。
- 结果：两份 DLL 均成功加载，完成半场交换并正常终场，比分 `0:0`；终场计分牌我方显示 `牢龚888`。
- 证据：`阶段3基线/对局证据/PRO-NAME-FINAL-L_half.JPG`，SHA-256 `0CF0A12FCB101EE3B68049D7AA56458A09F8C660412C2AE93940EC16221EAB87`；`PRO-NAME-FINAL-L_final.JPG`，SHA-256 `402B8078BF0E744D74996EB656394A0BC68885A2A9F9BA8D58B579D706601B9D`。
- 截图另一侧显示的 `NEU666` 来自 `NEU222pro.dll` 自己的 `GetTeamName()`，不属于我方残留命名。

## 隔离说明

- 已冻结的 `阶段9发布/正式提交包_20260731` 及其中 SHA-256 为 `99CC14953B01F070A50867B51393BC6CC4BD5FE153693F62269070587E2BF331` 的旧提交 DLL 未修改。
- 后续面对 `NEU222pro.dll` 的所有策略调整只在主线继续，不能把阶段 9 旧包覆盖成同名新版本。
