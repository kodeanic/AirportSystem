using Infrastructure.Interfaces;

namespace Infrastructure.IConfiguration;

public interface IUnitOfWork
{
    IFlightRepository Flights { get; }

    Task CompleteAsync();
}
