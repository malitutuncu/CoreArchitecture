using DataAccess.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Roles
{
    public class Role : BaseRole
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public ICollection<User> Users { get; set; }
    }
}
