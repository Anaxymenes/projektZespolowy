using Data.DBModel;
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

        public HobbyService(IHobbyRepository hobbyRepository) {
            _hobbyRepository = hobbyRepository;
        }

        public List<Hobby> GetAll() {
            return _hobbyRepository.GetAll().ToList();
        }
    }
}
