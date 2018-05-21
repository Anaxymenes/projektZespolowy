using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Service.Services
{
    public class AuthService : IAuthService {
        private IConfiguration Configuration;

        public AuthService(
            IConfiguration config
            ) {
            Configuration = config;
        }

        public string GetToken() {
            return this.JwtTokenBuilder();
        }

        private string JwtTokenBuilder() {
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Configuration["JWT:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: Configuration["JWT:issuer"],
                audience: Configuration["JWT:audience"],
                signingCredentials: credentials,
                expires: DateTime.Now.AddSeconds(20));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
