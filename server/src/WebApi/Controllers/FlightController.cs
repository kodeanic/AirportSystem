using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;
using Infrastructure.Interfaces.IConfiguration;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FlightController(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    [HttpGet]
    public async Task<IActionResult> GetAllFlights()
    {
        var response = await _unitOfWork.Flights.GetAll();
        return Ok(response.Select(flight => _mapper.Map<FlightDto>(flight)));
    }

    [HttpGet("ByName/{name}")]
    public async Task<IActionResult> GetFlightByName(string name) =>
        Ok(_mapper.Map<FlightDto>(await _unitOfWork.Flights.GetByName(name)));

    [HttpGet("ByCompany/{company}")]
    public async Task<IActionResult> GetFlightsByCompany(string company)
    {
        var response = await _unitOfWork.Flights.GetByCompany(company);
        return Ok(response.Select(flight => _mapper.Map<FlightDto>(flight)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateFlight(FlightDto flightDto)
    {
        var airplane = await _unitOfWork.Airplanes.GetByType(flightDto.TypeAirplane);

        if (!ModelState.IsValid || airplane == null)
        {
            return BadRequest();
        }

        Flight flight = _mapper.Map<Flight>(flightDto);
        flight.Airplane = airplane;

        await _unitOfWork.Flights.Create(flight);
        await _unitOfWork.CompleteAsync();

        return Ok(flight.Id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFlight(FlightDto flightDto)
    {
        var flight = await _unitOfWork.Flights.GetByName(flightDto.Name);
        var airplane = await _unitOfWork.Airplanes.GetByType(flightDto.TypeAirplane);

        if (!ModelState.IsValid || flight == null || airplane == null)
        {
            return BadRequest();
        }

        flight.Company = flightDto.Company;
        flight.Airplane = airplane;
        flight.DepartureCity = flightDto.DepartureCity;
        flight.ArriveCity = flightDto.ArriveCity;
        flight.Price = flightDto.Price;

        await _unitOfWork.CompleteAsync();

        return Ok();
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteFlight(string name)
    {
        var flight = await _unitOfWork.Flights.GetByName(name);

        if (flight == null)
        {
            return BadRequest();
        }

        await _unitOfWork.Flights.Delete(flight.Id);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }
}
