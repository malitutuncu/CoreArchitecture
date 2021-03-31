using Core.DataAccess;
using Data.Entity;
using DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class KullaniciRepository : BaseRepository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }
    }
}
