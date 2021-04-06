using Core.Business;
using Data.User;
using DataAccess.Entities.User;

namespace Business.Services.UserService
{
    public interface IUserService : ICrudService<User, UserExtendDto, UserListItemDto, UserListFilterDto>, IService
    {
    }
}