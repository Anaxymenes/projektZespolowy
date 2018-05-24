using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service.Services
{
    public class AuthService : IAuthService {
        private IConfiguration Configuration;
        private readonly IAccountRepository _accountRepository;

        public AuthService(
            IConfiguration config,
            IAccountRepository accountRepository
            ) {
            Configuration = config;
            _accountRepository = accountRepository;
        }

        public JWTBearerToken GetToken(Account user) {
            return this.JwtTokenBuilder(user);
        }

        public bool isValid(Account user, LoginDTO loginDTO) {
            return user.Password.Equals(this.GetHashedPassword(loginDTO.password, Encoding.UTF8.GetBytes(user.PasswordSalt)));
        }

        public Account GetUserByUserNameOrEmail(LoginDTO loginDTO) {
            return _accountRepository.GetUserByUsernameOrEmail(loginDTO.username);
        }

        private JWTBearerToken JwtTokenBuilder(Account user) {
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Configuration["JWT:key"]));
            var claims = new[] {
                new Claim(ClaimTypes.Name,  user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: Configuration["JWT:issuer"],
                audience: Configuration["JWT:audience"],
                signingCredentials: credentials,
                claims:claims,
                expires: DateTime.Now.AddSeconds(20));
            JWTBearerToken jwTBearerToken = new JWTBearerToken();
            jwTBearerToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
            jwTBearerToken.Expires = token.ValidTo;
            return jwTBearerToken;
        }

        public byte[] GetSalt() {
            byte[] salt = new byte[32 / 8];
            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }
            string result = Convert.ToBase64String(salt);
            return Encoding.ASCII.GetBytes(result);
        }

        public string GetHashedPassword(string password, byte[] salt) {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                ));
            return hashedPassword;
        }

    }
}
