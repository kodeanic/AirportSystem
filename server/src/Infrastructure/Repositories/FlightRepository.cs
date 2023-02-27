using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FlightRepository : GenericRepository<Flight>, IFlightRepository
{
    public FlightRepository(ApplicationDbContext db) : base(db) { }

    public override async Task Update(Flight entity)
    {
        try
        {
            var existingFlight = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            existingFlight.Name = entity.Name;
            existingFlight.Company = entity.Company;
            
            existingFlight.DepartureCity = entity.DepartureCity;
            existingFlight.ArriveCity = entity.ArriveCity;
            existingFlight.Price = entity.Price;
        }
        catch(Exception ex)
        {
            
        }
    }

    public override async Task Delete(int id)
    {
        try
        {
            var existingFlight = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            _dbSet.Remove(existingFlight);
        }
        catch(Exception ex)
        {

        }
    }
}
