using WebApi.Models.ModelViews;
using Infrastructure.IConfiguration;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public FlightController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWork.Flights.GetAll());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _unitOfWork.Flights.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateFlight(FlightModelView flightModelView)
    {
        if (ModelState.IsValid)
        {
            Flight flight = new Flight
            {
                Name = flightModelView.Name,
                Company = flightModelView.Company,
                
                DepartureCity = flightModelView.DepartureCity,
                ArriveCity = flightModelView.ArriveCity,
                Price = flightModelView.Price
            };

            int idResponse = await _unitOfWork.Flights.Create(flight);
            await _unitOfWork.CompleteAsync();

            return Ok(idResponse);
        }

        return BadRequest();
    }
}
