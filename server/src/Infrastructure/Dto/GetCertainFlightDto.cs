namespace Infrastructure.Dto;

public class GetCertainFlightDto
{
    public string Flight { get; set; }

    public DateOnly Date { get; set; }

    public int FreeSeats { get; set; }
}
