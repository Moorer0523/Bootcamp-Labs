using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TacosFastFoodAPI.Models;

namespace TacosFastFoodAPI.Data;

public class TacoDBContext : DbContext
{
    public TacoDBContext(DbContextOptions<TacoDBContext> options) : base(options) { }

    public DbSet<Taco> Tacos {  get; set; }

    public DbSet<Drink> Drinks { get; set; }
}
