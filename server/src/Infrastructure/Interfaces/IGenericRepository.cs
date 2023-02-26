namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<bool> Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
}
