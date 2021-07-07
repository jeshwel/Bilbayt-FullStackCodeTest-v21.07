using FullStackCodeTest.BLL.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullStackCodeTest.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string secret;
        private readonly string expInMins;
        private readonly string issuer;
        private readonly string audience;

        public AuthenticationService(IConfiguration config)
        {
            secret = config["Jwt:Secret"];
            expInMins = config["Jwt:ExpirationInMins"];
            audience = config["Jwt:Audience"];
            issuer = config["Jwt:Issuer"];
        }
        public string GenerateSecurityToken(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    //new Claim(ClaimTypes.Name, name),
                    new Claim("id", id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(expInMins)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
