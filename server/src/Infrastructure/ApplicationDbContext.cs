using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseLazyLoadingProxies();

    public DbSet<Airplane> Airplanes { get; set; }

    public DbSet<Flight> Flights { get; set; }

    public DbSet<Schedule> Schedules { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserInformation> UserInformations { get; set; }

    public DbSet<CertainFlight> CertainFlights { get; set; }
}
