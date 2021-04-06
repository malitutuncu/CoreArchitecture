using AutoMapper;
using Data.User;
using System.Collections.Generic;

namespace Business.Mapping.Profiles
{
    public static class KullaniciMappingExtension
    {
        public static UserExtendDto MapToKullaniciExt(this User kullanici, IMapper mapper)
        {
            return mapper.Map<UserExtendDto>(kullanici);
        }

        public static IEnumerable<UserListItemDto> MapToKullaniciTableItemList(this IEnumerable<User> kullaniciList, IMapper mapper)
        {
            return mapper.Map<IEnumerable<UserListItemDto>>(kullaniciList);
        }
    }
}