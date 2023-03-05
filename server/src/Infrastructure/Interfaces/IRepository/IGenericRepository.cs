using Domain.Interfaces;

namespace Infrastructure.Interfaces.IRepository;

public interface IGenericRepository<T> where T : class, IBaseEntity
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(int id);

    Task<int> Create(T entity);

    Task Delete(int id);
}
