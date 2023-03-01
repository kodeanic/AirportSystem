using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IAirplaneRepository : IGenericRepository<Airplane>
{
    Task<Airplane> GetByType(string type);
}
