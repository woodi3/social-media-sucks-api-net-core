using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly JwtSettings _jwtSettings;
        private JwtSecurityTokenHandler _tokenHandler;
        public TokenHelper(IOptions<JwtSettings> settings, JwtSecurityTokenHandler jwtHandler)
        {
            _jwtSettings = settings.Value;
            _tokenHandler = jwtHandler;
        }

        public string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };
            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }

        public void GetExistingToken()
        {
        }

        
    }
}
