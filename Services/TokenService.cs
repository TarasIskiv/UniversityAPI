using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UniversityAPI.Indentity;
using UniversityAPI.JWT;

namespace UniversityAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IndentityLoginedUser _loginedUser;
        private readonly JWTSettings _jwtSettings;

        public TokenService(IndentityLoginedUser loginedUser,IOptions<JWTSettings> jwtSettings)
        {
            _loginedUser = loginedUser;
            _jwtSettings = jwtSettings.Value;
        }

        public string GetUserToken(Tuple<int, string> result)
        {
            var login = _loginedUser.getLogin(result);
             //sign token here
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, login),
                    new Claim(ClaimTypes.Role, result.Item2),
                    new Claim(ClaimTypes.SerialNumber, result.Item1.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginedUserToken = tokenHandler.WriteToken(token);

            return loginedUserToken;
        }

        public void ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if(tokenHandler.CanReadToken(token))
            {
                try
                {
                    var result = tokenHandler.ReadJwtToken(token);
                }
                catch(ArgumentException)
                {
                    throw new Exception(); // not validate
                }
            }
            else
            {
                throw new Exception(); // not validate
            }
        }
        public int GetLoginedUserId(string token)
        {
            ValidateToken(token);
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = tokenHandler.ReadJwtToken(token).Claims.ToList();
            return Int32.Parse(claims[2].Value);
        }
    }
}