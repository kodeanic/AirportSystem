using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class AirplaneDto
{
    [Required]
    public string TypeAirplane { get; set; }

    [Range(1, int.MaxValue)]
    public int NumberOfSeats { get; set; }
}
