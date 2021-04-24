using Business.Concrete;
using Business.Services.UserService;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Token;
using DataAccess.Entities.User;
using DataAccess.Repositories.UserRepository;
using DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AuthService
{
    public class AuthService : BaseService, IAuthService
    {
        private IUserRepository _userRepository;
        private ITokenHelper _tokenHelper;
        public AuthService()
        {

        }
        public Task<IDataResult<AccessToken>> Login(UserLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AccessToken>> Register(UserRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Firstname = userForRegisterDto.FirstName,
                Lastname = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };
            await _userService.AddAsync(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }
    }
}
