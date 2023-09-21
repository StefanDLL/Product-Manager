using Microsoft.EntityFrameworkCore;
using Product_Manager.Domain;

namespace Product_Manager.Data;

public class ApplicationContext : DbContext
{
    private string connectionString = "Server=localhost;Database=Product_Manager;Integrated Security=true;Encrypt=false;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Product> Product { get; set; }
}
