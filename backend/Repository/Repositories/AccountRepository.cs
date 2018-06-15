using Data.DBModel;
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

        public IQueryable<Account> FindAccountsByValue(string value) {
            if(_context.Account.Any(x=>x.AccountDetails.LastName.Contains(value)) ||
               _context.Account.Any(x => x.AccountDetails.Name.Contains(value)) ||
               _context.Account.Any(x => x.Email.Contains(value)))
                return _context.Account.Where(
                            x => x.AccountDetails.LastName.Contains(value) ||
                            x.AccountDetails.Name.Contains(value) ||
                            x.Email.Contains(value))
                     .Include(x => x.AccountDetails)
                     .Include(x => x.AccountRole).AsQueryable();
            return null;
        }

        public IQueryable<Account> GetAll() {
            throw new NotImplementedException();
        }

        public Account GetById(int id)
        {
            if (_context.Account.Any(x => x.Id == id))
            {
                return _context.Account.First(x => x.Id == id);
            }
            return null;
        }

        public  IQueryable<Account> GetByIdEXT(int id) {
            if (_context.Account.Any(x => x.Id == id))
            {
                var users = _context.Account
                    .Include(d => d.AccountDetails)
                    .Include(a => a.AccountRole);
                return users.Where(x => x.Id == id).Take(1);
            }
            return null;

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
            _context.SaveChanges();
        }

        public void SaveToken(AccountToken accToken)
        {
            try
            {
                _context.AccountToken.Add(accToken);
                _context.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

        public void Update(Account user) {
            try {
                _context.Account.Update(user);
                _context.SaveChanges();
            }catch(Exception e) {
                throw e;
            }
        }

        public void UpdateAvatar(string path, int accountId) {
            try {
                var accountDetails = _context.AccountDetails.First(x => x.AccountId == accountId);
                accountDetails.Avatar = path;
                _context.AccountDetails.Update(accountDetails);
                _context.SaveChanges();
            }catch(Exception e) {
                throw e;
            }
        }
    }
}
