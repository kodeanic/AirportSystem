using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;
using Infrastructure.Interfaces.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingController(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var response = await _unitOfWork.Bookings.GetAll();
        return Ok(response.Select(booking => _mapper.Map<BookingDto>(booking)));
    }

    [HttpGet("Tickets")]
    public async Task<IActionResult> GetTickets(DateOnly date, string departureCity, string arriveCity)
    {
        var response = await _unitOfWork.Bookings.GetBooking_Date_Way(date, departureCity, arriveCity);
        return Ok(response.Select(booking => _mapper.Map<BookingDto>(booking)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto bookingDto)
    {
        var schedules = await _unitOfWork.Schedules.GetByFlight(bookingDto.Flight);

        if(schedules.Count == 0)
        {
            return BadRequest();
        }

        var seats = schedules.First().Flight.Airplane.NumberOfSeats;

        var bookings = new List<Booking>();
        var datesInterval = new List<DateTime>();

        for (var date = bookingDto.StartDate; date <= bookingDto.EndDate; date = date.AddDays(1)) 
        {
            datesInterval.Add(date);
        }

        foreach(var date in datesInterval)
        {
            foreach(var schedule in schedules) 
            { 
                if(date.DayOfWeek == schedule.DayOfWeek)
                {
                    bookings.Add(new Booking()
                    {
                        Schedule = schedule,
                        Date = DateOnly.FromDateTime(date),
                        FreeSeats = seats
                    });
                }
            }
        }

        await _unitOfWork.Bookings.CreateRange(bookings);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }
}
