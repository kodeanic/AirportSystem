using Domain.Entities;

namespace Infrastructure.Interfaces.IRepository;

public interface IFlightRepository : IGenericRepository<Flight>
{
    Task<Flight> GetByName(string name);

    Task<List<Flight>> GetByCompany(string company);

    Task<List<Flight>> GetByDepartureCity(string departureCity);

    Task<List<Flight>> GetByArriveCity(string arriveCity);
}
