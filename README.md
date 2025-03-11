
# Rejestracja czasu pracy

Aplikacja webowa służąca do rejestracji czasu pracy zdalnej.




## Wymagania

 - [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
 - [SQL Server 2022](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)


## Konfiguracja 

#### appsettings.json


| Klucz | Type     | Opis                |
| :-------- | :------- | :------------------------- |
| `ConnectionStrings:DateBaseConnection` | `string` | Connection string do bazy danych |
| `Port` | `int` | Port aplikacji |

#### config.json


| Klucz | Type     | Opis                |
| :-------- | :------- | :------------------------- |
| `serverPort` | `int` | Port servera |




## Konfiguracja bazy danych

Należy utworzyć bazę danych. Następnie uruchomić skrypt UpdateDatabase.ps1, a ostatecznie na bazie należy uruchomić skrypt AddUser.sql

## Uruchamianie

#### API

```bash
  uruchomienie skryptu Run.ps1
```

#### UI

```bash
  uruchomienie pliku index.html
```

