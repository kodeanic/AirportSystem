using Domain.Entities;

namespace Infrastructure.Interfaces.IRepository;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByLogin(string login);
}
