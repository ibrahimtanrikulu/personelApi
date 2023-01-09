using Application.Abstract;
using Application.Models.User;
using Domain.Entities.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenService : IToken
    {
        readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserLoginResultModel CreateAccessToken(int minute, AppUser appUser)
        {
            UserLoginResultModel token = new();

            //sifrelenmiş kimliği oluşturuyoruz
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes("ibrahim tanrıkulu"));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //oluşturdugumuz token ayarlarını veriyoruz
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken jwtSecurityTokenjwtSecurityToken = new(
                audience: "www.deneme.com",
                issuer: "www.test.com",
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, appUser.UserName) }
                );

            JwtSecurityTokenHandler jwt = new();
            token.AccessToken = jwt.WriteToken(jwtSecurityTokenjwtSecurityToken);

            return token;
        }
    }
}
