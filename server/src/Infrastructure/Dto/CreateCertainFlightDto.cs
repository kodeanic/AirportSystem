using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class CreateCertainFlightDto
{
    [Required]
    public string Flight { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
