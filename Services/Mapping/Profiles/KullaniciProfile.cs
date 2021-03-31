using AutoMapper;
using Data.Extends;
using Data.TableItem;

namespace Business.Mapping.Profiles
{
    public class KullaniciProfile : Profile
    {
        public KullaniciProfile()
        {
            CreateMap<Kullanici, KullaniciUpsertDto>();
            CreateMap<KullaniciUpsertDto, Kullanici>();

            CreateMap<Kullanici, KullaniciTableItem>();
            CreateMap<KullaniciTableItem, Kullanici>();
        }
    }
}