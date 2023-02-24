using AirportSystem.Domain.Entities;
using AirportSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirportSystem.Infrastructure.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly ApplicationDbContext _db;
    public FlightRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<int> NextIndex()
    {
        return await _db.Flight.CountAsync() == 0 ? 1 : await _db.Flight.MaxAsync(x => x.Id) + 1;
    }

    public async Task<bool> Create(Flight entity)
    {
        await _db.Flight.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(Flight entity)
    {
        _db.Flight.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Flight> Get(int id)
    {
        return await _db.Flight.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Flight>> GetAll()
    {
        return await _db.Flight.ToListAsync();
    }

    public async Task<Flight> GetByName(string name)
    {
        return await _db.Flight.FirstOrDefaultAsync(x => x.Name == name);
    }
}
