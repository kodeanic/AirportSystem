using Infrastructure.IConfiguration;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using AutoMapper;
using Infrastructure.Dto;

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

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetFlightByName(string name) =>
        Ok(_mapper.Map<FlightDto>(await _unitOfWork.Flights.GetFlightByName(name)));

    [HttpGet("company/{company}")]
    public async Task<IActionResult> GetFlightsByCompany(string company)
    {
        var response = await _unitOfWork.Flights.GetFlightsByCompany(company);
        return Ok(response.Select(flight => _mapper.Map<FlightDto>(flight)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateFlight(FlightDto flightDto)
    {
        var airplaneExist = await _unitOfWork.Airplanes.GetByType(flightDto.TypeAirplane);
        if (ModelState.IsValid && airplaneExist != null)
        {
            Flight flight = _mapper.Map<Flight>(flightDto);
            flight.Airplane = airplaneExist;

            await _unitOfWork.Flights.Create(flight);
            await _unitOfWork.CompleteAsync();

            return Ok(flight.Id);
        }
        return BadRequest();
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteFlight(string name)
    {
        var flightDelete = await _unitOfWork.Flights.GetFlightByName(name);
        if (flightDelete != null)
        {
            await _unitOfWork.Flights.Delete(flightDelete.Id);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
        return BadRequest();
    }
}
