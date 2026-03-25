using Microsoft.EntityFrameworkCore;

namespace EFCoreModelApp.Services; 

public class EmployeeService(HRDbContext context)
{
    public void ListAllEmployees()
    {
        var employeeList = context.Employees
            .Include(e => e.Department)
            .Where(e => e.IsActive)
            .ToList(); 
        
        Console.WriteLine("\n--- Current Employee Registry ---");
        
        if (!employeeList.Any())
        {
            Console.WriteLine("No records found.");
            return;
        }

        foreach (var emp in employeeList)
        {
            string departmentDisplay = emp.Department?.Name ?? "Unassigned";
            Console.WriteLine($"ID: {emp.EmployeeId}, Name: {emp.FirstName} {emp.LastName}, Department: {departmentDisplay}");
        }
    }

    public void RegisterNewEmployee()
    {
        Console.WriteLine("\n--- Register New Employee ---");
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine() ?? "Unknown";
        
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine() ?? "Unknown";

        var depts = context.Departments.ToList();
        Console.WriteLine("\nAvailable Departments: " + string.Join(", ", depts.Select(d => d.Name)));

        Console.Write("Enter Department Name: ");
        string deptName = Console.ReadLine() ?? "Unknown";

        var selectedDept = context.Departments
            .FirstOrDefault(d => d.Name.ToLower() == deptName.ToLower());

        if (selectedDept == null)
        {
            Console.WriteLine("[Error]: Department not found. High-level abort triggered.");
            return;
        }

        var emp = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            HireDate = DateTime.Now,
            DepartmentId = selectedDept.DepartmentId,
            Department = null!
        };

        context.Employees.Add(emp);
        context.SaveChanges();
        Console.WriteLine($"\n[System Update]: {emp.FirstName} added successfully.");
    }

    public void DeactivateEmployee()
    {
        Console.Write("\nEnter Employee ID to deactivate: ");
        if (!int.TryParse(Console.ReadLine(), out int empId))
            return;


        var emp = context.Employees.FirstOrDefault(e => e.EmployeeId == empId);

        if (emp == null)
        {
            Console.WriteLine("[Error]: Employee not found. High-level abort triggered.");
            return;
        }

        emp.IsActive = false;
        context.SaveChanges();
        Console.WriteLine($"\n[System Update]: {emp.FirstName} deactivated successfully.");
    }


    public void SearchEmployee()
    {
        Console.Write("\nEnter Name to search: ");
        string searchTerm = Console.ReadLine()?.ToLower() ?? "";

        var results = context.Employees
            .Include(e => e.Department)
            .Where(e => e.IsActive &&
                        (e.FirstName.ToLower().Contains(searchTerm) ||
                         e.LastName.ToLower().Contains(searchTerm)))
            .ToList();

        Console.WriteLine($"\n--- Search Results for '{searchTerm}' ---");
        if (!results.Any())
        {
            Console.WriteLine("No matching active records found.");
            return;
        }

        foreach (var emp in results)
        {
            Console.WriteLine(
                $"ID: {emp.EmployeeId} | Name: {emp.FirstName} {emp.LastName} | Dept: {emp.Department?.Name}");
        }
    }

    }

