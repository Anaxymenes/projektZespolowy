using AutoMapper;
using Data.DBModels;
using Data.DTO;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class PostHobbyService : IPostHobbyService
    {
        private readonly IPostHobbyRepository _postHobbyRepository;
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public PostHobbyService(IPostHobbyRepository postHobbyRepository, IHobbyRepository hobbyRepository,
            IMapper mapper) {
            _postHobbyRepository = postHobbyRepository;
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
        }

        public IEnumerable<PostHobbyDTO> GetAllByPost(int postId) {
            var results =  _postHobbyRepository.GetAllByPost(postId);
            var resutlsDTO = new List<PostHobbyDTO>();
            foreach(var obj in results) {
                resutlsDTO.Add(_mapper.Map<PostHobbyDTO>(obj));
            }
            return resutlsDTO.AsEnumerable();
        }

        //public IEnumerable<PostHobbyDTO> GetAllByPost(int id) {
        //    var results =  _postHobbyRepository.GetAllByPost(id);
        //}
    }
}
