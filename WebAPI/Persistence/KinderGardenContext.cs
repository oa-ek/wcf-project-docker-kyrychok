using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Persistence;

public class KinderGardenContext : DbContext
{
    public DbSet<Child> Children { get; set; }
    public DbSet<Toy> Toys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        // name of database
        optionsBuilder.UseSqlite("Data Source = KinderGarden.db");
    }
}