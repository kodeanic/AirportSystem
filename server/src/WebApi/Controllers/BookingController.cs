using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;
using Infrastructure.IConfiguration;
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

    [HttpGet("/Tickets")]
    public async Task<IActionResult> GetTickets(DateOnly date, string departureCity, string arriveCity)
    {
        var response = await _unitOfWork.Bookings.GetBooking_Date_Way(date, departureCity, arriveCity);
        return Ok(response.Select(booking => _mapper.Map<BookingDto>(booking)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto bookingDto)
    {
        var respose = await _unitOfWork.Schedules.GetScheduleByFlight(bookingDto.Flight);
        if (respose.Count > 0)
        {
            var seats = respose[0].Flight.Airplane.NumberOfSeats;
            DateOnly startDay = new DateOnly(bookingDto.StartDateYear, bookingDto.StartDateMonth, bookingDto.StartDateDay);
            DateOnly endDay = new DateOnly(bookingDto.EndDateYear, bookingDto.EndDateMonth, bookingDto.EndDateDay);

            for (DateOnly i = startDay; i <= endDay;)
            {
                Console.WriteLine(i.ToString());
                foreach (var resp in respose)
                    if (i.DayOfWeek == resp.DayOfWeek)
                    {
                        Booking booking = new Booking()
                        {
                            Schedule = resp,
                            Date = i,
                            FreeSeats = seats
                        };

                        await _unitOfWork.Bookings.Create(booking);
                    }
                i = i.AddDays(1);
            }
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
        return BadRequest();
    }
}
