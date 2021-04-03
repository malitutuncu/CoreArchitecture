using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.User
{
    public class BaseUser
    {
        public BaseUser()
        {
            Durum = true;
        }
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdiSoyadi { get; set; }
        public string Email { get; set; }
        public bool Durum { get; set; }
    }
}
