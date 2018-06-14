using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Examples;
using WebAPI.Utils;

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
            if (!_authService.IsValid(user, loginDTO) || user.Active == false || user == null)
                return BadRequest("Wystąpił błąd. Użytkonik nie istnieje, nie jest aktywny bądź błędne dane logowania");
            response = Ok(_authService.GetToken(user));
            return response;
        }

        [HttpPost("hashPassword")]
        public IActionResult GetHashedPassword(string password) {
            if(password != null)
                return Ok(_authService.GetHasedPassword(password));
            return BadRequest();
        }

        [HttpPost("register")]
        public IActionResult RegisterNewAccount([FromBody]RegisterAccountDTO registerAccountDTO) {
            if (registerAccountDTO == null || !registerAccountDTO.IsValid() ||
                _authService.ExistUser(registerAccountDTO) || _authService.RegisterUser(registerAccountDTO) == false)
                return BadRequest("Nie można zarejestrować użytkownika");
            return Ok();
            
        }

        [HttpPost("sendVerificationEmail")]
        public IActionResult SendVerificationEmail([FromBody] string email) {
            if(_authService.SendVerificationEmail(email))
                return Ok("Email aktywacyjny wysłany");
            return BadRequest("Email aktywacyjny nie został wysłany");
        }

        [HttpPost("activeAccount")]
        public IActionResult ActivatedAccount([FromBody] ActivatedAccount activatedAccount) {
            if (_authService.ActiveAccount(activatedAccount))
                return Ok("Konto pomyślnie aktywowane");
            return BadRequest("Błąd aktywacji");
        }

        [Authorize]
        [HttpPost("upload")]
        [AddSwaggerFileUploadButton]
        public async Task<IActionResult> UloadFile(IFormFile file) {
            string result = await _authService.UploadFile(file);
            _authService.UpdateAvatar(result, ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
            if (result != "")
                return Ok(result);
            return BadRequest();
        }

        [Authorize]
        [HttpPost("changePasswd")]
        public IActionResult ChangePassword([FromBody] PasswordEdit passwordEdit) {
            if (passwordEdit == null)
                return BadRequest();
            else if (!_authService.CheckOldPasswd(passwordEdit.OldPassword,
                ClaimsMethods.GetIdFromClaim(ClaimsMethods.GetClaimsList(HttpContext.User.Claims))))
                return BadRequest("Stare hasło nie jest poprawne");
            else if (!_authService.ChangePasswd(passwordEdit, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return BadRequest("Nie można zmienić hasła. Spróbuj ponownie później");
            return Ok();
        }

        [Authorize]
        [HttpGet("getUserById/{id}")]
        public AccountDTO GetUserById(int id)
        {
            if (id < 0)
                return null;
            AccountDTO result = _authService.GetUserById(id);
            if (result == null)
                return null;
            return result;

        }
    }
}