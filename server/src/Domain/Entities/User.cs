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

    public virtual UserInformation Information { get; set; }

    public virtual List<CertainFlight> Tickets { get; set; }
}
