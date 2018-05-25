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

        public HobbyService(IHobbyRepository hobbyRepository, DatabaseContext context) {
            _hobbyRepository = hobbyRepository;
            _context = context;
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

        public Hobby Add(HobbyDTO hobbyDto)
        {
            Hobby hobby = new Hobby { };

            hobby.Name = hobbyDto.Name;
            hobby.Logo = hobbyDto.Logo;
            hobby.Description = hobbyDto.Description;
            hobby.Color = hobbyDto.Color;
            hobby.AdministratorId = hobbyDto.AdministratorId;

            if(_context.Account.Find(hobby.AdministratorId) != null)
            {
                return _hobbyRepository.Add(hobby);
            }

            return null;
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

        public Hobby Edit(HobbyEdit hobbyEdit)
        {
            Hobby hobby = _context.Hobby.Find(hobbyEdit.Id);

            if(hobby != null)
            {
                if (hobby.AdministratorId == hobbyEdit.accountId)
                {
                    hobby.Name = hobbyEdit.name;
                    hobby.Color = hobbyEdit.color;
                    hobby.AdministratorId = hobbyEdit.newAdminId;
                    hobby.Description = hobbyEdit.description;
                    return _hobbyRepository.Edit(hobby);
                }
            }

            return null;
        }
    }
}
