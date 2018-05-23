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

        public IQueryable<Account> GetAll() {
            throw new NotImplementedException();
        }

        public Account GetUserByUsernameOrEmail(string value) {
            return _context.Account.First(x => x.Username == value || x.Email == value);
        }
    }
}
