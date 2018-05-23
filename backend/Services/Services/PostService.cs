
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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IAccountService _accountService;
        private readonly IPictureService _pictureService;
        private readonly ICommentService _commentService;
        private readonly IHobbyService _hobbyService;

        public PostService(IPostRepository repository, IAccountService accountService,
            IPictureService pictureService,
            ICommentService commentService,
            IHobbyService hobbyService)
        {
            _postRepository = repository;
            _accountService = accountService;
            _pictureService = pictureService;
            _commentService = commentService;
            _hobbyService = hobbyService;
        }

        public IEnumerable<PostDTO> GetAll()
        {
            List<PostDTO> results = new List<PostDTO>();
            var dbPostResults =  _postRepository.GetAll().AsEnumerable();
            HashSet<int> hobbiesId = new HashSet<int>();
            List<HobbyDTO> hobbies = new List<HobbyDTO>();
            foreach (var obj in dbPostResults) {
                foreach(var posthobby in obj.PostHobbies) {
                    hobbiesId.Add(posthobby.HobbyId);
                }
            }
            foreach(var id in hobbiesId) {
                var hobby = _hobbyService.GetHobbyById(id);
                hobbies.Add(new HobbyDTO() {
                    Id = hobby.Id,
                    Color = hobby.Color,
                    Name = hobby.Name
                });
            }
            foreach(var obj in dbPostResults) {
                    results.Add(new PostDTO() {
                        Id = obj.Id,
                        Date = obj.Date,
                        Content = obj.Content,
                        Author = _accountService.Get(obj.AuthorId).Username,
                        Pictures = _pictureService.GetByPost(obj.Id).ToList(),
                        Comments = _commentService.GetAllCommentByPost(obj.Id).ToList(),
                        Hobbies = hobbies.Where(x=> hobbies.Select(c=> c.Id == x.Id))
                    });
            }
            return results;

        }

        public IEnumerable<Post> GetByAuthor(int authorId)
        {
            return null; 
        }

        public Post GetById(int id)
        {
            return _postRepository.Get(id);
        }
    }
}