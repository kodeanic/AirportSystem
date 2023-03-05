using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class CertainFlight : IBaseEntity
{
    public int Id { get; set; }

    [Required]
    public virtual Schedule Schedule { get; set; }

    public DateOnly Date { get; set; }

    public int FreeSeats { get; set; }

    public virtual List<User> Passengers { get; set; }
}
