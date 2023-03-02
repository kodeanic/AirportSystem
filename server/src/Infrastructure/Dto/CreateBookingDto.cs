using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class CreateBookingDto
{
    [Required]
    public string Flight { get; set; }

    public int EndDateDay { get; set; }

    public int EndDateMonth { get; set; }

    public int EndDateYear { get; set; }

    public int StartDateDay { get; set; }
    
    public int StartDateMonth { get; set; }

    public int StartDateYear { get; set; }
}
