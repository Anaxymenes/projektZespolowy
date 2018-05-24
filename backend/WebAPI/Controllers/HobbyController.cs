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

    }
}
