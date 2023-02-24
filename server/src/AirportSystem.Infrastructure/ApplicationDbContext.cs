using AirportSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirportSystem.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<Flight> Flight { get; set; }
}
