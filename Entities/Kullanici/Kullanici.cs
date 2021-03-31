using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Kullanici
{
    public class Kullanici : BaseKullanici, IEntity
    {
        public Kullanici()
        {
            CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte[] ParolaSalt { get; set; }
        public byte[] ParolaHash { get; set; }
    }
}
