using Infrastructure.IConfiguration;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _db;

    public IFlightRepository Flights { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;

        Flights = new FlightRepository(_db);
    }

    public async Task CompleteAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
