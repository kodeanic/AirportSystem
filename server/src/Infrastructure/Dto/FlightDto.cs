using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class FlightDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Company { get; set; }

    [Required]
    public string TypeAirplane { get; set; }

    [Required]
    public string DepartureCity { get; set; }

    [Required]
    public string ArriveCity { get; set; }

    [Range(1, int.MaxValue)]
    public decimal Price { get; set; }
}
