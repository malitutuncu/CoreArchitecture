using AutoMapper;
using Data.Extends;
using Data.TableItem;

namespace Business.Mapping.Profiles
{
    public class KullaniciProfile : Profile
    {
        public KullaniciProfile()
        {
            CreateMap<Kullanici, UserDetailDto>();
            CreateMap<UserDetailDto, Kullanici>();

            CreateMap<Kullanici, UserListItemDto>();
            CreateMap<UserListItemDto, Kullanici>();
        }
    }
}