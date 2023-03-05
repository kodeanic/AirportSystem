using Infrastructure.Interfaces.IRepository;

namespace Infrastructure.Interfaces.IConfiguration;

public interface IUnitOfWork
{
    IAirplaneRepository Airplanes { get; }
    IFlightRepository Flights { get; }
    IScheduleRepository Schedules { get; }
    IUserRepository Users { get; }
    IUserInformationRepository UserInformations { get; }
    ICertainFlightRepository CertainFlights { get; }

    Task CompleteAsync();
}
