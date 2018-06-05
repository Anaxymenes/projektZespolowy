using AutoMapper;
using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Repository;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class HobbyService : IHobbyService {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

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
        
    }
}
