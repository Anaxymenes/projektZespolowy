using Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IAccountVerificationRepository : IRepository<AccountVerification> {
        AccountVerification GetVerificationCodeForUserByEmail(string email);
    }
}
