using Domain.Entities;
using Infrastructure.Dto;

namespace Infrastructure.Interfaces.IService;

public interface ICertainFlightService
{
    Task GenerateConcreteFlights(CreateCertainFlightDto certainFlightDto, List<Schedule> schedule);
}
