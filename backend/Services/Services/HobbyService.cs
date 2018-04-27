using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class HobbyService : IHobbyService
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IPostHobbyService _postHobbyService;

        public HobbyService(IHobbyRepository hobbyRepository,
            IPostHobbyService postHobbyService) {
            _hobbyRepository = hobbyRepository;
            _postHobbyService = postHobbyService;
        }

    }
}
