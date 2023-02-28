using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IScheduleRepository : IGenericRepository<Schedule>
{
    Task<List<Schedule>> GetScheduleOnWeekDay(DayOfWeek dayOfWeek);
}
