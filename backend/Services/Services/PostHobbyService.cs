using Data.DBModels;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class PostHobbyService : IPostHobbyService
    {
        private readonly IPostHobbyRepository _postHobbyRepository;

        public PostHobbyService(IPostHobbyRepository postHobbyRepository) {
            _postHobbyRepository = postHobbyRepository;

        }

        public IEnumerable<PostHobby> GetAllByPost(int id) {
            return _postHobbyRepository.GetAllByPost(id);
        }
    }
}
