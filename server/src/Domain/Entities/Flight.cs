using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Flight : IBaseEntity
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Company { get; set; }

    [Required]
    public Airplane Airplane { get; set; }

    [Required]
    public string DepartureCity { get; set; }

    [Required]
    public string ArriveCity { get; set; }

    public decimal Price { get; set; }

    public ICollection<Schedule> Timetable { get; set; }
}
