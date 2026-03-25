# EFCoreModelApp: Relational Data Management System

### ⚙️ Infrastructure Overview
A modular backend application built on **.NET 9.0** and **Entity Framework Core**. This project demonstrates the transition from industrial hardware commissioning (**Inbetriebnahme**) logic to high-level Software Engineering principles.

### 🏗️ Architecture & Design Patterns
* **Service Layer Pattern:** Logic is decoupled from the entry point (`Program.cs`) into an `EmployeeService` for better testability and maintenance.
* **Eager Loading:** Implements `.Include()` to resolve relational dependencies between Employees and Departments.
* **Null Safety:** Utilizes C# Null-Safety features (Null-forgiving operator `!`) to prevent runtime exceptions during data entry.

### 🛠️ Setup Protocol
```powershell
# 1. Clean environment
dotnet clean; dotnet build

# 2. Commission database
dotnet ef database update

# 3. Start system interface
dotnet run




### 🔄 Database Evolution
* **Migration Strategy:** Utilized EF Core Migrations to implement "Soft Delete" functionality via an `IsActive` boolean flag.
* **Schema Resilience:** Navigated SQLite table-rebuild constraints (PRAGMA foreign_keys) to ensure zero data loss during structural updates.