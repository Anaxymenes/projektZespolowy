using Data.DBModel;
using Data.DTO;
using Repository;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class PostHobbyService : IPostHobbyService
    {
        private readonly IPostHobbyRepository _postHobbyRepository;
        private readonly DatabaseContext _context;
        private readonly IPostService _postService;

        public PostHobbyService(IPostHobbyRepository postHobbyRepository,
                                IPostService postService,
                                DatabaseContext context
                                )
        {
            _postHobbyRepository = postHobbyRepository;
            _postService = postService;
            _context = context;
        }

        public List<PostHobby> GetAll()
        {
            return _postHobbyRepository.GetAll().ToList();
        }

        public void CreatePostHobby(PostDTO postDTO)
        {
            var post = _postService.Add(postDTO);
            foreach (var hobby in postDTO.Hobbys)
            {
                _postHobbyRepository.Add(
                    new PostHobby()
                    {
                        PostId = post.Id,
                        HobbyId = hobby.Id
                    }
                    );
            }
        }

        public List<PostDTO> GetAllPostsHobbyByHobbyId(int hobbyId)
        {
            var posts = _postHobbyRepository.GetAllPostsHobbyByHobbyId(hobbyId);

            List<PostDTO> postsDTO = new List<PostDTO>();
            foreach (var post in posts)
            {
                IQueryable<PostHobby> hobbys = _postHobbyRepository.GetHobbysByPostId(post);
                List<HobbyForPostDTO> hobbysForPostDTO = new List<HobbyForPostDTO>();
                List<String> pictures = new List<String>();
                EventDTO eventDTO = new EventDTO();

                foreach (var hobby in hobbys)
                {
                    hobbysForPostDTO.Add(new HobbyForPostDTO()
                    {
                        Color = hobby.Hobby.Color,
                        Id = hobby.Hobby.Id,
                        Name = hobby.Hobby.Name
                    });

                    var picturesClass = hobby.Post.Pictures;
                    foreach (var pic in picturesClass)
                    {
                        pictures.Add(pic.Path);
                    }
                }

                postsDTO.Add(new PostDTO()
                {
                    Date = post.Post.Date,
                    Content = post.Post.Content,
                    Author = post.Post.Author.AccountDetails.Name + " " + post.Post.Author.AccountDetails.LastName,
                    AuthorId = post.Post.Author.AccountDetails.Id,
                    Hobbys = hobbysForPostDTO,
                    Pictures = pictures,
                    Event = eventDTO

                });
            }


            return postsDTO;
            
        }

        public void Delete(int id, int accountId)
        {
            PostHobby postHobby = _context.PostHobby.Find(id);
            Account account = _context.Account.Find(accountId);

            if(postHobby != null && account != null)
            {
                if(postHobby.Post.AuthorId == accountId || account.RoleId == 1)
                {
                    _postHobbyRepository.Delete(id);
                }
            }
        }
    }
}




