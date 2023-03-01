using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;
using Infrastructure.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AirplaneController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AirplaneController(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    [HttpGet]
    public async Task<IActionResult> GetAllAirplanes()
    {
        var response = await _unitOfWork.Airplanes.GetAll();
        return Ok(response.Select(airplane => _mapper.Map<AirplaneDto>(airplane)));
    }

    [HttpGet("{type}")]
    public async Task<IActionResult> GetAirplaneByType(string type) =>
        Ok(_mapper.Map<AirplaneDto>(await _unitOfWork.Airplanes.GetByType(type)));

    [HttpPost]
    public async Task<IActionResult> CreateAirplane(AirplaneDto airplaneDto)
    {
        if (ModelState.IsValid)
        {
            Airplane airplane = _mapper.Map<Airplane>(airplaneDto);

            await _unitOfWork.Airplanes.Create(airplane);
            await _unitOfWork.CompleteAsync();

            return Ok(airplane.Id);
        }
        return BadRequest();
    }

    [HttpDelete("{type}")]
    public async Task<IActionResult> DeleteAirplane(string type)
    {
        var airplaneDelete = await _unitOfWork.Airplanes.GetByType(type);
        if (airplaneDelete != null)
        {
            await _unitOfWork.Airplanes.Delete(airplaneDelete.Id);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
        return BadRequest();
    }
}
