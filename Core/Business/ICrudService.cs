using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface ICrudService<TEntity, TAddOrEdit, TTableItem, TListFilter>  
    {
        Task<IDataResult<TAddOrEdit>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IDataResult<TAddOrEdit>> GetByIdAsync(int id);
        Task<IDataResult<int>> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IDataResult<TAddOrEdit>> AddAsync(TAddOrEdit extEntity);
        Task<IDataResult<TAddOrEdit>> UpdateAsync(TAddOrEdit extEntity);
        Task<IResult> DeleteAsync(TAddOrEdit extEntity);
        Task<IDataResult<IEnumerable<TTableItem>>> GetListAsync(TListFilter filter);
        Task<PagedResult<IEnumerable<TTableItem>>> GetPagedListAsync(int pageNumber, int pageSize, TListFilter filter);
    }
}
