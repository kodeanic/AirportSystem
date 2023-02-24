using AirportSystem.Domain.Entities;
using AirportSystem.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirportSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : Controller
{
    private readonly IFlightService _flightService;
    public FlightController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var response = await _flightService.GetAll();
        if(response.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return Ok(response.Data);
        }

        return BadRequest();
    }

    /*
    [HttpGet("{id}")]
    public async Task<ActionResult<Flight>> Get(int id) => Ok(await _flightRepository.Get(id));

    [HttpPost]
    public async Task<ActionResult> Create(Flight flight) => Ok(await _flightRepository.Create(flight));
    */
}
