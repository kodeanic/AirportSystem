using Domain.Entities;
using Infrastructure.Interfaces.IRepository;

namespace Infrastructure.Implementation.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext db) : base(db) { }
}
