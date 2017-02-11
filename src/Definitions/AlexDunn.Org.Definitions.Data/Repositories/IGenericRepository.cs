using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Definitions.Data.Repositories
{
    public interface IGenericRepository<T> where T : new()
    {
        Task InitializeAsync();
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IEnumerable<T>> GetAsync(int skip, int take);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int skip, int take);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
    }
}
