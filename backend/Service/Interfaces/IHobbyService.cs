using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IHobbyService {
        List<Hobby> GetAll();
        void Delete(int id, int accountId);
        Hobby Get(int id);
        bool Add(HobbyAdd hobbyDTO, List<ClaimDTO> list);
        HobbyDTO Edit(HobbyEdit hobbyEdit, List<ClaimDTO> list);
        Task<string> UploadFile(IFormFile file);
        List<HobbyToList> GetAllHobbiesByAccountId(List<ClaimDTO> list);
        List<HobbyInformation> GetAllPagination(int countOfItem, int page);
    }
}
