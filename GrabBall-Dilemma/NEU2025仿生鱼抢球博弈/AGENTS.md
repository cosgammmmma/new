# AGENTS.md

> `agent.md` is the requested filename for the same rules. Keep `AGENTS.md` and `agent.md` identical so both project tooling and team members read one stable rule set.

## Scope

These rules apply to the entire `D:\仿生机器人` workspace. They describe stable project constraints only. Do not add temporary tasks, current scores, short-lived dates, one-off requests, copied third-party manuals, or completion status to this file.

## Source Of Truth

- Treat `01_当前主线/StrategyNew2V2` as the strategy mainline unless the user explicitly selects a historical source tree.
- Treat `01_当前主线/StrategyNew2V2` as the main 2D ball-scrimmage project.
- Training and other competition projects are intentionally not included in this standalone archive.
- Treat `Backup`, `bin`, `obj`, `.vs`, `StrategyCache`, `改代码`, decompiled sources, and timestamped DLLs as generated, historical, or reference material. Never select them as the edit target merely because they contain a newer-looking filename.
- Before editing duplicate files, state the chosen source-of-truth path and verify that the build uses it.

## Technology And Build Constraints

- Language: C# using legacy MSBuild project files.
- Target framework: .NET Framework 3.5.
- Target platform: x86.
- Strategy output type: class library DLL.
- Core dependencies: `Microsoft.Xna.Framework`, `URWPGSim2D.Common`, and `URWPGSim2D.StrategyLoader`; some template projects also reference `Microsoft.Dss.Base` and `URWPGSim2D.StrategyHelper`.
- Do not upgrade the framework, convert projects to SDK style, change platform target, or replace platform DLLs without an explicit compatibility task and simulator load test.
- Do not modify simulator physics, match rules, or platform binaries to improve strategy results.

## Stable Commands

Run builds from a Visual Studio Developer PowerShell/Command Prompt when `MSBuild.exe` is not on `PATH`.

```powershell
# Main strategy, Debug
msbuild ".\01_当前主线\StrategyNew2V2\StrategyNew2V2.csproj" /t:Rebuild /p:Configuration=Debug /p:Platform=x86

# Main strategy, Release
msbuild ".\01_当前主线\StrategyNew2V2\StrategyNew2V2.csproj" /t:Rebuild /p:Configuration=Release /p:Platform=x86

# Record a release artifact hash
Get-FileHash ".\01_当前主线\StrategyNew2V2\bin\Release\GrabBall Dilemma.dll" -Algorithm SHA256
```

Do not compile while the simulator has the same DLL loaded. Close the simulator first, rebuild, then confirm the output timestamp, team name, and SHA-256 before testing.

## Runtime Contract

- Strategy classes implement `IStrategy` and inherit `MarshalByRefObject`.
- Preserve `InitializeLifetimeService()` returning `null` unless the platform contract is intentionally being changed.
- `GetDecision(Mission mission, int teamId)` is called every simulation cycle and must return one initialized `Decision` per fish.
- Keep every `VCode` and `TCode` in the inclusive range 0-14. `TCode == 7` means straight movement.
- The field uses X/Z coordinates in millimetres: positive X is right and positive Z is down.
- State whether new logic operates on raw coordinates or on the normalized left-side view after `RightToLeft()`.
- Account for both `teamId` values and the halftime side swap.

## Code Ownership

- `Strategy.cs`: cycle orchestration, input normalization, score/phase analysis, tactic priority, task assignment, final output.
- `BaseAction.cs`: ball selection, positioning, dribbling, scoring, boundary recovery, opponent avoidance, stalemate actions.
- `GlobalVar.cs`: shared constants and cross-cycle state. Every added state variable must have a documented initialization and reset path.
- `Compute.cs`: reusable geometry, distance, and angle calculations.
- `DebugRecord.cs`: diagnostic events. Keep high-frequency logging gated or throttled.
- `Integration_Example.cs` is an example and is not currently compiled by `StrategyNew2V2.csproj`; production behavior must be integrated into compiled files and verified.

## C# Style

- Stay compatible with C# and libraries available to .NET Framework 3.5. Do not use modern language/runtime APIs without confirming compiler support.
- Use 4 spaces for new indentation and braces on their own lines. Match nearby style inside legacy blocks when a broad reformat would obscure the behavioral change.
- Use descriptive English identifiers for new code. Preserve public/platform-required names and avoid renaming large legacy surfaces during tactical work.
- Extract a helper only when it isolates a coherent calculation or state transition. Do not create abstractions that require rewriting unrelated legacy code.
- Replace newly introduced magic numbers with named constants grouped by domain: field geometry, timing, scoring, motion, or state-machine thresholds.
- Use radians consistently for platform angles. Include the unit in names when ambiguity is possible.
- Comments explain why a threshold, transition, or fallback exists. Do not narrate obvious assignments.
- Do not add profanity, personal remarks, meaningless debug labels, or commented-out experimental blocks.

## Strategy Change Rules

- Treat opponent DLLs as black-box test fixtures. Do not decompile, reconstruct, copy, or submit an opponent implementation. Tactical ideas may be inferred from official rules and observable match behavior only, then implemented independently in the mainline. The submitted strategy and report must satisfy the competition's originality and intellectual-property requirements.
- Make one behavioral hypothesis per change. Record the target scenario and expected metric before editing.
- Preserve the priority order in `Strategy.GetDecision`; inserting an early `return` is a global behavior change and requires broad regression testing.
- Every state machine must define entry, active, exit, timeout, and reset behavior.
- Every target-ball selection must handle invalid IDs, scored balls, teammate conflicts, and target loss.
- Defensive array access must respect actual fish and ball counts; do not assume indices without validating the mission type.
- A feature is not complete because code or an example exists. It is complete only after the compiled DLL triggers it in simulator logs and exits the state correctly.

## Testing Rules

- Minimum smoke test after any strategy edit: build Debug and Release, load the DLL, verify team name/version, run once as each side, and check decision ranges and exceptions.
- Changes to coordinate transforms, score state, match phase, target selection, global state, or early-return priority require a full-match test through halftime on both sides.
- Changes in `BaseAction.cs` require focused tests for the touched action plus regression for corners, boundaries, goal area, opponent blocking, and no-target fallback when applicable.
- Compare against a frozen `NEU222.dll` identified by SHA-256. Never rely on a timestamped cache filename alone.
- Alternate left/right assignments. Report wins, draws, losses, average score margin, side-specific results, crashes, stalls, and invalid outputs.
- Repeated deterministic matches with an identical initial state are not independent evidence. Use side swaps and any officially supported initial-state variation.
- Do not claim improvement from a single match. Keep the previous passing DLL available for immediate rollback.

## Known Traps

- Multiple near-duplicate strategy trees can compile different code than the file being edited.
- Simulator `StrategyCache` creates many timestamped DLL copies and can make stale-code tests look current.
- The simulator may lock loaded DLLs; close it before rebuilding.
- A successful compile does not prove the DLL will load under the simulator's x86/.NET/XNA runtime.
- Static `GlobalVar` fields can leak state between matches or after hot strategy replacement.
- Historical documents disagree on some region boundaries and timing conversions. Cross-check current code against official match rules and observable simulator behavior.
- Ball score-state keys are string based; a typo compiles but fails at runtime.
- The workspace may contain cloud/cache placeholder executables such as `._cache_URWPGSim2DServer.exe`. Do not rename or execute them as if they were the real simulator.
- `BaseAction.cs` is very large. Avoid broad formatting, line-ending, or encoding churn.

## Documentation

- Keep architecture and stable workflow in Markdown. Keep experiment results and current performance in separate test records.
- Use `04_规则与项目文档/项目工作与测试分阶段执行计划.md` as the checkbox workflow.
- Follow `Word文档书写规则.md` for formal reports.
- When code behavior changes, update only the relevant maintained design/test documentation. Do not edit completed third-party manuals or historical competition submissions.
