using Infrastructure.Interfaces;

namespace Infrastructure.IConfiguration;

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
