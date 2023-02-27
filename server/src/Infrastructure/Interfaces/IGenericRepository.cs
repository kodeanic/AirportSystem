﻿using Domain.Interfaces;

namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : IBaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<int> Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
}
