using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IAccountHobbyRepository : IRepository<AccountHobby>
    {
        AccountHobby JoinToGroup(AccountHobby accountHobby);
    }
}
