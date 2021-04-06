using AutoMapper;
using Business.Concrete;
using Business.Services.KullaniciService.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Data.User;
using DataAccess.Abstract;
using DataAccess.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services.UserService
{
    public class UserService : CrudService<User, UserExtendDto, UserListItemDto, UserListFilterDto>, IUserService
    {
        public UserService(IUnitOfWork<User> uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override Task<PagedResult<IEnumerable<UserListItemDto>>> GetPagedListAsync(int pageNumber, int pageSize, UserListFilterDto filter)
        {
            Expression<Func<User, bool>> expression = x =>
                x.KullaniciAdi.Contains(filter.KullaniciAdi);

            return BaseGetPagedListAsync(pageNumber, pageSize, expression);
        }
    }
}