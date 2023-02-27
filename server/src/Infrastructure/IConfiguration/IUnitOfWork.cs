using Infrastructure.Interfaces;

namespace Infrastructure.IConfiguration;

public interface IUnitOfWork
{
    IAirplaneRepository Airplanes { get; }
    IFlightRepository Flights { get; }

    Task CompleteAsync();
}
