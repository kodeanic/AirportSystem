using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;

public class UserDto
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }
}
