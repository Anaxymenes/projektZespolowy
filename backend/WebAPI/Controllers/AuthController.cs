using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        
        public AuthController(IConfiguration config,
            IAuthService authService) {
            
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult LoginAndGetToken([FromBody] LoginDTO loginDTO) {
            IActionResult response = Unauthorized();
            if (loginDTO == null)
                return BadRequest("Błąd przesyłu danych");
            Account user = _authService.GetUserByUserNameOrEmail(loginDTO);
            if (user == null)
                return NotFound("Konto nie istnieje");
            if (!_authService.isValid(user, loginDTO))
                return BadRequest("Błędny username lub password");
            response = Ok(_authService.GetToken(user));
            return response;
        }

        [HttpGet("test")]
        public IActionResult Test([FromHeader] string header) {
            return Ok(header);
        }

        [HttpPost("hashPassword")]
        public IActionResult GetHashedPassword(string password) {
            if(password != null)
                return Ok(_authService.GetHasedPassword(password));
            return BadRequest();
        }

        
    }
}