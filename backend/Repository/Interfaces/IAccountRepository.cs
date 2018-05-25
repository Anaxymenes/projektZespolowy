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
    }
}
