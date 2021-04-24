using Core.Utilities.Results;
using Core.Utilities.Security.Token;
using DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AuthService
{
    public interface IAuthService
    {
        Task<IDataResult<AccessToken>> Register(UserRegisterDto userForRegisterDto, string password);
        Task<IDataResult<AccessToken>> Login(UserLoginDto userForLoginDto);
    }
}
