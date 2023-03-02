using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(ApplicationDbContext db) : base(db) { }

    public async Task<List<Schedule>> GetScheduleByFlight(string flight) =>
        await _dbSet.Where(s => s.Flight.Name.ToLower() == flight.ToLower()).ToListAsync();

    public async Task<List<Schedule>> GetScheduleByWeekDay(DayOfWeek dayOfWeek) =>
        await _dbSet.Where(s => s.DayOfWeek == dayOfWeek).ToListAsync();
}
