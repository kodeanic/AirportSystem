using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Airplane : IBaseEntity
{
    public int Id { get; set; }

    [Required]
    public string TypeAirplane { get; set; }
    
    public int NumberOfSeats { get; set; }
}
