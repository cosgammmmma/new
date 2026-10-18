# NEU2025 仿生鱼抢球博弈

这是适合通过 GitHub 网页直接上传的精简项目包，共 98 个文件。完整的原始归档另行保存在同级目录中。

## 目录说明

- `01_当前主线`：当前完整策略源码、依赖说明和最终交付 DLL。
- `02_关键迭代记录`：迭代 01—54 的连续设计、测试与回退记录。
- `03_关键源码快照`：迭代 35、47、53、54 的源码快照。
- `04_关键冻结DLL`：阶段 0、3、5、6、7 的代表性自研 DLL。
- `04_规则与项目文档`：比赛规则、坐标接口、架构和工作流。
- `05_阶段测试与发布记录`：阶段 0—9 的核心测试、发布与哈希记录。
- `SHA256SUMS.csv`：除清单自身外，仓库内所有文件的 SHA-256。

## 当前版本

主项目：

`01_当前主线/StrategyNew2V2/StrategyNew2V2.csproj`

最终 DLL：

`01_当前主线/交付/GrabBall Dilemma.dll`

技术约束：.NET Framework 3.5、x86、传统 MSBuild 类库。

## 构建

```powershell
msbuild ".\01_当前主线\StrategyNew2V2\StrategyNew2V2.csproj" /t:Rebuild /p:Configuration=Release /p:Platform=x86
```

项目仍依赖原 URWPGSim2D 平台中的 `Common`、`StrategyLoader`、XNA 和 Microsoft Robotics Developer Studio 组件。具体见 `01_当前主线/依赖说明.md`。

## 精简原则

保留能够说明当前实现、关键战术演进和验证结论的材料。重复候选 DLL、逐局截图、超大诊断日志、GUI 调试图片及重复发布包未放入 GitHub 精简版，仍可在完整归档中找回。

未收录反编译派生物和黑盒对手 DLL。正式公开仓库前，请确认比赛规则 PDF 及平台接口材料的公开授权。

