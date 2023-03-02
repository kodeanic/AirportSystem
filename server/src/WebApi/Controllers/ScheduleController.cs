using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;
using Infrastructure.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ScheduleController(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    [HttpGet]
    public async Task<IActionResult> GetAllSchedules()
    {
        var response = await _unitOfWork.Schedules.GetAll();
        return Ok(response.Select(schedule => _mapper.Map<ScheduleDto>(schedule)));
    }

    [HttpGet("ByFlight/{flight}")]
    public async Task<IActionResult> GetScheduleByFlight(string flight)
    {
        var response = await _unitOfWork.Schedules.GetScheduleByFlight(flight);
        return Ok(response.Select(schedule => _mapper.Map<ScheduleDto>(schedule)));
    }

    [HttpGet("ByDay/{day}")]
    public async Task<IActionResult> GetScheduleByWeekDay(DayOfWeek day)
    {
        var response = await _unitOfWork.Schedules.GetScheduleByWeekDay(day);
        return Ok(response.Select(schedule => _mapper.Map<ScheduleDto>(schedule)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateSchedule(ScheduleDto scheduleDto)
    {
        var flightExist = await _unitOfWork.Flights.GetFlightByName(scheduleDto.Flight);
        if (ModelState.IsValid && flightExist != null)
        {
            Schedule schedule = _mapper.Map<Schedule>(scheduleDto);
            schedule.Flight = flightExist;
            schedule.Time = new TimeOnly(scheduleDto.Hours, scheduleDto.Minutes);

            await _unitOfWork.Schedules.Create(schedule);
            await _unitOfWork.CompleteAsync();

            return Ok(schedule.Id);
        }
        return BadRequest();
    }

    [HttpDelete("{flight}")]
    public async Task<IActionResult> DeleteSchedule(string flight)
    {
        var schedulesDelete = await _unitOfWork.Schedules.GetScheduleByFlight(flight);
        if (schedulesDelete.Count > 0)
        {
            foreach (var schedule in schedulesDelete)
            {
                await _unitOfWork.Schedules.Delete(schedule.Id);
                await _unitOfWork.CompleteAsync();
            }
            return Ok();
        }
        return BadRequest();
    }
}
