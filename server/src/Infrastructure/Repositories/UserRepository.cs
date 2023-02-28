using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext db) : base(db) { }
}
