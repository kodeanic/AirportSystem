using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class ScheduleDto
{
    [Required]
    public string Flight { get; set; }

    [Range(0, 6)]
    public DayOfWeek DayOfWeek { get; set; }

    [Range(0, 23)]
    public int Hours { get; set; }

    [Range(0, 59)]
    public int Minutes { get; set; }
}
