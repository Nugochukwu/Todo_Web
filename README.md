h# Todo_Web
## <Requirements / Downloads Required> 
1 .NetCore

## Set Up
dotnet tool restore
dotnet restore
dotnet tool run dotnet-ef database update

## Running the App
dotnet run

## Development
  ##To add a new migration
dotnet tool run dotnet-ef migrations add <MigrationName>
  ##To update the database:
dotnet tool run dotnet-ef database update
