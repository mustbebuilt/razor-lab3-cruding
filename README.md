# Lab 3: CRUD Operations in ASP.NET Core Razor Pages (Starter Application)

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512bd4.svg)](https://dotnet.microsoft.com/)
[![Razor Pages](https://img.shields.io/badge/ASP.NET%20Core-Razor%20Pages-0284c7.svg)](https://learn.microsoft.com/aspnet/core/razor-pages/)
[![SQLite](https://img.shields.io/badge/Database-SQLite-003B57.svg)](https://www.sqlite.org/)
[![EF Core](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-68217a.svg)](https://learn.microsoft.com/ef/core/)

Welcome to **Lab 3**! This repository is the starter template designed for students to fork and clone. 

In this lab, you will extend a data-driven ASP.NET Core Razor Pages web application (started in Lab 2) by implementing full **CRUD (Create, Read, Update, Delete)** operations with **Entity Framework Core (EF Core)** and **SQLite**. You will build HTML input forms, handle HTTP POST requests, validate user input with Data Annotations, enforce safe data-deletion workflows, and apply the **Post-Redirect-Get (PRG)** design pattern with `TempData` user feedback.

> 📖 **Full Tutorial Guide**: Follow the step-by-step instructions in the [GitHub Wiki Guide](https://github.com/mustbebuilt/razor-lab3-cruding/wiki).

---

## 📋 Table of Contents

- [Requirements & Prerequisites](#-requirements--prerequisites)
- [Quick Start](#-quick-start)
- [Lab Tutorial Syllabus](#-lab-tutorial-syllabus)
- [Reference & Supplementary Guides](#-reference--supplementary-guides)
- [Repository Structure](#-repository-structure)
- [Database Schema & Resetting the Database](#-database-schema--resetting-the-database)
- [Companion Labs](#-companion-labs)

---

## 🛠 Requirements & Prerequisites

Before starting this lab, ensure you have:

- **.NET 10 SDK** (or .NET 8.0+) - [Download .NET](https://dotnet.microsoft.com/download)
- **Visual Studio Code** - [Download VS Code](https://code.visualstudio.com/)
  - Recommended extensions: *C# Dev Kit*, *SQLite Viewer* (optional)
- **SQLite 3 CLI** (pre-installed on macOS/Linux; available via package managers on Windows)
- Completed **Lab 1** (Razor syntax, layouts, PageModels, Tag Helpers) and **Lab 2** (EF Core SQLite setup, DbContext, query filtering, and details routing).

Verify your installed .NET SDK version:
```bash
dotnet --version
```

---

## 🚀 Quick Start

### 1. Fork & Clone

Fork this repository to your own GitHub account, then clone it to your development machine:

```bash
git clone https://github.com/<YOUR-USERNAME>/razor-lab3-cruding.git
cd razor-lab3-cruding
```

### 2. Run the Starter Application

Launch the local Kestrel development server:

```bash
dotnet run
```

For automatic hot-reloading as you edit Razor files and C# models, use:

```bash
dotnet watch run
```

Open your browser to the local URL displayed in the terminal (typically `http://localhost:5000`).

---

## 📚 Lab Tutorial Syllabus

The step-by-step lab instructions are published in the [Lab 3 GitHub Wiki](https://github.com/mustbebuilt/razor-lab3-cruding/wiki):

| Step | Tutorial Page | Description |
|:---:|:---|:---|
| **01** | [CRUD Overview & the PRG Pattern](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/01.-CRUD-Overview-and-the-PRG-Pattern) | Explore CRUD concepts, distinguish GET vs POST, master the Post-Redirect-Get pattern, and inspect the starter codebase. |
| **02** | [Inserting Data (Creating Records)](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/02.-Inserting-Data-Creating-Records) | Build `Pages/Staff/Create.cshtml`, use `asp-for` Tag Helpers, handle `OnPostAsync()`, and insert records with `_context.Staff.Add()`. |
| **03** | [Form Validation & Data Annotations](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/03.-Form-Validation-and-Data-Annotations) | Apply validation attributes (`[Required]`, `[Range]`, `[EmailAddress]`), enforce `ModelState.IsValid`, and add client-side validation. |
| **04** | [Editing Data (Updating Records)](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/04.-Editing-Data-Updating-Records) | Create `Pages/Staff/Edit.cshtml`, bind route `{id:int}`, maintain hidden entity IDs, and update database records safely. |
| **05** | [Deleting Data (Safe Deletion)](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/05.-Deleting-Data-Safe-Deletion) | Understand why GET must never mutate data, implement a two-step confirmation page (`Delete.cshtml`), and remove records via POST. |
| **06** | [User Feedback & UI Polish](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/06.-User-Feedback-and-UI-Polish) | Provide flash alerts using `TempData`, add action buttons to the Staff Directory, and explore soft delete vs hard delete patterns. |

---

## 📖 Reference & Supplementary Guides

| Guide | Description |
|:---|:---|
| [EF Core State & Concurrency](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/90.-EF-Core-State-and-Concurrency) | Deep dive into `EntityState`, the EF Core `ChangeTracker`, connected vs disconnected entities, and concurrency conflict handling. |
| [CRUD Operations Cheat Sheet](https://github.com/mustbebuilt/razor-lab3-cruding/wiki/91.-CRUD-Cheat-Sheet) | Quick-reference lookup table for routes, HTTP verbs, Tag Helpers, PageModel handlers, and EF Core methods. |

---

## 📁 Repository Structure

```text
├── MyRazorApp.csproj            # .NET 10 project definition
├── Program.cs                   # Application entry point, middleware, SQLite DI service
├── appsettings.json             # Configuration including SQLite connection string
├── appsettings.Development.json # Development environment settings
├── Data/
│   ├── ApplicationDbContext.cs  # EF Core DbContext connecting Staff entity to SQLite
│   ├── staff.db                 # Pre-configured SQLite database
│   └── README.md                # Data documentation
├── Models/
│   ├── Staff.cs                 # Staff entity class with schema mappings & data annotations
│   └── README.md                # Model documentation
├── Pages/
│   ├── _ViewImports.cshtml      # Global TagHelpers and namespaces
│   ├── _ViewStart.cshtml        # Default layout assignment
│   ├── Index.cshtml/.cs         # Student dashboard and lab roadmap
│   ├── News.cshtml/.cs          # News announcements page
│   ├── Privacy.cshtml/.cs       # Privacy statement
│   ├── Error.cshtml/.cs         # Error handler
│   ├── Shared/
│   │   └── _Layout.cshtml       # Master responsive layout template
│   └── Staff/
│       ├── Index.cshtml/.cs     # Staff Directory with search & active count
│       └── Details.cshtml/.cs   # Staff member detail view (from Lab 2)
│       └── (Create.cshtml/.cs)  # Created in Step 02
│       └── (Edit.cshtml/.cs)    # Created in Step 04
│       └── (Delete.cshtml/.cs)  # Created in Step 05
├── resources/
│   ├── README.md                # Database seed script details
│   ├── staff-sqlite.sql         # SQLite DDL and 6 seed records
│   └── staff-mssql.sql          # Microsoft SQL Server DDL and seed records
└── wwwroot/
    ├── css/site.css             # Vanilla CSS design system
    ├── js/site.js               # Client JavaScript
    └── favicon.ico              # App favicon
```

---

## 🗄 Database Schema & Resetting the Database

The starter repository includes a pre-seeded SQLite database in `Data/staff.db` containing 6 employee records across multiple departments:

| Staff ID | Full Name | Department | Job Title | Salary | Active? |
|:---:|:---|:---|:---|---:|:---:|
| 1 | Alice Johnson | Engineering | Engineering Manager | £55,000 | Yes |
| 2 | Brian Lee | Engineering | Senior Developer | £52,000 | Yes |
| 3 | Carla Gomez | Human Resources | HR Specialist | £48,000 | No |
| 4 | David Smith | Finance | Financial Analyst | £55,000 | Yes |
| 5 | Emma Watson | Marketing | Marketing Director | £60,000 | Yes |
| 6 | Frank Wright | Sales | Account Executive | £45,000 | Yes |

### Resetting the Database
If you ever want to reset the database back to its initial state after testing create, update, or delete operations, execute:

```bash
sqlite3 Data/staff.db < resources/staff-sqlite.sql
```

---

## 💡 Companion Labs

Explore the related module repositories in the series:
- [webdev-razor-lab1](https://github.com/mustbebuilt/webdev-razor-lab1) - Foundation: Razor Syntax, Layouts & Components
- [webdev-razor-lab2-data](https://github.com/mustbebuilt/webdev-razor-lab2-data) - Data: EF Core, SQLite & LINQ
- [webdev-razor-http-methods](https://github.com/mustbebuilt/webdev-razor-http-methods) - HTTP Methods: GET Query Strings, Route Params & PRG Pattern
