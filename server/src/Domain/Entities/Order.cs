using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Order : IBaseEntity
{
    public int Id { get; set; }

    [Required]
    public Booking Booking { get; set; }

    [Required]
    public User User { get; set; }
}
