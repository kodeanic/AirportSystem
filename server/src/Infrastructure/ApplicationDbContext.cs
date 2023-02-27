using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        /*
        Database.EnsureDeleted();
        Database.EnsureCreated();
        */
    }

    public DbSet<Airplane> Airplanes { get; set; }

    public DbSet<Flight> Flights { get; set; }

    public DbSet<Schedule> Schedules { get; set; }
}
