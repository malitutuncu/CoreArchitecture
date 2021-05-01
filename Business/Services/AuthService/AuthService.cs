using Business.Concrete;
using Business.Services.UserService;
using Core.Constants;
using Core.CrossCuttings.Caching;
using Core.DataAccess;
using Core.Helpers.Caching;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using DataAccess.Entities.Users;
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
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _uow;
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<User> _userRepository;
        public AuthService(IUnitOfWork uow, ITokenHelper tokenHelper, ICacheManager cacheManager)
        {
            _uow = uow;
            _tokenHelper = tokenHelper;
            _cacheManager = cacheManager;
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
            //_userService.GetRoles();
            _cacheManager.Add(CacheKeyHelper.GetKeyUserRoles(user.Id),"asd");

            return Success(accessToken);
        }

        private AccessToken CreateAccessToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(CustomClaimTypes.UserId, user.Id.ToString()),
                new Claim(CustomClaimTypes.Email , user.Email),
                new Claim(CustomClaimTypes.Username, user.Username),
            };

            var accessToken = _tokenHelper.CreateToken(claims);
            return accessToken;
        }
    }
}
