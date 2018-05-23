using Data.DBModels;
using Data.DTO;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class CommentService : ICommentService {
        private readonly ICommentRepository _commentRepository;
        private readonly IAccountService _accountService;

        public CommentService(ICommentRepository commentRepository,
            IAccountService accountService) {
            _commentRepository = commentRepository;
            _accountService = accountService;
        }

        public IEnumerable<CommentDTO> GetAllCommentByPost(int postId) {
            List<CommentDTO> resultList = new List<CommentDTO>();
            var results = _commentRepository.GetAllByPost(postId);
            if (results == null)
                return null;
            foreach(var obj in results) {
                resultList.Add(
                    new CommentDTO() {
                        Id = obj.Id,
                        Date = obj.Date,
                        Content = obj.Content,
                        Author = _accountService.Get(obj.AuthorId).Username,
                        AuthorId = obj.AuthorId
                    }
                );
            }
            return resultList;
        }
    }
}
