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
using System.Net;
using System.Net.Mail;
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
            return user.Password.Equals(this.GetHashedPassword(loginDTO.Password, Encoding.UTF8.GetBytes(user.PasswordSalt)));
        }

        public Account GetUserByUserNameOrEmail(LoginDTO loginDTO) {
            return _accountRepository.GetUserByUsernameOrEmail(loginDTO.Email);
        }

        private JWTBearerToken JwtTokenBuilder(Account user) {
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Configuration["JWT:key"]));
            var claims = new[] {
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

        protected byte[] GetSalt() {
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }
            string result = Convert.ToBase64String(salt);
            return Encoding.ASCII.GetBytes(result);
        }
        protected string EncodeByteToString(byte[] value) {
            return Encoding.UTF8.GetString(value);
        }

        protected string GetHashedPassword(string password, byte[] salt) {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                ));
            return hashedPassword;
        }

        public HashedPassword GetHasedPassword(string password) {
            byte[] salt = this.GetSalt();
            HashedPassword result = new HashedPassword();
            result.Password = password;
            result.Salt = Encoding.UTF8.GetString(salt);
            result.PasswordHashed = this.GetHashedPassword(password, salt);

            return result;
        }

        public bool ExistUser(RegisterAccountDTO registerAccountDTO) {
            return _accountRepository.ExistEmail(registerAccountDTO.Email);
        }

        public bool RegisterUser(RegisterAccountDTO registerAccountDTO) {
            byte[] salt = this.GetSalt();
            Account account = new Account() {
                Email = registerAccountDTO.Email,
                Active = false,
                RoleId = 2,
                Password = this.GetHashedPassword(registerAccountDTO.Password, salt),
                PasswordSalt = this.EncodeByteToString(salt)
            };

            AccountDetails accountDetails = new AccountDetails() {
                Avatar = "personAvatar.png",
                BirthDate = registerAccountDTO.BirthDate,
                LastName = registerAccountDTO.LastName,
                Name = registerAccountDTO.FirstName
            };

            return false;
        }

        public bool SendVerificationEmail(string email) {
            try {
                using (var client = new SmtpClient() {
                    Host = "smtp.gmail.com",
                    Port = 587, // Port 
                    EnableSsl = true,
                    Credentials = new NetworkCredential("adm.ehobby@gmail.com", "3Hobby1234")
                }) {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("adm.ehobby@gmail.com");
                    mailMessage.To.Add(email);
                    mailMessage.Body = "Only test";
                    mailMessage.Subject = "eHobby Account Verification";
                    client.Send(mailMessage);
                    return true;
                }  
            }catch(Exception e) {
                return false;
            }
        }
    }
}
