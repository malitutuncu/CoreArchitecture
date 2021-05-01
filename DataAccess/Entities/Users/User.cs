using Core.Data;
using DataAccess.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Users
{
    public class User : BaseUser, IEntity
    {
        public User()
        {
            CreatedDate = DateTime.Now;
            Roles = new HashSet<Role>();
        }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public ICollection<Role> Roles { get; set; }
    }

}
