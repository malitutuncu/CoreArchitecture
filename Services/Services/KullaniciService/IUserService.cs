using Core.Business;
using Data.User;
using DataAccess.Entities.User;

namespace Business.Services.KullaniciService
{
    public interface IUserService : ICrudService<User, UserDetailDto, UserListItemDto, UserListFilterDto>, IService
    {
    }
}