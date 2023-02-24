using AirportSystem.Domain.Entities;
using AirportSystem.Domain.Response;

namespace AirportSystem.Services.Interfaces;

public interface IFlightService
{
    Task<IBaseResponse<IEnumerable<Flight>>> GetAll();
}
