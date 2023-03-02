using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IScheduleRepository : IGenericRepository<Schedule>
{
    Task<List<Schedule>> GetScheduleByFlight(string flight);

    Task<List<Schedule>> GetScheduleByWeekDay(DayOfWeek dayOfWeek);
}
