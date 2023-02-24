using AirportSystem.Domain.Entities;
using AirportSystem.Domain.Response;
using AirportSystem.Domain.ViewModels.Flight;

namespace AirportSystem.Services.Interfaces;

public interface IFlightService
{
    Task<IBaseResponse<IEnumerable<Flight>>> GetAll();
    Task<IBaseResponse<Flight>> Get(int id);
    Task<IBaseResponse<bool>> Create(FlightViewModel flightViewModel);
    Task<IBaseResponse<bool>> Edit(int id, FlightViewModel flightViewModel);
    Task<IBaseResponse<bool>> Delete(int id);
}
