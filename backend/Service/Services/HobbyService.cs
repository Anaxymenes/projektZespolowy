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

        public List<Hobby> GetAll() {
            return _hobbyRepository.GetAll().ToList();
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
                
                if (_hobbyRepository.Add(hobby))
                    return true;
            return false;
        }

        public void Delete(int id, int accountId)
        {
            Hobby hobby = _context.Hobby.Find(id);

            if (hobby != null) 
            {
                if (hobby.AdministratorId == accountId) 
                {
                    _hobbyRepository.Delete(id);
                }
            }
        }

        public HobbyDTO Edit(HobbyEdit hobbyEdit, List<ClaimDTO> claimList)
        {
            var hobby = _mapper.Map<Hobby>(hobbyEdit);
            var results = _hobbyRepository.Edit(hobby, Convert.ToInt32(claimList.Find(x => x.Type == "nameidentifier").Value));
            if (results != null)
                return _mapper.Map<HobbyDTO>(results);
            return null;
        }

        public List<HobbyToList> GetAllHobbiesByAccountId(List<ClaimDTO> list) {
            try {
                var resultDb = _hobbyRepository.GetAllHobbiesForAccountId(ClaimsMethods.GetIdFromClaim(list)); H
                List<HobbyToList> results = new List<HobbyToList>();
                foreach (var obj in resultDb)
                    results.Add(_mapper.Map<HobbyToList>(obj));
                return results;
            }catch (Exception e) {
                return null;
            }
        }
    }
}
