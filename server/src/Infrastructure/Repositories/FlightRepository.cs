using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FlightRepository : GenericRepository<Flight>, IFlightRepository
{
    public FlightRepository(ApplicationDbContext db) : base(db) { }

    public override async Task<IEnumerable<Flight>> GetAll() => await _dbSet.ToListAsync();

    public override async Task<bool> Update(Flight entity)
    {
        try
        {
            var existingFlight = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            if (existingFlight == null)
                return await Create(entity);

            existingFlight.Name = entity.Name;
            existingFlight.Company = entity.Company;
            existingFlight.TypePlane = entity.TypePlane;
            existingFlight.DepartureCity = entity.DepartureCity;
            existingFlight.ArriveCity = entity.ArriveCity;
            existingFlight.Price = entity.Price;

            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var existingFlight = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingFlight == null)
                return false;

            _dbSet.Remove(existingFlight);
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
}
