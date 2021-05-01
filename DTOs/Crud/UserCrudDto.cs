using DataAccess.Entities.Users;
using DTOs.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Crud
{
    public class UserExtendDto : BaseUser
    {

    }

    public class UserListFilterDto : ListFilter
    {
        public string KullaniciAdi { get; set; }
    }

    public class UserListItemDto
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdiSoyadi { get; set; }
        public string Email { get; set; }
        public bool Durum { get; set; }
    }
}
