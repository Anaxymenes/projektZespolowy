using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        JWTBearerToken GetToken(AccountLoginVerificationDTO user);
        AccountLoginVerificationDTO GetUserByUserNameOrEmail(LoginDTO loginDTO);
        bool IsValid(AccountLoginVerificationDTO user, LoginDTO loginDTO);
        HashedPassword GetHasedPassword(string password);
        bool ExistUser(RegisterAccountDTO registerAccountDTO);
        bool RegisterUser(RegisterAccountDTO registerAccountDTO);
        bool SendVerificationEmail(string email);
        bool SendVerificationEmail(IEnumerable<ClaimDTO> claimDTOEnumarable);
        bool ActiveAccount(ActivatedAccount activatedAccount);
        Task<string> UploadFile(IFormFile file);
        bool ChangePasswd(PasswordEdit passwordEdit);
        void UpdateAvatar(string result, List<ClaimDTO> list);
    }
}
