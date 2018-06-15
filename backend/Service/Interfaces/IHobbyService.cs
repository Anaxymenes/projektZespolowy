using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Data.Search;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IHobbyService {
        bool Delete(int hobbyId, List<ClaimDTO> claims);
        bool Add(HobbyAdd hobbyDTO, List<ClaimDTO> list);
        HobbyDTO Edit(HobbyEdit hobbyEdit, List<ClaimDTO> list);
        Task<string> UploadFile(IFormFile file);
        List<HobbyToList> GetAllHobbiesByAccountId(List<ClaimDTO> list);
        List<HobbyInformation> GetAllPagination(int countOfItem, int page, List<ClaimDTO> list);
        List<HobbyInformation> GetAll(List<ClaimDTO> list);
        List<HobbyInformation> GetHobbysByUserId(int userId);
        List<HobbyDTO> GetHobbysWhereIAmAdmin(List<ClaimDTO> list);
        List<HobbyDTO> FindHobbyByValue(string value);
        HobbyInformation Get(int hobbyId, List<ClaimDTO> list);
    }
}
