param([switch]$Test)
$ErrorActionPreference = 'Stop'
$projectDir = $PSScriptRoot
$compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'
if (!(Test-Path -LiteralPath $compiler)) { throw 'The Windows .NET Framework C# compiler is required.' }
$outputDir = Join-Path $projectDir 'dist'
New-Item -ItemType Directory -Path $outputDir -Force | Out-Null
$common = @('/nologo', '/optimize+', '/warn:4', '/reference:System.dll', '/reference:System.Core.dll', '/reference:System.Net.Http.dll', '/reference:System.Web.Extensions.dll')
$sources = @(Get-ChildItem -LiteralPath (Join-Path $projectDir 'src') -Filter '*.cs' | ForEach-Object { $_.FullName })
$executable = Join-Path $outputDir 'GTrader.PriceExplorer.exe'
& $compiler @common '/target:winexe' '/reference:System.Windows.Forms.dll' '/reference:System.Drawing.dll' "/win32manifest:$projectDir\src\app.manifest" "/win32icon:$projectDir\assets\app.ico" "/out:$executable" "/resource:$projectDir\nasdaq_nyse_innovation_over_1b.txt,GTrader.Symbols" "/resource:$projectDir\data\companies.json,GTrader.Companies" @sources
if ($LASTEXITCODE -ne 0) { throw 'Application compilation failed.' }
Copy-Item -LiteralPath (Join-Path $projectDir 'src\app.config') -Destination ($executable + '.config') -Force
Copy-Item -LiteralPath (Join-Path $projectDir 'nasdaq_nyse_innovation_over_1b.txt') -Destination $outputDir -Force
Copy-Item -LiteralPath (Join-Path $projectDir 'nasdaq_nyse_innovation_over_1b.sources.md') -Destination $outputDir -Force
Copy-Item -LiteralPath (Join-Path $projectDir 'data\companies.json') -Destination $outputDir -Force
Copy-Item -LiteralPath (Join-Path $projectDir 'README.md') -Destination $outputDir -Force
Write-Output "Compiled $executable"
if ($Test) {
    $testExecutable = Join-Path $projectDir 'tests\GTrader.Tests.exe'
    & $compiler @common '/target:exe' "/out:$testExecutable" (Join-Path $projectDir 'src\Models.cs') (Join-Path $projectDir 'src\StockRepository.cs') (Join-Path $projectDir 'src\PriceHistoryService.cs') (Join-Path $projectDir 'tests\Tests.cs')
    if ($LASTEXITCODE -ne 0) { throw 'Test compilation failed.' }
    & $testExecutable
    if ($LASTEXITCODE -ne 0) { throw 'Tests failed.' }
}
