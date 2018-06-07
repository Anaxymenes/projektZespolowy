using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IAccountHobbyRepository : IRepository<AccountHobby>
    {
        bool JoinToGroup(AccountHobby accountHobby);
        bool leaveGroup(AccountHobby accountHobby);
    }
}
