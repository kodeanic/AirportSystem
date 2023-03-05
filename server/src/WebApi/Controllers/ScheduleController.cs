using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;
using Infrastructure.Interfaces.IConfiguration;
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
        var response = await _unitOfWork.Schedules.GetByFlight(flight);
        return Ok(response.Select(schedule => _mapper.Map<ScheduleDto>(schedule)));
    }

    [HttpGet("ByDay/{day}")]
    public async Task<IActionResult> GetScheduleByWeekDay(DayOfWeek day)
    {
        var response = await _unitOfWork.Schedules.GetByWeekDay(day);
        return Ok(response.Select(schedule => _mapper.Map<ScheduleDto>(schedule)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateSchedule(ScheduleDto scheduleDto)
    {
        var flight = await _unitOfWork.Flights.GetByName(scheduleDto.Flight);

        if (!ModelState.IsValid || flight == null)
        {
            return BadRequest();
        }

        Schedule schedule = _mapper.Map<Schedule>(scheduleDto);
        schedule.Flight = flight;
        schedule.Time = new TimeOnly(scheduleDto.Hours, scheduleDto.Minutes);

        await _unitOfWork.Schedules.Create(schedule);
        await _unitOfWork.CompleteAsync();

        return Ok(schedule.Id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSchedule(ScheduleDto scheduleDto)
    {
        var schedule = (await _unitOfWork.Schedules.GetByFlight(scheduleDto.Flight))
            .Where(s => s.DayOfWeek == scheduleDto.DayOfWeek).FirstOrDefault();

        if (!ModelState.IsValid || schedule == null)
        {
            return BadRequest();
        }

        schedule.Time = new TimeOnly(scheduleDto.Hours, scheduleDto.Minutes);

        await _unitOfWork.CompleteAsync();

        return Ok();
    }

    [HttpDelete("{flight}")]
    public async Task<IActionResult> DeleteSchedule(string flight)
    {
        var schedulesDelete = await _unitOfWork.Schedules.GetByFlight(flight);

        if (schedulesDelete.Count == 0)
        {
            return BadRequest();
        }

        foreach (var schedule in schedulesDelete)
        {
            await _unitOfWork.Schedules.Delete(schedule.Id);
        }

        await _unitOfWork.CompleteAsync();

        return Ok();
    }
}
