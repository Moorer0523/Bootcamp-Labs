using Microsoft.EntityFrameworkCore;

namespace CoffeeShopLab.Models.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    //Outline what tables are available in the DB

    public DbSet<User> Users { get; set; }

}
