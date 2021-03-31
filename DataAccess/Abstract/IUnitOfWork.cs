using Core.Data;
using Core.DataAccess;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork<T> where  T : class, IEntity
    {
        IRepository<T> Repository { get; }
        Task CommitAsync();
    }
}
