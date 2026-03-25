using EFCoreModelApp;
using EFCoreModelApp.Services;

// The 'using' declaration handles disposal automatically
using var context = new HRDbContext();
var service = new EmployeeService(context);
bool running = true;

while (running)
{
    Console.WriteLine("\n=== HR MANAGEMENT SYSTEM ===");
    Console.WriteLine("1. List All Employees");
    Console.WriteLine("2. Register New Employee");
    Console.WriteLine("3. Exit System");
    Console.WriteLine("4. Deactivate Employee");
    Console.WriteLine("5. Search Employee");
    Console.Write("\nSelect Option [1-5]: ");

    string input = Console.ReadLine() ?? "";

    switch (input)
    {
        case "1":
            service.ListAllEmployees();
            break;
        case "2":
            service.RegisterNewEmployee();
            break;
        case "3":
            Console.WriteLine("Closing Database Connection... Goodbye.");
            running = false;
            break;
        case "4":
            service.DeactivateEmployee();
            break;
        case "5":
            service.SearchEmployee();
            break;
        default:
            Console.WriteLine("Invalid Input! Please check the terminal for valid protocols.");
            break;
    }
}