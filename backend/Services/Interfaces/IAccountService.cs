using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAccountService {
        List<AccountDTO> GetAll();
        bool RegisterAccount(RegisterDTO account);
    }
}
