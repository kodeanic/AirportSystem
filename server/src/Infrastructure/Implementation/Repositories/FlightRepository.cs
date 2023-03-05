using Domain.Entities;
using Infrastructure.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories;

public class FlightRepository : GenericRepository<Flight>, IFlightRepository
{
    public FlightRepository(ApplicationDbContext db) : base(db) { }

    public async Task<Flight> GetByName(string name) =>
        await _dbSet.Where(f => f.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();

    public async Task<List<Flight>> GetByCompany(string company) =>
        await _dbSet.Where(f => f.Company.ToLower() == company.ToLower()).ToListAsync();

    public async Task<List<Flight>> GetByDepartureCity(string departureCity) =>
        await _dbSet.Where(f => f.DepartureCity.ToLower() == departureCity.ToLower()).ToListAsync();

    public async Task<List<Flight>> GetByArriveCity(string arriveCity) =>
        await _dbSet.Where(f => f.ArriveCity.ToLower() == arriveCity.ToLower()).ToListAsync();
}
