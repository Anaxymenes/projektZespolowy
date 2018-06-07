using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Examples;
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
        [HttpGet("getall/{countOfItem}/{page}")]
        public IActionResult GetAllPagination(int countOfItem, int page) {
            try {
                return Ok(_hobbyService.GetAllPagination(countOfItem, page, ClaimsMethods.GetClaimsList(User.Claims)));
            }catch(Exception e) {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        public Hobby Get(int id)
        {
            return _hobbyService.Get(id);
        }

        [Authorize]
        [HttpPost("add")]
        public IActionResult Add([FromBody]HobbyAdd hobbyDTO) { 
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
        public IActionResult Edit([FromBody]HobbyEdit hobbyEdit)
        {
            var result = _hobbyService.Edit(hobbyEdit, ClaimsMethods.GetClaimsList(User.Claims));
            if (result != null)
                return Ok();
            return BadRequest("Błąd podczas edytowania danych");
        }

        [Authorize]
        [HttpPost("upload")]
        [AddSwaggerFileUploadButton]
        public async Task<IActionResult> UloadFile(IFormFile file) {
            string result = await _hobbyService.UploadFile(file);
            if (result != "")
                return Ok(result);
            return BadRequest();
        }

        [Authorize]
        [HttpGet("getAllMyHobbies")]
        public IActionResult GetAllHobbiesByAccountId() {
            var result = _hobbyService.GetAllHobbiesByAccountId(ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
