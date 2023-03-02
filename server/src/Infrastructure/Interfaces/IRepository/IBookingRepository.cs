using Domain.Entities;

namespace Infrastructure.Interfaces.IRepository;

public interface IBookingRepository : IGenericRepository<Booking>
{
    Task CreateRange(List<Booking> bookings);

    Task<List<Booking>> GetBookingsOnDate(DateOnly date);

    Task<List<Booking>> GetBooking_Date_Way(DateOnly date, string departureCity, string arriveCity);
}
