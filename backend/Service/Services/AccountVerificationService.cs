using Data.DBModel;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class AccountVerificationService : IAccountVerificationService{

        private readonly IAccountVerificationRepository _accountVerificationRepository;

        public AccountVerificationService(IAccountVerificationRepository accountVerificationRepository) {
            _accountVerificationRepository = accountVerificationRepository;
        }

        public AccountVerification GetVerificationCodeForUserByEmail(string email) {
            return _accountVerificationRepository.GetVerificationCodeForUserByEmail(email);
        }
    }
}
