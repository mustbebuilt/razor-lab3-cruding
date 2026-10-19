# Lab 2 Tutorial Documentation: Data & Databases in Razor Pages

This directory contains the documentation and tutorial guides for **Lab 2: Data & Databases in ASP.NET Core Razor Pages**. These files also form the basis of the [GitHub Wiki](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki).

## Tutorial Modules

1. **[01. SQLite Database Integration](01-db-connection-sqlite.md)**:
   - Creating and seeding the local SQLite database (`Data/staff.db`)
   - Setting up Entity Framework Core with `Microsoft.EntityFrameworkCore.Sqlite`
   - Creating the `Staff` model and `ApplicationDbContext`
   - Dependency Injection in `Program.cs` and `Pages/Staff/Index.cshtml.cs`
   - Rendering the staff directory table

2. **[02. MSSQL Database Integration (Alternative)](02-db-connection-mssql.md)**:
   - Connecting to Microsoft SQL Server / Azure SQL / Docker
   - Using `Microsoft.EntityFrameworkCore.SqlServer`
   - Working with EF Core Migrations (`dotnet ef migrations add` & `dotnet ef database update`)

3. **[03. Route Parameters & Staff Details](03-data-routing.md)**:
   - Generating links with `asp-route-id`
   - Defining route templates with `@page "{id:int}"`
   - Retrieving single records with `_context.Staff.FindAsync(id)`

4. **[04. Searching Data](04-searching-the-data.md)**:
   - GET form model binding with `[BindProperty(SupportsGet = true)]`
   - Constructing dynamic queries with deferred execution (`IQueryable<Staff>`)
   - Case-insensitive LINQ search filtering

---

> 💡 **HTTP Methods & Routing Demos:**  
> For interactive demos covering GET query strings, route parameters vs query strings, and POST with the Post-Redirect-Get (PRG) pattern, see the companion repository: [webdev-razor-http-methods](https://github.com/mustbebuilt/webdev-razor-http-methods).
