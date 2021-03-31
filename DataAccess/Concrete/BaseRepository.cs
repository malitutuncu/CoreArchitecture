using Core.Data;
using Core.DataAccess;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext context;
        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { context.Remove(entity); });
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().AsQueryable().FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
                return await context.Set<T>().CountAsync();
            else
                return await context.Set<T>().CountAsync(expression);
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await context.Set<T>().ToListAsync() :
                await context.Set<T>().Where(expression).ToListAsync();
        }

        public IQueryable<T> GetListQueryable(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? context.Set<T>().AsQueryable() :
                 context.Set<T>().Where(expression).AsQueryable();
        }

        //todo: tuppledan kurtarmaya bak
        public async Task<Tuple<IEnumerable<T>, int>> GetPagedListAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> expression = null)
        {
            var count = expression == null ? await context.Set<T>().CountAsync() :
             await context.Set<T>().Where(expression).CountAsync();

            var entityList = expression == null ? await context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync() :
                     await context.Set<T>().Where(expression).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

            return new Tuple<IEnumerable<T>, int>(entityList, count);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { context.Update(entity); });
            return entity;
        }
    }
}
