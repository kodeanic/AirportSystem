using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class AirplaneRepository : GenericRepository<Airplane>, IAirplaneRepository
{
    public AirplaneRepository(ApplicationDbContext db) : base(db) { }


}
