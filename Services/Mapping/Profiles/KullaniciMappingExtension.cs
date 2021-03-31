using AutoMapper;
using Data.Extends;
using Data.TableItem;
using System.Collections.Generic;

namespace Business.Mapping.Profiles
{
    public static class KullaniciMappingExtension
    {
        public static KullaniciUpsertDto MapToKullaniciExt(this Kullanici kullanici, IMapper mapper)
        {
            return mapper.Map<KullaniciUpsertDto>(kullanici);
        }

        public static IEnumerable<KullaniciTableItem> MapToKullaniciTableItemList(this IEnumerable<Kullanici> kullaniciList, IMapper mapper)
        {
            return mapper.Map<IEnumerable<KullaniciTableItem>>(kullaniciList);
        }
    }
}