using Domain.Entities;

namespace Infrastructure.Interfaces.IRepository;

public interface IScheduleRepository : IGenericRepository<Schedule>
{
    Task<List<Schedule>> GetByFlight(string flight);

    Task<List<Schedule>> GetByWeekDay(DayOfWeek dayOfWeek);
}
