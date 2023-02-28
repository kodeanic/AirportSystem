using Infrastructure.IConfiguration;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _db;

    public IAirplaneRepository Airplanes { get; private set; }
    public IFlightRepository Flights { get; private set; }
    public IScheduleRepository Schedules { get; private set; }
    public IBookingRepository Bookings { get; private set; }
    public IUserRepository Users { get; private set; }
    public IOrderRepository Orders { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;

        Airplanes = new AirplaneRepository(_db);
        Flights = new FlightRepository(_db);
        Schedules = new ScheduleRepository(_db);
        Bookings = new BookingRepository(_db);
        Users = new UserRepository(_db);
        Orders = new OrderRepository(_db);
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
