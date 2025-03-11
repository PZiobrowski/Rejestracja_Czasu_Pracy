# Uruchomienie aktualizacji bazy danych

try {
        cd RCP

        dotnet tool install --global dotnet-ef

        Write-Host "Tworzenie migracji EF Core..."

        dotnet ef migrations add Initial

        Write-Host "Aktualizowanie bazy danych w oparciu o migracje EF Core..."

        dotnet ef database update

    Write-Host "Aktualizacja zakonczona pomyslnie!"
} catch {
    Write-Host "Wystapil blad podczas aktualizacji bazy danych:"
    Write-Host $_.Exception.Message
    exit 1
}
