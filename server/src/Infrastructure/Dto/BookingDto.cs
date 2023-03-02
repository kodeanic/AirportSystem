using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class BookingDto
{
    
    public string Flight { get; set; }

    public DateOnly Date { get; set; }

    public int FreeSeats { get; set; }
}
