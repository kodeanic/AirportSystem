using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(ApplicationDbContext db) : base(db) { }

    public async Task<List<Booking>> GetBookingsOnDate(DateOnly date) =>
        await _dbSet.Where(d => d.Date == date).ToListAsync();
}
