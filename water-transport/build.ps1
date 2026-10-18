param([switch]$Test, [int]$ReloadCycle = -1)
$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$platform = [IO.Path]::GetFullPath((Join-Path $root '..\..\URWPGSim2D\bin'))
$framework = Join-Path $env:WINDIR 'Microsoft.NET\Framework\v3.5'
$common = [IO.Path]::GetFullPath((Join-Path $root '..\..\Common\obj\Release\URWPGSim2D.Common.dll'))
$loader = [IO.Path]::GetFullPath((Join-Path $root '..\..\StrategyLoader\obj\Release\URWPGSim2D.StrategyLoader.dll'))
foreach ($required in @($common, $loader)) {
    if (-not (Test-Path $required)) { throw "Missing platform project assembly: $required" }
}
& (Join-Path $framework 'MSBuild.exe') (Join-Path $root 'StrategyWaterTransport.csproj') /t:Rebuild /p:Configuration=Release /nologo /verbosity:minimal
if ($LASTEXITCODE -ne 0) { throw 'Strategy build failed' }
$dll = Join-Path $root 'bin\Release\StrategyWaterTransport.dll'
Write-Host "DLL: $dll"
if ($Test) {
    $out = Join-Path $root 'Tests\out'
    New-Item -ItemType Directory -Force $out | Out-Null
    # The platform bin currently lacks these two assemblies; use the matching project build outputs.
    Get-ChildItem $platform -Filter '*.dll' | Copy-Item -Destination $out
    Copy-Item $common $out
    Copy-Item $loader $out
    Copy-Item (Join-Path $platform 'config.xml') $out
    Copy-Item $dll $out
    $refs = @('URWPGSim2D.Common', 'URWPGSim2D.Match', 'URWPGSim2D.StrategyLoader', 'Microsoft.Xna.Framework', 'Microsoft.Dss.Base')
    $compilerArgs = @('/nologo', '/target:exe', '/platform:x86', '/optimize+', "/out:$out\Harness.exe")
    foreach ($name in $refs) { $compilerArgs += "/reference:$out\$name.dll" }
    $compilerArgs += (Join-Path $root 'Tests\Harness.cs')
    & (Join-Path $framework 'csc.exe') $compilerArgs
    if ($LASTEXITCODE -ne 0) { throw 'Harness build failed' }
    $log = Join-Path $out ("run-reload-{0}.log" -f $ReloadCycle)
    $process = Start-Process -FilePath (Join-Path $out 'Harness.exe') -ArgumentList "$ReloadCycle" -WorkingDirectory $out -Wait -PassThru -NoNewWindow -RedirectStandardOutput $log -RedirectStandardError (Join-Path $out 'error.log')
    Get-Content $log | Select-String 'Platform:|Field:|Loaded:|PASS |RELOAD|SCORE |RESULT '
    Get-Content (Join-Path $out 'error.log') -ErrorAction SilentlyContinue
    if ($process.ExitCode -ne 0) { throw "Harness exit code $($process.ExitCode); see $log" }
}
