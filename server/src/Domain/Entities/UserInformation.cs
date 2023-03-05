using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class UserInformation : IBaseEntity
{
    [ForeignKey("User")]
    public int Id { get; set; }

    public virtual User User { get; set; }

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
