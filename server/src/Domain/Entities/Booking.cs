﻿using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Booking : IBaseEntity
{
    public int Id { get; set; }

    [Required]
    public Schedule Schedule { get; set; }

    public DateOnly Date { get; set; }

    public int FreeSeats { get; set; }

    public ICollection<Order> Orders { get; set; }
}