using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApplicationDbContext _db;
    protected DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext db) => (_db, _dbSet) = (db, db.Set<T>());

    public virtual async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

    public virtual async Task<T> GetById(int id) => await _dbSet.FindAsync(id);

    public virtual async Task<bool> Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
