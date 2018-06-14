using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IAccountRepository : IRepository<Account> {
        Account GetUserByUsernameOrEmail(string value);
        bool ExistEmail(string email);
        void RegisterUser(Account account, AccountDetails accountDetails, AccountVerification accountVerification);
        bool ActiveAccount(ActivatedAccount activatedAccount);
        void UpdateAvatar(string path, int accountId);
        IQueryable<Account> GetByIdEXT(int id);
        Account GetById(int id);
        void Update(Account user);
    }
}
