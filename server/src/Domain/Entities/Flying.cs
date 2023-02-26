namespace Domain.Entities;

public class Flying
{
    public string Name { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeOnly Time { get; set; }
    public int FreePlaces { get; set; }

}
