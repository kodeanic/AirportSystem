using AirportSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Infrastructure.Interfaces;

public interface IFlightRepository : IBaseRepository<Flight>
{
    Task<Flight> GetByName(string name);
}
