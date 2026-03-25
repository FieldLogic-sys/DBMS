namespace EFCoreModelApp
{
    public class Employee
    {
        public int EmployeeId { get; set; } // Primary Key
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; } // Foreign Key
        public virtual Department? Department { get; set; } // Navigation Property
    }
}