using AutoMapper;
using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Microsoft.AspNetCore.Http;
using Repository;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Utils;

namespace Service.Services
{
    public class HobbyService : IHobbyService {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly string _module = "hobby";

        public HobbyService(IHobbyRepository hobbyRepository, DatabaseContext context, IMapper mapper) {
            _hobbyRepository = hobbyRepository;
            _context = context;
            _mapper = mapper;
        }


        public Hobby Get(int id)
        {
            Hobby hobby = _context.Hobby.Find(id);

            if(hobby != null)
            {
                return _hobbyRepository.GetHobby(id);
            }

            return null;
        }
        public async Task<string> UploadFile(IFormFile file) {
            if (file != null && file.Length > 0) {
                var filename = FileManagement.GetFileName(file);
                await FileManagement.UploadFile(file, _module, filename);
                return FileManagement.GetFilePathForDatabase(filename, _module);
                }
            return "";
        }
        public bool Add(HobbyAdd hobbyDTO, List<ClaimDTO> claimList)
        {
                if (hobbyDTO == null)
                    return false;
                int administratorId = Convert.ToInt32(claimList.Find(x => x.Type == "nameidentifier").Value);

                var hobby = _mapper.Map<Hobby>(hobbyDTO);
                hobby.AdministratorId = administratorId;
            if (hobbyDTO.Logo == null || hobbyDTO.Logo == "")
                hobby.Logo = "/img/hobby/defaultHobby.png";
                if (_hobbyRepository.Add(hobby))
                    return true;
            return false;
        }

        

        public HobbyDTO Edit(HobbyEdit hobbyEdit, List<ClaimDTO> claimList)
        {
            var hobby = _mapper.Map<Hobby>(hobbyEdit);
            var results = _hobbyRepository.Edit(hobby, Convert.ToInt32(claimList.Find(x => x.Type == "nameidentifier").Value));
            if (results != null)
                return _mapper.Map<HobbyDTO>(results);
            return null;
        }

        public List<HobbyToList> GetAllHobbiesByAccountId(List<ClaimDTO> claimsList) {
            try {
                var resultDb = _hobbyRepository.GetAllHobbiesForAccountId(ClaimsMethods.GetIdFromClaim(claimsList)); 
                List<HobbyToList> results = new List<HobbyToList>();
                foreach (var obj in resultDb)
                {
                    var temp = _mapper.Map<HobbyToList>(obj);
                    results.Add(temp);
                }
                return results;
            }catch (Exception e) {
                return null;
            }
        }

        public List<HobbyInformation> GetAll(List<ClaimDTO> claimsList)
        {
            try
            {
                int accountId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
                List<HobbyInformation> result = new List<HobbyInformation>();
                foreach (var obj in _hobbyRepository.GetAll())
                {
                    var temp = new HobbyInformation
                    {
                        Administator = obj.Administrator.AccountDetails.Name + " " + obj.Administrator.AccountDetails.LastName,
                        AdministratorId = obj.AdministratorId,
                        Name = obj.Name,
                        Color = obj.Color,
                        Description = obj.Description,
                        Id = obj.Id,
                        Logo = obj.Logo
                    };
                    if (obj.AccountHobbies.Any(x => x.AccountId == accountId))
                        temp.Belong = true;
                    else
                        temp.Belong = false;
                    result.Add(temp);
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<HobbyInformation> GetAllPagination(int countOfItem, int page, List<ClaimDTO> claimsList) {
            try {
                int accountId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
                List<HobbyInformation> result = new List<HobbyInformation>();
                foreach (var obj in _hobbyRepository.GetAllWithPagination(countOfItem, page))
                {
                    var temp = new HobbyInformation {
                        Administator = obj.Administrator.AccountDetails.Name + " " + obj.Administrator.AccountDetails.LastName,
                        AdministratorId = obj.AdministratorId,
                        Name = obj.Name,
                        Color = obj.Color,
                        Description = obj.Description,
                        Id = obj.Id,
                        Logo = obj.Logo
                    };
                    if (obj.AccountHobbies.Any(x => x.AccountId == accountId))
                        temp.Belong = true;
                    else
                        temp.Belong = false;
                    result.Add(temp);
                }
                return result;
            }catch (Exception e) {
                return null;
            }
        }

        public List<HobbyInformation> GetHobbysByUserId(int userId) {
            List<HobbyInformation> list = new List<HobbyInformation>();
            var result = _hobbyRepository.GetAllHobbiesForAccountId(userId);
            if (result == null || result.Count() == 0)
                return null;
            foreach (var obj in result)
            {
                var temp = _mapper.Map<HobbyInformation>(obj);
                temp.Belong = true;
                list.Add(temp);
            }
            return list;
        }

        public bool Delete(int hobbyId, List<ClaimDTO> claims) {
            var accountId = ClaimsMethods.GetIdFromClaim(claims);
            return _hobbyRepository.Delete(hobbyId, accountId);
        }

        public List<HobbyDTO> GetHobbysWhereIAmAdmin(List<ClaimDTO> claims)
        {
            var accountId = ClaimsMethods.GetIdFromClaim(claims);
            var hobbys = _hobbyRepository.GetHobbysWhereIAmAdmin(accountId);
            List<HobbyDTO> hobbysDTO = new List<HobbyDTO>();
            foreach(var hobby in hobbys)
            {
                var hobbyDTO = _mapper.Map<HobbyDTO>(hobby);
                hobbysDTO.Add(hobbyDTO);
            }
            return hobbysDTO;
        }
    }
}
