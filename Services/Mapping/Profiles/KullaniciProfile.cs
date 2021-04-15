using AutoMapper;
using DataAccess.Entities.User;
using DTOs.User;

namespace Business.Mapping.Profiles
{
    public class KullaniciProfile : Profile
    {
        public KullaniciProfile()
        {
            CreateMap<User, UserExtendDto>();
            CreateMap<UserExtendDto, User>();

            CreateMap<User, UserListItemDto>();
            CreateMap<UserListItemDto, User>();
        }
    }
}