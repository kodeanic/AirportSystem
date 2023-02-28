using Domain.Entities;
using Infrastructure.IConfiguration;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ModelViews;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AirplaneController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AirplaneController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Airplanes.GetAll());
    /*
    {
        List<Airplane> airplanes = (List<Airplane>)await _unitOfWork.Airplanes.GetAll();
        List<AirplaneModelView> response = new List<AirplaneModelView>();
        foreach (var airplane in airplanes)
        {
            response.Add(new AirplaneModelView()
            {
                TypeAirplane = airplane.TypeAirplane,
                NumberOfSeats = airplane.NumberOfSeats
            });
        }
        return Ok(response);
    }
    */

    [HttpPost]
    public async Task<IActionResult> CreateAirplane(AirplaneModelView airplaneModelView)
    {
        if (ModelState.IsValid)
        {
            Airplane airplane = new Airplane()
            {
                TypeAirplane = airplaneModelView.TypeAirplane,
                NumberOfSeats = airplaneModelView.NumberOfSeats
            };

            await _unitOfWork.Airplanes.Create(airplane);

            //await _unitOfWork.

            await _unitOfWork.CompleteAsync();

            return Ok(airplane.Id);
        }

        return BadRequest();
    }
}
