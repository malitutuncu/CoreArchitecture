using Core.Business;
using Core.Utilities.Results;
using DataAccess.Entities.Users;
using DTOs.Role;
using DTOs.User;
using System.Threading.Tasks;

namespace Business.Services.UserService
{
    public interface IUserService : ICrudService<User, UserExtendDto, UserListItemDto, UserListFilterDto>, IService
    {
        Task<IDataResult<RoleExtendDto>> GetRoles(int userId);
    }
}