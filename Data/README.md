# Data Directory

This folder is reserved for your application's database and data context classes.

## In Step 06 of the Lab:
1. **Create the SQLite Database File (`staff.db`)**:
   Run the following terminal command from the project root to create and seed your SQLite database using the SQL script provided in `resources/staff-sqlite.sql`:

   ```bash
   sqlite3 Data/staff.db < resources/staff-sqlite.sql
   ```

   To verify that the 6 sample staff records were created:
   ```bash
   sqlite3 Data/staff.db "SELECT count(*) FROM staff;"
   ```

2. **Create the Database Context (`ApplicationDbContext.cs`)**:
   Follow Section 4 of the tutorial (`06-db-connection-sqlite.md`) to create your `ApplicationDbContext` class in this folder.
