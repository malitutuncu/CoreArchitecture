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
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> repos;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
            repos = new Dictionary<Type, object>();
        }

        public IRepository<T> Repository => new BaseRepository<T>(_context);

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
