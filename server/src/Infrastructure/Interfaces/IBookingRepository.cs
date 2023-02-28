using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IBookingRepository : IGenericRepository<Booking>
{
    Task<List<Booking>> GetBookingsOnDate(DateOnly date);
}
