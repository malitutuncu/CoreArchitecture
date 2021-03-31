using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IBaseService<TEntity, TExtend, TTableItem, TListFilter>  
    {
        Task<IDataResult<TExtend>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IDataResult<TExtend>> GetByIdAsync(int id);
        Task<IDataResult<int>> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IDataResult<TExtend>> AddAsync(TExtend extEntity);
        Task<IDataResult<TExtend>> UpdateAsync(TExtend extEntity);
        Task<IResult> DeleteAsync(TExtend extEntity);
        Task<IDataResult<IEnumerable<TTableItem>>> GetListAsync(TListFilter filter);
        Task<PagedResult<IEnumerable<TTableItem>>> GetPagedListAsync(int pageNumber, int pageSize, TListFilter filter);
    }
}
