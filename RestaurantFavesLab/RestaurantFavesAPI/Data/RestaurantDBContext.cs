using Microsoft.EntityFrameworkCore;
using RestaurantFavesAPI.Models;

namespace RestaurantFavesAPI.Data;

public class RestaurantDBContext : DbContext
{
    public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }
}
