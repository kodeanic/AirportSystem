using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Schedule : IBaseEntity
{
    public int Id { get; set; }

    [Required]
    public virtual Flight Flight { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly Time { get; set; }
}
