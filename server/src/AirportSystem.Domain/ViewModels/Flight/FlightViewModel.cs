namespace AirportSystem.Domain.ViewModels.Flight;

public class FlightViewModel
{
    public string Name { get; set; }
    public string Company { get; set; }
    public int TypePlane { get; set; }
    public string DepartureCity { get; set; }
    public string ArriveCity { get; set; }
    public decimal Price { get; set; }
}
