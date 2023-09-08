using Microsoft.EntityFrameworkCore;
using Product_Manager.Domain;

namespace Product_Manager.Data;

//DbContext = reprsenterar en "session" mot databasen - det är via den vi kommunicerar med databasen.

public class ApplicationContext : DbContext
{
    private string connectionString = "Server=localhost;Database=Product_Manager;Integrated Security=true;Encrypt=false;";


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    // DbSet = representerar i grund och botten en tabell
    public DbSet<Product> Product { get; set; }
}
