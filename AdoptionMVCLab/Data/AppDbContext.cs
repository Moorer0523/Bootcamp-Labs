using AdoptionMVCLab.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptionMVCLab.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AnimalModel> Animals { get; set; }
    //Tabula go here


}
