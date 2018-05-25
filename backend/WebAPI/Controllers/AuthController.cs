﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Authorization;
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
            var user = _authService.GetUserByUserNameOrEmail(loginDTO);
            if (user == null)
                return NotFound("Konto nie istnieje");
            if (user.Active == false)
                return BadRequest("Konto nie aktywne!");
            if (!_authService.IsValid(user, loginDTO))
                return BadRequest("Błędny username lub password");
            response = Ok(_authService.GetToken(user));
            return response;
        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult Test(string email) {
            //return Ok(_authService.SendVerificationEmail(email));
            return Ok(HttpContext.User.Claims.Select(x => new {
                Type = x.Type,
                Value = x.Value
            }
                ));
        }

        [HttpPost("hashPassword")]
        public IActionResult GetHashedPassword(string password) {
            if(password != null)
                return Ok(_authService.GetHasedPassword(password));
            return BadRequest();
        }

        [HttpPost("register")]
        public IActionResult RegisterNewAccount([FromBody]RegisterAccountDTO registerAccountDTO) {
            if (registerAccountDTO == null)
                return BadRequest("Błąd przesyłu danych");
            if (_authService.ExistUser(registerAccountDTO))
                return BadRequest("Zarejestrowano konto na adres email : " + registerAccountDTO.Email);
            if (!registerAccountDTO.IsValid())
                return BadRequest("Błąd przesyłu danych");
            if (_authService.RegisterUser(registerAccountDTO) == false)
                return BadRequest("Nie mogę dodać użytkownika do bazy. Spróbuj ponownie później.");
            return Ok();
            
        }

        //[Authorize]
        //[HttpPost("sendVerificationEmail")]
        //public IActionResult SendVerificationEmail([FromHeader] string header) {
        //    _authService.SendVerificationEmail(header.Where)
        //}
    }
}