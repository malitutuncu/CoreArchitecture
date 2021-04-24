using Core.Settings;
using Core.Utilities.Security.Token;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Security.Encyption;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security
{
    public class JwtHelper : ITokenHelper
    {
        private TokenSettings _tokenSettings;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            _tokenSettings = configuration.GetSection(nameof(TokenSettings)).Get<TokenSettings>();

        }
        public AccessToken CreateToken(List<Claim> claims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenSettings.Expiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenSettings.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(signingCredentials, claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: claims,
                signingCredentials: signingCredentials
            );
            return jwt;
        }
    }
}
