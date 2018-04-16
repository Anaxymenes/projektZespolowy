using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("user/")]
    public class AccountController : Controller{

        private AccountService _accountService;

        public AccountController(AccountService accountService) {
            _accountService = accountService;
        }
        [HttpGet]
        public List<AccountDTO> GetAll() {
            return _accountService.GetAll();
        }

        [Route("register")]
        public IActionResult RegisterUser ([FromBody] RegisterDTO account) {
            if (account == null)
                return BadRequest();
            if (_accountService.RegisterAccount(account))
                return Ok();
            return BadRequest();
        }

        [Route("test")]
        public IActionResult Test() {
            return Ok();
        }
    }
}
