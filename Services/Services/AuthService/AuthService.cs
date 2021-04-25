using Business.Concrete;
using Business.Services.UserService;
using Core.DataAccess;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using DataAccess.Entities.User;
using DataAccess.Repositories.UserRepository;
using DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AuthService
{
    public class AuthService : BaseService, IAuthService
    {
        private ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _uow;
        private readonly IRepository<User> _userRepository;
        public AuthService(IUnitOfWork uow)
        {
            _uow = uow;
            _userRepository = _uow.GetRepository<User>();
        }

        public async Task<IDataResult<AccessToken>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.GetAsync(x => x.Email == userLoginDto.UsernameOrEmail);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Pasword  error");
            }

            var accessToken = CreateAccessToken(user);

            return Success(accessToken);
        }

        public async Task<IDataResult<AccessToken>> Register(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userRegisterDto.Email,
                Firstname = userRegisterDto.FirstName,
                Lastname = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };

            await _userRepository.AddAsync(user);
            await _uow.CommitAsync();

            var accessToken = CreateAccessToken(user);

            return Success(accessToken);
        }

        private AccessToken CreateAccessToken(User user)
        {
            var claims = new List<Claim>();
            //todo :baslıca claimler  ekleneecek, digerleri cache mekanızmasından getirilkecek token uzamamsı icin, userId, username, vb
            var accessToken = _tokenHelper.CreateToken(claims);
            return accessToken;
        }
    }
}
