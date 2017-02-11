using AlexDunn.Org.Definitions.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AlexDunn.Org.Infrastructure.Data.Repositories
{
    public class GenericSqliteRepository<T> : IGenericRepository<T> where T : new()
    {
        protected readonly DbContext _context;
        public GenericSqliteRepository(DbContext context)
        {
            _context = context;
        }
        public virtual async Task InitializeAsync()
        {
            await _context.CreateTableAsync<T>();
        }
        public virtual async Task AddAsync(T entity)
        {
            await _context.Database.InsertOrReplaceAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Database.InsertAllAsync(entities);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(int skip, int take)
        {
            return await _context.Set<T>().Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int skip, int take)
        {
            return await _context.Set<T>().Where(predicate).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            await _context.Database.DeleteAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _context.Database.UpdateAsync(entity);
        }
    }
}
