using AirportSystem.Domain.Entities;

namespace AirportSystem.Infrastructure.Interfaces;

public interface IFlightRepository : IBaseRepository<Flight>
{
    Task<Flight> GetByName(string name);
}
