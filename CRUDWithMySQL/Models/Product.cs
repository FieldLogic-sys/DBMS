namespace CRUDWithMySQL.Models
{
    public class Product
    {
        public int Id { get; set; } // EF Core automatically picks 'Id' as the Primary Key
        public string Name { get; set; } = string.Empty; // Initialized to avoid null warnings
        public decimal Price { get; set; }
    }
    
}