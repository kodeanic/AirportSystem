using Domain.Entities;
using Infrastructure.Interfaces.IRepository;

namespace Infrastructure.Implementation.Repositories;

public class UserInformationRepository : GenericRepository<UserInformation>, IUserInformationRepository
{
    public UserInformationRepository(ApplicationDbContext db) : base(db) { }
}
