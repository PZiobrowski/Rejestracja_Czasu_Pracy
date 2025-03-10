$projectPath = Join-Path $PSScriptRoot "RCP"

if (Test-Path $projectPath) {
    Set-Location $projectPath

    # Uruchom aplikację .NET
    Write-Host "Run..."
    dotnet run
} else {
}