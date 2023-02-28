using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Airplane> Airplanes { get; set; }

    public DbSet<Flight> Flights { get; set; }

    public DbSet<Schedule> Schedules { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Order> Orders { get; set; }
}
