using Data.DBModel;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class PostHobbyService : IPostHobbyService {
        private readonly IPostHobbyRepository _postHobbyRepository;

        public PostHobbyService(IPostHobbyRepository postHobbyRepository) {
            _postHobbyRepository = postHobbyRepository;

        }

        public List<PostHobby> GetAll() {
            return _postHobbyRepository.GetAll().ToList();
        }
    }
}
