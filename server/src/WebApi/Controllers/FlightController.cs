using Domain.Entities;
using Infrastructure.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public FlightController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> CreateFlight(Flight flight)
    {
        if (ModelState.IsValid)
        {
            flight.Id = new Random().Next();

            await _unitOfWork.Flights.Create(flight);
            await _unitOfWork.CompleteAsync();

            return new JsonResult("Everything is ok") { StatusCode = 200 };
        }

        return new JsonResult("Something went wrong") { StatusCode = 500 };
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWork.Flights.GetAll());
    }
}
