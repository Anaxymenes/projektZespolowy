using Data.DBModels;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAccountService {
        List<AccountDTO> GetAll();
        bool RegisterAccount(RegisterDTO account);
        Account Login(string username, string passwd);
        Account Get(int id);

    }
}
