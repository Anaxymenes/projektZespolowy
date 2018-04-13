using AutoMapper;
using Data.DBModels;
using Data.DTO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Services.Services
{
    public class AccountService : IAccountService {
        private IRepository<Account> _repository;

        public AccountService(IRepository<Account> repository) {
            this._repository = repository;
        }

        public List<AccountDTO> GetAll() {
            var accoutList = _repository.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Account, AccountDTO>());
            return Mapper.Map<IQueryable<Account>, List<AccountDTO>>(accoutList);
        }

        public bool RegisterAccount(RegisterDTO registerAccount) {

            return false;
        }

        public byte[] GetSalt() {
            byte[] salt = new byte[32 / 8];
            using(var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }
            string result = Convert.ToBase64String(salt);
            return Encoding.ASCII.GetBytes(result);
        }

        public string GetHashedPassword(string password, byte[] salt) {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password : password,
                    salt : salt,
                    prf : KeyDerivationPrf.HMACSHA1,
                    iterationCount : 10000,
                    numBytesRequested : 256/8
                ));
            return hashedPassword;
        }
    }
}
