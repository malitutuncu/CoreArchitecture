using AutoMapper;
using Business.Concrete;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Entities.Users;
using DTOs.Role;
using DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services.UserService
{
    public class UserService : CrudService<User, UserExtendDto, UserListItemDto, UserListFilterDto>, IUserService
    {
        public override Task<PagedResult<IEnumerable<UserListItemDto>>> GetPagedListAsync(int pageNumber, int pageSize, UserListFilterDto filter)
        {
            Expression<Func<User, bool>> expression = x =>
                x.Username.Contains(filter.KullaniciAdi);

            return BaseGetPagedListAsync(pageNumber, pageSize, expression);
        }

        public Task<IDataResult<RoleExtendDto>> GetRoles(int userId)
        {
            Context
        }
    }
}