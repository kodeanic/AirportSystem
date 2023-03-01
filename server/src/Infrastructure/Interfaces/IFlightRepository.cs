using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IFlightRepository : IGenericRepository<Flight>
{
    Task<Flight> GetFlightByName(string name);

    Task<List<Flight>> GetFlightsByCompany(string company);

    Task<List<Flight>> GetFlightsByDepartureCity(string departureCity);

    Task<List<Flight>> GetFlightsByArriveCity(string arriveCity);
}
