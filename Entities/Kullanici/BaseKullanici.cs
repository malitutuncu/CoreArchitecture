using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Kullanici
{
    public class BaseKullanici
    {
        public BaseKullanici()
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
