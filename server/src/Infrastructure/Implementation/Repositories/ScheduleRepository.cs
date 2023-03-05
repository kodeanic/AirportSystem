using Domain.Entities;
using Infrastructure.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(ApplicationDbContext db) : base(db) { }

    public async Task<List<Schedule>> GetByFlight(string flight) =>
        await _dbSet.Where(s => s.Flight.Name.ToLower() == flight.ToLower()).ToListAsync();

    public async Task<List<Schedule>> GetByWeekDay(DayOfWeek dayOfWeek) =>
        await _dbSet.Where(s => s.DayOfWeek == dayOfWeek).ToListAsync();
}
