using Infrastructure.IConfiguration;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _db;

    public IAirplaneRepository Airplanes { get; private set; }
    public IFlightRepository Flights { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;

        Airplanes = new AirplaneRepository(_db);
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
