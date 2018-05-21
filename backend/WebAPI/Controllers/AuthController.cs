using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IActionResult CreateToken([FromBody] LoginDTO loginDTO) {
            IActionResult response = Unauthorized();
            if (loginDTO != null) {
                response = Ok(new { access_token=_authService.GetToken()});
            }
            return response;
        }

        
    }
}