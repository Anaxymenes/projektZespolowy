﻿using Data.DBModel;
using Data.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class AccountRepository : IAccountRepository {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context) {
            _context = context;
        }

        public bool ActiveAccount(ActivatedAccount activatedAccount) {
            if(_context.AccountVerification.Any(x=> x.Account.Email == activatedAccount.Email && x.CodeVerification == activatedAccount.CodeVerification)) {
                try {
                    _context.Account.First(c => c.Email == activatedAccount.Email).Active = true;
                    var accountVerification = _context.AccountVerification.First(v =>
                    v.Account.Email == activatedAccount.Email &&
                    v.CodeVerification == activatedAccount.CodeVerification);
                    _context.AccountVerification.Remove(accountVerification);
                    _context.SaveChanges();
                    return true;
                }catch(Exception e) {
                    return false;
                }
            }
            return false;
        }

        public Account Add(Account entity) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Account Edit(Account entity) {
            throw new NotImplementedException();
        }

        public bool ExistEmail(string email) {
            return _context.Account.Any(x => x.Email == email);
        }

        public IQueryable<Account> GetAll() {
            throw new NotImplementedException();
        }

        public  Account GetUserByUsernameOrEmail(string value) {
            try {
                var results = _context.Account.AsQueryable()
                    .Include(accountDetails => accountDetails.AccountDetails)
                    .Include(role=>role.AccountRole);
                return results.Where(x => x.Email == value).Single();

            }catch(Exception e) {
                return null;
            }
            
        }

        public void RegisterUser(Account account, AccountDetails accountDetails, AccountVerification accountVerification) {
            _context.Add(account);
            _context.SaveChanges();
            var addedAccount = _context.Account.First(x => x.Email == account.Email);
            accountDetails.AccountId = addedAccount.Id;
            _context.Add(accountDetails);
            accountVerification.AccountId = addedAccount.Id;
            _context.Add(accountVerification);
            _context.SaveChanges();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
