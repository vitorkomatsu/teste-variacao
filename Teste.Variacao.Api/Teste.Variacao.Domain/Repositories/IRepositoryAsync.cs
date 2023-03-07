﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Variacao.Domain.Repositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        ValueTask<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> Query();

        Task<T> AddAsync(T entity);

        Task<List<T>> AddRangeAsync(List<T> entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}