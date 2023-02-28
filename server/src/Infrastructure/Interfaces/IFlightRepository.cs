using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IFlightRepository : IGenericRepository<Flight>
{
    Task<List<Flight>> GetFlightsByCompany(string company);

    Task<List<Flight>> GetFlightsByDepartureCity(string departureCity);

    Task<List<Flight>> GetFlightsByArriveCity(string arriveCity);
}
