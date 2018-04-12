using AutoMapper;
using Data.DBModels;
using Data.DTO;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
