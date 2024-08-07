using Microsoft.EntityFrameworkCore;

namespace MVC_StarterPack.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //Add your tables here
}
