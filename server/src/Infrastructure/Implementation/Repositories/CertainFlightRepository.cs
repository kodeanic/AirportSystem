using Domain.Entities;
using Infrastructure.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories;

public class CertainFlightRepository : GenericRepository<CertainFlight>, ICertainFlightRepository
{
    public CertainFlightRepository(ApplicationDbContext db) : base(db) { }

    public async Task CreateRange(List<CertainFlight> bookings) =>
        await _dbSet.AddRangeAsync(bookings);

    public async Task<List<CertainFlight>> GetBookingsOnDate(DateOnly date) =>
        await _dbSet.Where(d => d.Date == date).ToListAsync();

    public async Task<List<CertainFlight>> GetBooking_Date_Way(DateOnly date, string departureCity, string arriveCity) =>
        await _dbSet.Where(b => b.Date == date)
            .Where(b => b.Schedule.Flight.DepartureCity == departureCity)
            .Where(b => b.Schedule.Flight.ArriveCity == arriveCity).ToListAsync();

    public async Task<List<CertainFlight>> GetBooking_Date_From(DateOnly date, string departureCity) =>
        await _dbSet.Where(b => b.Date == date)
            .Where(b => b.Schedule.Flight.DepartureCity == departureCity).ToListAsync();
}
