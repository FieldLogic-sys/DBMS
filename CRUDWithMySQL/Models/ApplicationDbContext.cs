using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
// Make sure this namespace matches the folder where Product.cs is
using CRUDWithMySQL.Models;

namespace CRUDWithMySQL.Models
{
    // 1. Added ': DbContext' inheritance
    public class ApplicationDbContext : DbContext
    {
        // 2. Added empty constructor for the Migration Tool
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 3. Changed to 'public' and singular Model type
        public DbSet<Product> Products { get; set; } = null!;

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         if (!optionsBuilder.IsConfigured)
         {
             // This is the "Safe" way
             IConfigurationRoot configuration = new ConfigurationBuilder()
                 .AddUserSecrets<ApplicationDbContext>()
                 .Build();

             var connectionString = configuration.GetConnectionString("DefaultConnection");
             optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
         }
     }
    }
}