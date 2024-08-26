## Todo_Web
 The project entails a simple web app that functions as a to-do list, one that integrates simple CRUD operations
## Requirements / Downloads Required
1 .NetCore/.NET SDK
Microsoft.AspNetCore.Mvc
Microsoft.EntityFrameworkCore (using Entity Framework Core for database operations)
Microsoft.AspNetCore.Razor (for Razor views)
Microsoft.AspNetCore.Http
Microsoft.EntityFrameworkCore.Sqlite
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
## Problem
Web app is unable to load the web view for the todo list and is giving this error
```bash
InvalidOperationException: Unable to resolve service for type 'AspNetCoreTodo.Services.ITodoItemService' while attempting to activate 'AspNetCoreTodo.Controllers.TodoController'.
```
