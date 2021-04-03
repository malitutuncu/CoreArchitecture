using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.User
{
    public class UserListItemDto
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdiSoyadi { get; set; }
        public string Email { get; set; }
        public bool Durum { get; set; }
    }
}
