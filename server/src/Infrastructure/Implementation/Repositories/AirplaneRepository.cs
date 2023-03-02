using Domain.Entities;
using Infrastructure.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories;

public class AirplaneRepository : GenericRepository<Airplane>, IAirplaneRepository
{
    public AirplaneRepository(ApplicationDbContext db) : base(db) { }

    public async Task<Airplane> GetByType(string type) =>
        await _dbSet.FirstOrDefaultAsync(x => x.TypeAirplane.ToLower() == type.ToLower());
}
