using Domain.Entities;
using Infrastructure.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Implementation.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(ApplicationDbContext db) : base(db) { }

    public async Task CreateRange(List<Booking> bookings) =>
        await _dbSet.AddRangeAsync(bookings);

    public async Task<List<Booking>> GetBookingsOnDate(DateOnly date) =>
        await _dbSet.Where(d => d.Date == date).ToListAsync();

    public async Task<List<Booking>> GetBooking_Date_Way(DateOnly date, string departureCity, string arriveCity) =>
        await _dbSet.Where(b => b.Date == date)
            .Where(b => b.Schedule.Flight.DepartureCity == departureCity)
            .Where(b => b.Schedule.Flight.ArriveCity == arriveCity).ToListAsync();

    public async Task<List<Booking>> GetBooking_Date_From(DateOnly date, string departureCity) =>
        await _dbSet.Where(b => b.Date == date)
            .Where(b => b.Schedule.Flight.DepartureCity == departureCity).ToListAsync();
}
