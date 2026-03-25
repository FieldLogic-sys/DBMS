namespace EFCoreModelApp
{
    public class Department
    {
        public int DepartmentId { get; set; } // Primary Key
        public required string Name { get; set; }
        public required List<Employee> Employees { get; set; } // Navigation Property
    }
}