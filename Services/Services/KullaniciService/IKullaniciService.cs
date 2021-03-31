using Core.Business;
using Data.Extends;
using Data.Kullanici;
using Data.TableItem;

namespace Business.Services.KullaniciService
{
    public interface IKullaniciService : IBaseService<Kullanici, KullaniciUpsertDto, KullaniciTableItem, KullaniciTableFilter>, IService
    {
    }
}