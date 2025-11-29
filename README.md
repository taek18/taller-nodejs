# ToDoApp (macOS - SQLite) with Identity UI

This project is ready to run on macOS with .NET 7 and SQLite. It includes Identity UI package so you can use the default login/register pages via MapRazorPages.

## Quick start

1. Unzip the project.
2. Open a terminal and go to the project folder.
3. Run:
   ```
   dotnet restore
   dotnet tool install --global dotnet-ef --version 7.0.14
   dotnet ef migrations add Initial
   dotnet ef database update
   dotnet run
   ```
4. Open https://localhost:5001 and register a user at /Identity/Account/Register

