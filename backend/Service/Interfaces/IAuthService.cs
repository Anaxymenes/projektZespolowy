using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        JWTBearerToken GetToken(Account user);
        Account GetUserByUserNameOrEmail(LoginDTO loginDTO);
        bool isValid(Account user, LoginDTO loginDTO);
        HashedPassword GetHasedPassword(string password);
    }
}
