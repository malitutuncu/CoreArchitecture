using Data.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.User
{
    public class UserListFilterDto : ListFilter
    {
        public string KullaniciAdi { get; set; }
    }
}
