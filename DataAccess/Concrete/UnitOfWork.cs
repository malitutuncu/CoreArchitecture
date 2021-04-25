using Core.Data;
using Core.DataAccess;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private readonly Dictionary<Type, object> repos;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
            repos = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            var type = typeof(T);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new BaseRepository<T>(_context);
            }

            return (IRepository<T>)repos[type];
        }
            
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
