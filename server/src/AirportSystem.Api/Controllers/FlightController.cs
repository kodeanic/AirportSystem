using AirportSystem.Domain.ViewModels.Flight;
using AirportSystem.Services.Interfaces;
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
        switch (response.StatusCode)
        {
            case Domain.Enums.StatusCode.OK:
                return Ok(response.Data);
            case Domain.Enums.StatusCode.NotFound:
                return NotFound();
            default:
                return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var response = await _flightService.Get(id);
        switch (response.StatusCode)
        {
            case Domain.Enums.StatusCode.OK:
                return Ok(response.Data);
            case Domain.Enums.StatusCode.NotFound:
                return NotFound();
            default:
                return BadRequest();
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create(FlightViewModel flightViewModel)
    {
        if(ModelState.IsValid)
        {
            var response = await _flightService.Create(flightViewModel);
            switch (response.StatusCode)
            {
                case Domain.Enums.StatusCode.OK:
                    return Ok(response.Data);
                default:
                    return BadRequest();
            }
        }
        return BadRequest();
    }

    [HttpPut]
    public async Task<ActionResult> Edit(FlightViewModel flightViewModel)
    {
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var response = await _flightService.Delete(id);
        switch (response.StatusCode)
        {
            case Domain.Enums.StatusCode.OK:
                return Ok(response.Data);
            case Domain.Enums.StatusCode.NotFound:
                return NotFound();
            default:
                return BadRequest();
        }
    }
}
