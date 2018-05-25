using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class HobbyController : Controller {
        private  readonly IHobbyService _hobbyService;

        public HobbyController(IHobbyService hobbyService) {
           _hobbyService = hobbyService;
        }

        [HttpGet("get")]
        public List<Hobby> GetAll() {
            return _hobbyService.GetAll();
        }

        [HttpPost("add")]
        public Hobby Add([FromBody]HobbyDTO hobbyDto)
        {
            return _hobbyService.Add(hobbyDto);
        }

        [HttpDelete("delete")]
        public void Delete(int id, int accountId)
        {
            _hobbyService.Delete(id, accountId);
        }

        [HttpPut("update")]
        public void Edit(string name, string color, int id, int accountId, int newAdminId)
        {
            _hobbyService.Edit(name, color, id, accountId, newAdminId);
        }
    }
}
