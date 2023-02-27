using Domain.Interfaces;

namespace Domain.Entities;

public class Schedule : IBaseEntity
{
    public int Id { get; set; }

    public Flight flight { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly Time { get; set; }
}
