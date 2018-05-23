using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        JWTBearerToken GetToken();
        AccountDTO GetUserByUserNameOrEmail(LoginDTO loginDTO);
        bool isValid(AccountDTO user, LoginDTO loginDTO);
    }
}
