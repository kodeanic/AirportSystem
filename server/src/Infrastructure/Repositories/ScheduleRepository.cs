using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
{
    public ScheduleRepository(ApplicationDbContext db) : base(db) { }

    public async Task<List<Schedule>> GetScheduleOnWeekDay(DayOfWeek dayOfWeek) =>
        await _dbSet.Where(s => s.DayOfWeek == dayOfWeek).ToListAsync();
}
