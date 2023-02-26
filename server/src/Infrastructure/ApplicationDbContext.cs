using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Flight> Flights { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    /*
    Database.EnsureDeleted();
    Database.EnsureCreated();
    */
}
