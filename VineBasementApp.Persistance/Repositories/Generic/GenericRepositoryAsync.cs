using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VineBasementApp.Persistance.DataAccess;
using VineBasementHelpers.Interfaces;

namespace VineBasementApp.Persistance.Repositories.Generic
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly VineBasementContext _dbContext;

        public GenericRepositoryAsync(VineBasementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id).ConfigureAwait(false) ??
                throw new KeyNotFoundException(string.Format("Nie znaleziono takiego obiektu"));
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> filter,
                                              //int skip = 0,
                                              //int take = int.MaxValue,
                                              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                              Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {

            var _resetSet = filter != null ? _dbContext.Set<T>().AsNoTracking().Where(filter).AsQueryable() : _dbContext.Set<T>().AsNoTracking().AsQueryable();

            if (include != null)
            {
                _resetSet = include(_resetSet);
            }
            if (orderBy != null)
            {
                _resetSet = orderBy(_resetSet).AsQueryable();
            }
            //_resetSet = skip == 0 ? _resetSet.Take(take) : _resetSet.Skip(skip).Take(take);

            return _resetSet.AsQueryable();
        }
    }
}
