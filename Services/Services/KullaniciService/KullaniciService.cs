using AutoMapper;
using Business.Services.KullaniciService.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Data.Extends;
using Data.Kullanici;
using Data.TableItem;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services.KullaniciService
{
    public class KullaniciService : BaseService<Kullanici, KullaniciUpsertDto, KullaniciTableItem, KullaniciTableFilter>, IKullaniciService
    {
        public KullaniciService(IUnitOfWork<Kullanici> uow, IMapper mapper) : base(uow, mapper)
        {
        }

        [ValidationAspect(typeof(KullaniciUpsertValidator), Priority = 1)]
        public override Task<IDataResult<KullaniciUpsertDto>> AddAsync(KullaniciUpsertDto extEntity)
        {
            return base.AddAsync(extEntity);
        }

        [ValidationAspect(typeof(KullaniciUpsertValidator), Priority = 1)]
        public override Task<IDataResult<KullaniciUpsertDto>> UpdateAsync(KullaniciUpsertDto extEntity)
        {
            return base.UpdateAsync(extEntity);
        }

        public override Task<PagedResult<IEnumerable<KullaniciTableItem>>> GetPagedListAsync(int pageNumber, int pageSize, KullaniciTableFilter filter)
        {
            Expression<Func<Kullanici, bool>> expression = x =>
                x.KullaniciAdi.Contains(filter.KullaniciAdi);

            return BaseGetPagedListAsync(pageNumber, pageSize, expression);
        }
    }
}