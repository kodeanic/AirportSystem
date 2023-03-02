using Domain.Entities;

namespace Infrastructure.Interfaces.IRepository;

public interface IAirplaneRepository : IGenericRepository<Airplane>
{
    Task<Airplane> GetByType(string type);
}
