using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IFlightRepository : IGenericRepository<Flight>
{
    //Task<string> GetWayOfFlight(Guid id);
}
