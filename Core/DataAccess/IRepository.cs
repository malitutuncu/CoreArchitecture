using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(int id);

        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);

        IQueryable<T> GetListQueryable(Expression<Func<T, bool>> expression = null);

        Task<Tuple<IEnumerable<T>, int>> GetPagedListAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> expression = null);

    }
}
