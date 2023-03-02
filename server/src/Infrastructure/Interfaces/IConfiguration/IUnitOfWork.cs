using Infrastructure.Interfaces.IRepository;

namespace Infrastructure.Interfaces.IConfiguration;

public interface IUnitOfWork
{
    IAirplaneRepository Airplanes { get; }
    IFlightRepository Flights { get; }
    IScheduleRepository Schedules { get; }
    IBookingRepository Bookings { get; }
    IUserRepository Users { get; }
    IOrderRepository Orders { get; }

    Task CompleteAsync();
}
