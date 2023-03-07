using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Variacao.Domain.Repositories;
using Teste.Variacao.Infrastructure.DbContexts;

namespace Teste.Variacao.Infrastructure.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Query() => _dbContext.Set<T>().AsNoTracking().AsQueryable();

        protected virtual IQueryable<T> TrackedQuery() => _dbContext.Set<T>().AsQueryable();

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public virtual async Task<List<T>> AddRangeAsync(List<T> entity)
        {
            await _dbContext.Set<T>().AddRangeAsync(entity);
            return entity;
        }

        public virtual Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public virtual ValueTask<T> GetByIdAsync(Guid id) => _dbContext.Set<T>().FindAsync(id);        

        public virtual Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
    }
}