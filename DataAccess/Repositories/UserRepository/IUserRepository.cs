using Core.Data;
using Core.DataAccess;
using Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
