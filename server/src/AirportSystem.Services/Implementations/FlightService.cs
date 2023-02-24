using AirportSystem.Domain.Entities;
using AirportSystem.Domain.Enums;
using AirportSystem.Domain.Response;
using AirportSystem.Domain.ViewModels.Flight;
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
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            baseResponse.Data = flights;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch { return new BaseResponse<IEnumerable<Flight>>() { StatusCode = StatusCode.InternalServerError }; }
    }

    public async Task<IBaseResponse<Flight>> Get(int id)
    {
        var baseResponse = new BaseResponse<Flight>();
        try
        {
            var flight = await _flightRepository.Get(id);
            if (flight == null)
            {
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }
            baseResponse.Data = flight;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch { return new BaseResponse<Flight>() { StatusCode = StatusCode.InternalServerError }; }
    }

    public async Task<IBaseResponse<bool>> Create(FlightViewModel flightViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var flight = new Flight()
            {
                Id = _flightRepository.NextIndex().Result,
                Name = flightViewModel.Name,
                Company = flightViewModel.Company,
                TypePlane = (TypePlane)flightViewModel.TypePlane,
                DepartureCity = flightViewModel.DepartureCity,
                ArriveCity = flightViewModel.ArriveCity,
                Price = flightViewModel.Price
            };

            await _flightRepository.Create(flight);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch { return new BaseResponse<bool>() { StatusCode = StatusCode.InternalServerError }; }
    }

    public async Task<IBaseResponse<bool>> Edit(int id, FlightViewModel flightViewModel)
    {
        return null;
    }

    public async Task<IBaseResponse<bool>> Delete(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var flight = await _flightRepository.Get(id);
            if (flight == null)
            {
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            await _flightRepository.Delete(flight);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch { return new BaseResponse<bool>() { StatusCode = StatusCode.InternalServerError }; }
    }
}
