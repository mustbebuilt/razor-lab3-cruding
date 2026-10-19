# Lab 2 Tutorial Documentation: Data & Databases in Razor Pages

This directory contains the documentation and tutorial guides for **Lab 2: Data & Databases in ASP.NET Core Razor Pages**. These files also form the basis of the [GitHub Wiki](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki).

## Tutorial Modules

1. **[06. SQLite Database Integration](06-db-connection-sqlite.md)**:
   - Setting up SQLite (`Data/staff.db`) and Entity Framework Core
   - Creating the `Staff` model and `ApplicationDbContext`
   - Dependency Injection in `Program.cs` and `Pages/Staff/Index.cshtml.cs`
   - Rendering the staff directory table

2. **[07. MSSQL Database Integration (Alternative)](07-db-connection-mssql.md)**:
   - Connecting to Microsoft SQL Server / Azure SQL / Docker
   - Using `Microsoft.EntityFrameworkCore.SqlServer`
   - Working with EF Core Migrations (`dotnet ef migrations add` & `dotnet ef database update`)

3. **[08. Route Parameters & Staff Details](08-data-routing.md)**:
   - Generating links with `asp-route-id`
   - Defining route templates with `@page "{id:int}"`
   - Retrieving single records with `_context.Staff.FindAsync(id)`

4. **[08a. Searching Data](08a-searching-the-data.md)**:
   - GET form model binding with `[BindProperty(SupportsGet = true)]`
   - Constructing dynamic queries with deferred execution (`IQueryable<Staff>`)
   - Case-insensitive LINQ search filtering

5. **[08b. HTTP Methods & Routing](08b-http-methods-and-routing.md)**:
   - Deep-dive into HTTP GET query strings, route parameters, multi-segment routes
   - HTTP POST with form validation and the **Post-Redirect-Get (PRG)** pattern
   - Flash messages with `[TempData]`
