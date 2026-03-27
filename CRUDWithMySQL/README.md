# CRUD Operations with EF Core & MySQL

## Overview
This project demonstrates high-level **CRUD (Create, Read, Update, Delete)** operations using **Entity Framework Core 9** and **MySQL**. It serves as the initial "Inbetriebnahme" (commissioning) logic for industrial hardware management, specifically targeting the **Microsoft Backend Developer** curriculum.

**System Motto:** "Control the memory, control the machine."

## Technical Stack
* **Language:** C# 13 / .NET 9
* **ORM:** Entity Framework Core
* **Database:** MySQL 8.0
* **Architecture:** Modular Service-Oriented Logic

## Modules Implemented
1.  **Create:** Implementation of persistent data entry for industrial hardware (e.g., Knect Tools).
2.  **Read:** Bulk retrieval ($O(n)$) and Primary Key lookup ($O(1)$) using LINQ.
3.  **Search:** Targeted diagnostic scanning using `Where` and `Contains` filters.
4.  **Update:** Real-time calibration of hardware records in the database.
5.  **Delete:** Decommissioning of stale records to maintain data integrity.
6.  **Serialization:** Conversion of objects to JSON strings for **D791 AI Integration** and mobile interface (Samsung S26 Ultra) support.

## Security & Configuration
This project utilizes the **.NET User-Secrets Manager** to protect database credentials, ensuring that mission-critical connection strings are never exposed in version control.

## Operational Integrity
By utilizing explicit `using` blocks, the system ensures scoped database connections, preventing connection pool exhaustion and optimizing memory usage on the host workstation (Lenovo Yoga 9i).