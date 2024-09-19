## Todo_Web
 The project entails a simple web app that functions as a to-do list, one that integrates simple CRUD operations
## Requirements / Downloads Required
1. .NET SDK - Required for building and running the application.
2. Microsoft.AspNetCore.Mvc - For MVC functionalities.
3. Microsoft.EntityFrameworkCore - For database operations using Entity Framework Core.
4. Microsoft.AspNetCore.Razor - For Razor views.
5. Microsoft.AspNetCore.Http - For handling HTTP requests.
6. Microsoft.EntityFrameworkCore.Sqlite - For SQLite database support.
```bash
#Version
8.0.303
```
## Set Up
```bash
dotnet tool restore
dotnet restore
dotnet tool run dotnet-ef database update
```
## Running the App
```bash
 dotnet build
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
