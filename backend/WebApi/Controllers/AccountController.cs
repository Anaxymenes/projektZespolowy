using Data.DBModels;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller{

        private IAccountService _accountService;

        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }

        [HttpGet]
        public IEnumerable<AccountDTO> GetAll() {
            return _accountService.GetAll();
        }

        [HttpGet]
        [Route("register")]
        public IActionResult RegisterUser ([FromBody] RegisterDTO account) {
            if (account == null)
                return BadRequest();
            if (_accountService.RegisterAccount(account))
                return Ok();
            return BadRequest();
        }
        [HttpGet]
        [Route("{asd}")]
        public List<Account> FindAllAcountsCOntainsString(string  asd) {
            return this._accountService.FindAllUsersContains(asd);
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test() {
            return Ok();
        }
    }
}
