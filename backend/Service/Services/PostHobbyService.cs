using Data.DBModel;
using Data.DTO;
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
        private readonly IPostService _postService;

        public PostHobbyService(IPostHobbyRepository postHobbyRepository,
                                IPostService postService) {
            _postHobbyRepository = postHobbyRepository;
            _postService = postService;
        }

        public List<PostHobby> GetAll() {
            return _postHobbyRepository.GetAll().ToList();
        }

        public void CreatePostHobby(PostDTO postDTO)
        {
            var post = _postService.Add(postDTO);
            foreach (var hobby in postDTO.Hobbys)
            {
                _postHobbyRepository.Add(
                    new PostHobby() {
                        PostId = post.Id,
                        HobbyId = hobby.Id
                    }
                    );
            }
        }

        public List<PostDTO> GetAllPostsByHobbyId(int id)
        {
            var resultsDB = _postHobbyRepository.GetAllPostByHobbyId(id);
            List<PostDTO> results = new List<PostDTO>();
            foreach (var obj in resultsDB)
            {
                HobbyForPostDTO hobby = new HobbyForPostDTO()
                {
                    Color = obj.Hobby.Color,
                    Name = obj.Hobby.Name

                };
                EventDTO events = new EventDTO()
                {
                    EndAt = obj.Post.EventDetalis.EndAt,
                    Latitude = obj.Post.EventDetalis.Latitude,
                    Longitude = obj.Post.EventDetalis.Longitude,
                    StartAt = obj.Post.EventDetalis.StartAt

                };
                PostDTO post = new PostDTO()
                {
                    Author = obj.Post.Author.Username,
                    Content = obj.Post.Content,
                    Date = obj.Post.Date,
                    //Hobbys = hobby,
                    Event = events
                };
            }
            return null;
        }

        List<PostHobby> IPostHobbyService.GetAllPostsByHobbyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
