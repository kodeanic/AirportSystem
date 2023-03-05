using Domain.Entities;

namespace Infrastructure.Interfaces.IRepository;

public interface ICertainFlightRepository : IGenericRepository<CertainFlight>
{
    Task CreateRange(List<CertainFlight> bookings);

    Task<List<CertainFlight>> GetBookingsOnDate(DateOnly date);

    Task<List<CertainFlight>> GetBooking_Date_Way(DateOnly date, string departureCity, string arriveCity);
}
