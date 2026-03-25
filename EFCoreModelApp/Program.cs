using EFCoreModelApp;
using EFCoreModelApp.Services;

using var context = new HRDbContext();

{
    var service = new EmployeeService(context);
    bool running = true;


    while (running)
    {
        Console.WriteLine("\n=== HR MANAGEMENT SYSTEM ===");
        Console.WriteLine("1. List All Employees");
        Console.WriteLine("2. Register New Employee");
        Console.WriteLine("3. Exit System");
        Console.Write("\nSelect Option [1-3]: ");


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
                default:
                    Console.WriteLine("Invalid Input! Pleae check the terminal for valid protocols.");
                    break;
            }
    }
}