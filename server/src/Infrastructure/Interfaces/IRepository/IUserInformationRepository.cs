using Domain.Entities;

namespace Infrastructure.Interfaces.IRepository;

public interface IUserInformationRepository : IGenericRepository<UserInformation>
{
    Task<UserInformation> GetByUser(int id);
}
