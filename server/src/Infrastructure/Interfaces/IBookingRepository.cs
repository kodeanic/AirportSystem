using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IBookingRepository : IGenericRepository<Booking>
{
    Task<List<Booking>> GetBookingsOnDate(DateOnly date);

    Task<List<Booking>> GetBooking_Date_Way(DateOnly date, string departureCity, string arriveCity);
}
