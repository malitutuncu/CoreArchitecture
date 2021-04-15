using Core.Business;
using DataAccess.Entities.User;
using DTOs.User;

namespace Business.Services.UserService
{
    public interface IUserService : ICrudService<User, UserExtendDto, UserListItemDto, UserListFilterDto>, IService
    {
    }
}