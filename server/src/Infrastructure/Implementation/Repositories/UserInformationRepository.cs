using Domain.Entities;
using Infrastructure.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories;

public class UserInformationRepository : GenericRepository<UserInformation>, IUserInformationRepository
{
    public UserInformationRepository(ApplicationDbContext db) : base(db) { }

    public async Task<UserInformation> GetByUser(int id) =>
        await _dbSet.Where(ui => ui.Id == id).FirstOrDefaultAsync();
}
