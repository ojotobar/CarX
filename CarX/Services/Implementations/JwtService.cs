using CarX.Models;
using CarX.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarX.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration config;

        public JwtService(IConfiguration config)
        {
            this.config = config;
        }
        public string GenerateToken(List<string> roles, AppUser user)
        {
            var claims = new List<Claim>();
            var IdClaim = new Claim(ClaimTypes.NameIdentifier, user.Id);
            claims.Add(IdClaim);

            var roleClaim = new Claim(ClaimTypes.Role, roles[0]);
            claims.Add(roleClaim);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTKey"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(1)
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
