using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class HobbyController : Controller {
        private  readonly IHobbyService _hobbyService;

        public HobbyController(IHobbyService hobbyService) {
           _hobbyService = hobbyService;
        }

        [HttpGet("getall")]
        public List<Hobby> GetAll() {
            return _hobbyService.GetAll();
        }

        [HttpGet("get")]
        public Hobby Get(int id)
        {
            return _hobbyService.Get(id);
        }

        [Authorize]
        [HttpPost("add")]
        public IActionResult Add([FromBody]HobbyAdd hobbyDTO)
        {
            if (_hobbyService.Add(hobbyDTO, ClaimsMethods.GetClaimsList(User.Claims)))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("delete")]
        public void Delete(int id, int accountId)
        {
            _hobbyService.Delete(id, accountId);
        }

        [HttpPut("update")]
        public Hobby Edit([FromBody]HobbyEdit hobbyEdit)
        {
            return _hobbyService.Edit(hobbyEdit);
        }
    }
}
