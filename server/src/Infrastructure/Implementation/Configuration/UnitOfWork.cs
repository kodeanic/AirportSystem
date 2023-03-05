using Infrastructure.Interfaces.IConfiguration;
using Infrastructure.Interfaces.IRepository;
using Infrastructure.Implementation.Repositories;

namespace Infrastructure.Implementation.Configuration;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _db;

    public IAirplaneRepository Airplanes { get; private set; }
    public IFlightRepository Flights { get; private set; }
    public IScheduleRepository Schedules { get; private set; }
    public IUserRepository Users { get; private set; }
    public IUserInformationRepository UserInformations { get; private set; }
    public ICertainFlightRepository CertainFlights { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;

        Airplanes = new AirplaneRepository(_db);
        Flights = new FlightRepository(_db);
        Schedules = new ScheduleRepository(_db);
        Users = new UserRepository(_db);
        UserInformations = new UserInformationRepository(_db);
        CertainFlights = new CertainFlightRepository(_db);
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
