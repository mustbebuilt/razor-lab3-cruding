# Database Resources & Seed Scripts

This directory contains SQL scripts to create and populate the database tables for this tutorial.

## Available SQL Scripts

1. **`staff-sqlite.sql`**:
   - For SQLite local development (used in [06-db-connection-sqlite.md](../docs/06-db-connection-sqlite.md)).
   - Creates the `staff` table with column constraints and seeds 6 realistic employee records.
   - Command to execute:
     ```bash
     sqlite3 Data/staff.db < resources/staff-sqlite.sql
     ```

2. **`staff-mssql.sql`**:
   - For Microsoft SQL Server / Azure SQL / Docker SQL Server (used in [07-db-connection-mssql.md](../docs/07-db-connection-mssql.md)).
   - Creates the `[dbo].[staff]` table and inserts identical sample records with MSSQL-specific types (`NVARCHAR`, `IDENTITY`, `DECIMAL(18,2)`).
