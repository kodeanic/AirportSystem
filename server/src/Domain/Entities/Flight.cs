using Domain.Enums;

namespace Domain.Entities;

public class Flight
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public TypePlane TypePlane { get; set; }
    public string DepartureCity { get; set; }
    public string ArriveCity { get; set; }
    public decimal Price { get; set; }
}
