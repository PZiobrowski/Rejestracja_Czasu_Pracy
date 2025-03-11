$projectPath = Join-Path $PSScriptRoot "RCP"

if (Test-Path $projectPath) {
    Set-Location $projectPath

    # Uruchom aplikację .NET
    Write-Host "Uruchamianie..."
    dotnet run
} else {
    Write-Host "Nie znaleziono projektu"
}