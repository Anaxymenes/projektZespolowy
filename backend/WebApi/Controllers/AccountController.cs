using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class AccountController : Controller{

        private AccountService _accountService;

        public AccountController(AccountService accountService) {
            _accountService = accountService;
        }

        public List<AccountDTO> GetAll() {
            return _accountService.GetAll();
        }
    }
}
