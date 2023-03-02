using Domain.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.IService
{
    public interface IBookingService
    {
        Task GenerateConcreteFlights(CreateBookingDto bookingDto, List<Schedule> schedule);
    }
}
