## Todo_Web
## Requirements / Downloads Required
1 .NetCore

## Set Up
```bash
dotnet tool restore
dotnet restore
dotnet tool run dotnet-ef database update
```
## Running the App
```bash
 dotnet run
```
## Development:
  ## 1. To add a new migration
  ```bash
 dotnet tool run dotnet-ef migrations add <MigrationName>
 ```
  ## 2. To update the database:
 ```bash
 dotnet tool run dotnet-ef database update
```
