using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class CreateBookingDto
{
    [Required]
    public string Flight { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
