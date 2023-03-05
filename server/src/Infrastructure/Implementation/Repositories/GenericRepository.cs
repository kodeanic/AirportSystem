using Domain.Interfaces;
using Infrastructure.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
{
    protected ApplicationDbContext _db;

    protected DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext db) => (_db, _dbSet) = (db, db.Set<T>());

    public virtual async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

    public virtual async Task<T> GetById(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public virtual async Task<int> Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity.Id;
    }

    public virtual async Task Delete(int id) => _dbSet.Remove(await _dbSet.Where(x => x.Id == id).FirstAsync());
}
