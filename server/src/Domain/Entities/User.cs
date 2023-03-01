using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : IBaseEntity
{
    public int Id { get; set; }
    
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }

    public int Bonuses { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string Passport { get; set; }

    [Phone]
    public string Number { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
