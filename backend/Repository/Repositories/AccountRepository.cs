using Data.DBModel;
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

        public Account Add(Account entity) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Account Edit(Account entity) {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAll() {
            throw new NotImplementedException();
        }

        public Account GetUserByUsernameOrEmail(string value) {
            try {
                return _context.Account.First(x => x.Email == value);
            }catch(Exception e) {
                return null;
            }
            
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
