using Data.DBModel;
using Data.DTO;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class AccountHobbyService : IAccountHobbyService
    {
        private readonly IAccountHobbyRepository _accountHobbyRepository;

        public AccountHobbyService(IAccountHobbyRepository accountHobbyRepository)
        {
            _accountHobbyRepository = accountHobbyRepository;
        }

        public bool JoinToGroup(int hobbyId, List<ClaimDTO> claimsList)
        {
            int authorId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
            AccountHobby accountHobby = new AccountHobby()
            {
                AccountId = authorId,
                HobbyId = hobbyId
            };
            if (_accountHobbyRepository.JoinToGroup(accountHobby) != null)
                return true;
            return false;
        }
    }
}
