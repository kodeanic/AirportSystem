using AirportSystem.Domain.Entities;
using AirportSystem.Domain.Enums;
using AirportSystem.Domain.Response;
using AirportSystem.Infrastructure.Interfaces;
using AirportSystem.Services.Interfaces;

namespace AirportSystem.Services.Implementations;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository;
    public FlightService(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<IBaseResponse<IEnumerable<Flight>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Flight>>();
        try
        {
            var flights = await _flightRepository.GetAll();
            if (flights.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            baseResponse.Data = flights;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<Flight>>()
            {
                Description = $"[GetAll (Flight)] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError                
            };
        }
    }
}
