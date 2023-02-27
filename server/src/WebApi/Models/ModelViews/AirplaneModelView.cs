using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ModelViews;

public class AirplaneModelView
{
    [Required]
    public string TypeAirplane { get; set; }

    public int NumberOfSeats { get; set; }
}
