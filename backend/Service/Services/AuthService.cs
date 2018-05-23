using Data.DTO;
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

        public JWTBearerToken GetToken() {
            return this.JwtTokenBuilder();
        }

        public bool isValid(AccountDTO user, LoginDTO loginDTO) {
            throw new NotImplementedException();
        }

        public AccountDTO GetUserByUserNameOrEmail(LoginDTO loginDTO) {
            throw new NotImplementedException();
        }

        private JWTBearerToken JwtTokenBuilder() {
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Configuration["JWT:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: Configuration["JWT:issuer"],
                audience: Configuration["JWT:audience"],
                signingCredentials: credentials,
                expires: DateTime.Now.AddSeconds(20));
            JWTBearerToken jwTBearerToken = new JWTBearerToken();
            jwTBearerToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
            jwTBearerToken.Expires = token.ValidTo;
            return jwTBearerToken;
        }
    }
}
