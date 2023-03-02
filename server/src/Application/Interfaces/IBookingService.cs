namespace Application.Interfaces;

public interface IBookingService
{
    Task GenerateConcreteFlights(CreateBookingDto bookingDto, List<Schedule> schedule);
}
