using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.User
{
    public class User : BaseUser, IEntity
    {
        public User()
        {
            CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte[] ParolaSalt { get; set; }
        public byte[] ParolaHash { get; set; }


    }

}
