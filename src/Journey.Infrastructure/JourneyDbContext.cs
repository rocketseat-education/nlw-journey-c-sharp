using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure;

public class JourneyDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlite("Data Source=JourneyDatabase.db");
        optionsBuilder.UseSqlite("Data Source=/home/dop/RiderProjects/nlw3-Journey/src/Journey.Infrastructure/JourneyDatabase.db");
    }
}