# Lab 2: Data & Databases in ASP.NET Core Razor Pages (Starter Application)

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512bd4.svg)](https://dotnet.microsoft.com/)
[![Razor Pages](https://img.shields.io/badge/ASP.NET%20Core-Razor%20Pages-0284c7.svg)](https://learn.microsoft.com/aspnet/core/razor-pages/)
[![SQLite](https://img.shields.io/badge/Database-SQLite-003B57.svg)](https://www.sqlite.org/)
[![EF Core](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-68217a.svg)](https://learn.microsoft.com/ef/core/)

Welcome to **Lab 2**! This repository is the starter template designed for students to fork and clone. 

In this lab, you will extend a clean ASP.NET Core Razor Pages web application into a dynamic, data-driven system by connecting a local SQLite database using **Entity Framework Core (EF Core)**, executing LINQ queries, passing route parameters to dedicated detail pages, building search filters, and mastering HTTP request patterns.

> 📖 **Full Tutorial Guide**: Follow the step-by-step instructions in the [GitHub Wiki Guide](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki).

---

## 📋 Table of Contents

- [Requirements & Prerequisites](#-requirements--prerequisites)
- [Quick Start](#-quick-start)
- [Lab Tutorial Syllabus](#-lab-tutorial-syllabus)
- [Step-by-Step Instructions](#-step-by-step-instructions)
- [Repository Structure](#-repository-structure)
- [Database Schema & Seed Data](#-database-schema--seed-data)
- [Interactive HTTP Demos](#-interactive-http-demos)

---

## 🛠 Requirements & Prerequisites

Before starting this lab, ensure you have:

- **.NET 10 SDK** (or .NET 8.0+) - [Download .NET](https://dotnet.microsoft.com/download)
- **Visual Studio Code** - [Download VS Code](https://code.visualstudio.com/)
  - Recommended extensions: *C# Dev Kit*, *SQLite Viewer* (optional)
- **SQLite 3 CLI** (pre-installed on macOS/Linux; available via `winget install SQLite.SQLite` or package manager on Windows)
- Familiarity with Lab 1 concepts (Razor syntax, layouts, PageModels, and Tag Helpers).

Verify your installed .NET SDK version:
```bash
dotnet --version
```

---

## 🚀 Quick Start

### 1. Fork & Clone

Fork this repository to your own GitHub account, then clone it to your development machine:

```bash
git clone https://github.com/<YOUR-USERNAME>/webdev-razor-lab2-data.git
cd webdev-razor-lab2-data
```

### 2. Run the Starter Application

Restore dependencies and launch the local Kestrel development server:

```bash
dotnet run
```

Open your browser to the local URL displayed in the terminal (typically `http://localhost:5000` or `https://localhost:5001`).

---

## 📚 Lab Tutorial Syllabus

The tutorial instructions are published in the project wiki:

| Step | Topic | Description |
|:---:|:---|:---|
| **06** | [SQLite Database Integration](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki/06.-SQLite-Database-Integration) | Install EF Core, create `Models/Staff.cs`, `Data/ApplicationDbContext.cs`, register service, and list staff. |
| **07** | [MSSQL Database Integration](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki/07.-MSSQL-Database-Integration) | *(Alternative)* Learn how EF Core connects to Microsoft SQL Server / Azure SQL. |
| **08** | [Route Parameters & Details Page](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki/08.-Data-Routing-and-Details) | Pass `asp-route-id`, constrain routes with `@page "{id:int}"`, and display single records. |
| **08a** | [Searching Data with LINQ](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki/08a.-Searching-the-Data) | GET form model binding (`[BindProperty(SupportsGet = true)]`) and dynamic deferred LINQ filtering. |
| **08b** | [HTTP Methods & Routing Demos](https://github.com/mustbebuilt/webdev-razor-lab2-data/wiki/08b.-HTTP-Methods-and-Routing) | Explore GET query strings, route segments vs queries, and HTTP POST with Post-Redirect-Get (PRG). |

---

## 📝 Step-by-Step Instructions

### Step 1: Create Your Local SQLite Database

Students create the database themselves using the provided SQL script:

```bash
# Run from the project root directory
sqlite3 Data/staff.db < resources/staff-sqlite.sql
```

Verify that the `staff` table has been seeded with 6 employees:
```bash
sqlite3 Data/staff.db "SELECT staff_id, first_name, last_name, department, salary FROM staff;"
```

### Step 2: Install EF Core SQLite Provider

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

### Step 3: Create the Entity Model (`Models/Staff.cs`)

Create `Models/Staff.cs` representing the `staff` database table:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRazorApp.Models;

public class Staff
{
    [Key]
    [Column("staff_id")]
    public int StaffId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("department")]
    public string Department { get; set; } = string.Empty;

    [Column("job_title")]
    public string JobTitle { get; set; } = string.Empty;

    [Column("hire_date")]
    public string HireDate { get; set; } = string.Empty;

    [Column("salary")]
    public double Salary { get; set; }

    [Column("is_active")]
    public int IsActive { get; set; } // 0 = Inactive, 1 = Active
}
```

### Step 4: Create the Database Context (`Data/ApplicationDbContext.cs`)

Create `Data/ApplicationDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using MyRazorApp.Models;

namespace MyRazorApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Staff> Staff { get; set; } = null!;
}
```

### Step 5: Register DbContext in `Program.cs`

In `Program.cs`, add the following before `builder.Build()`:

```csharp
using Microsoft.EntityFrameworkCore;
using MyRazorApp.Data;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### Step 6: Connect `Pages/Staff/Index.cshtml` to SQLite

Inject `ApplicationDbContext` into `Pages/Staff/Index.cshtml.cs`:

```csharp
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRazorApp.Data;
using MyRazorApp.Models;

namespace MyRazorApp.Pages.Staff;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Models.Staff> StaffMembers { get; set; } = [];
    public int ActiveCount { get; set; }

    public async Task OnGetAsync()
    {
        StaffMembers = await _context.Staff.ToListAsync();
        ActiveCount = StaffMembers.Count(s => s.IsActive == 1);
    }
}
```

Then update `Pages/Staff/Index.cshtml` to iterate over `@Model.StaffMembers` using `@foreach`.

---

## 📁 Repository Structure

```text
├── MyRazorApp.csproj            # .NET 10 project definition
├── Program.cs                   # Application entry point, middleware, DI services
├── appsettings.json             # Configuration including SQLite connection string
├── appsettings.Development.json # Development environment settings
├── Data/
│   ├── README.md                # Guidance for student database creation
│   └── (staff.db)               # Created locally by students in Step 06
├── Models/
│   └── README.md                # Reserved for Staff.cs entity model
├── Pages/
│   ├── _ViewImports.cshtml      # Global TagHelpers and namespaces
│   ├── _ViewStart.cshtml        # Default layout assignment
│   ├── Index.cshtml/.cs         # Student dashboard and lab roadmap
│   ├── News.cshtml/.cs          # News announcements page
│   ├── Privacy.cshtml/.cs       # Privacy statement
│   ├── Error.cshtml/.cs         # Error handler
│   ├── Shared/
│   │   └── _Layout.cshtml       # Master responsive layout template
│   ├── Staff/
│   │   └── Index.cshtml/.cs     # Staff Directory starter (Target for Steps 06 & 08a)
│   └── HttpDemo/                # Interactive HTTP Method & Routing Demos (Step 08b)
│       ├── Index.cshtml/.cs     # HTTP demos landing overview
│       ├── GetDemo.cshtml/.cs   # Query strings and GET model binding
│       ├── RouteDemo.cshtml/.cs # Route parameters vs query strings
│       ├── MultiRouteDemo.cshtml/.cs # Multiple URL path segments
│       └── PostDemo.cshtml/.cs  # POST form, validation, and PRG pattern
├── resources/
│   ├── README.md                # Details on database seed files
│   ├── staff-sqlite.sql         # SQLite DDL and 6 seed records
│   └── staff-mssql.sql          # Microsoft SQL Server DDL and seed records
├── docs/                        # Tutorial documentation (mirrored in Wiki)
└── wwwroot/
    ├── css/site.css             # Vanilla CSS design system
    ├── js/site.js               # Client JavaScript
    └── favicon.ico              # App favicon
```

---

## 🗄 Database Schema & Seed Data

The sample company staff dataset features 6 employee records across Engineering, HR, Finance, Marketing, and Sales:

| Staff ID | Full Name | Department | Job Title | Salary | Active? |
|:---:|:---|:---|:---|---:|:---:|
| 1 | Alice Johnson | Engineering | Engineering Manager | £55,000 | Yes |
| 2 | Brian Lee | Engineering | Senior Developer | £52,000 | Yes |
| 3 | Carla Gomez | Human Resources | HR Specialist | £48,000 | No |
| 4 | David Smith | Finance | Financial Analyst | £55,000 | Yes |
| 5 | Emma Watson | Marketing | Marketing Director | £60,000 | Yes |
| 6 | Frank Wright | Sales | Account Executive | £45,000 | Yes |

---

## 🌐 Interactive HTTP Demos

Navigate to **HTTP Demos** in the application menu (`/HttpDemo`) to test:

1. **HTTP GET & Query Strings** (`/HttpDemo/GetDemo`): Filter courses by category, difficulty level, and keyword using URL query strings (`?Subject=Computer+Science&Level=Beginner`).
2. **Route Parameters vs Query Strings** (`/HttpDemo/RouteDemo/101?tab=compensation`): See how route segments identify resources while query strings modify view state.
3. **Multiple Route Parameters** (`/HttpDemo/MultiRouteDemo/engineering/101`): Test multi-segment URL paths using `@page "{department?}/{id:int?}"`.
4. **HTTP POST & Post-Redirect-Get** (`/HttpDemo/PostDemo`): Submit forms safely in the request body and prevent duplicate submissions with PRG and `TempData` flash messages.

---

## 📄 License & Attribution

Created for university/college Web Application Development modules. Free for educational use.
