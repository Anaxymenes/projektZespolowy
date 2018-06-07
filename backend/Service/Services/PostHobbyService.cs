using AutoMapper;
using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Http;
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
    public class PostHobbyService : IPostHobbyService {
        private readonly IPostHobbyRepository _postHobbyRepository;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly string _module = "post";

        public PostHobbyService(IPostHobbyRepository postHobbyRepository,
                                IPostService postService,
                                IMapper mapper) {
            _postHobbyRepository = postHobbyRepository;
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = FileManagement.GetFileName(file);
                await FileManagement.UploadFile(file, _module, filename);
                return FileManagement.GetFilePathForDatabase(filename, _module);
            }
            return "";
        }

        public List<PostHobby> GetAll() {
            return _postHobbyRepository.GetAll().ToList();
        }

        public void CreatePostHobby(PostAdd postAdd, List<ClaimDTO> claimsList) {
            var postDTO = _mapper.Map<PostDTO>(postAdd);
            postDTO.AuthorId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
            var post = _postService.Add(postDTO);
            foreach (var hobby in postDTO.Hobbys) {
                _postHobbyRepository.Add(
                    new PostHobby() {
                        PostId = post.Id,
                        HobbyId = hobby.Id
                    }
                    );
            }
        }

        public List<PostDTO> GetAllPostsByHobbyId(int hobbyId) {
            //var resultsDB = _postHobbyRepository.GetAllPostByHobbyId(hobbyId);
            //List<PostDTO> results = new List<PostDTO>();
            //foreach (var obj in resultsDB) {
            //    List<HobbyForPostDTO> hobbys = new List<HobbyForPostDTO>();

            //    foreach (var hobby in obj.Post.PostHobbies)
            //    {
            //        HobbyForPostDTO hobbyForPostDTO = _mapper.Map<HobbyForPostDTO>(hobby);
            //        hobbys.Add(hobbyForPostDTO);
            //    }

            //    PostDTO post = _mapper.Map<PostDTO>(obj.Post);
            //    post.Hobbys = hobbys;

            //    if (obj.Post.EventDetalis != null)
            //    {
            //        EventDTO events = _mapper.Map<EventDTO>(obj.Post.EventDetalis);
            //        post.Event = events;
            //    }

            //    results.Add(post);
            //}
            //return results;
            return _postService.GetAllPostsByHobbyId(hobbyId);
        }

        public List<PostDTO> GetAllPostsByUserHobbys(List<ClaimDTO> claimsList)
        {
            return _postService.GetAllPostsByUserHobbys(claimsList);
        }

        public List<PostDTO> GetAllPostByAuthorId(int authorId) {
            return _postService.GetAllPostByAuthorId(authorId);
        }
    }
}
