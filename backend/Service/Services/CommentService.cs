using Data.DBModel;
using Data.DTO;
using Repository;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CommentService : ICommentService{

        private readonly DatabaseContext _context;
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository, DatabaseContext context) {
            _commentRepository = commentRepository;
            _context = context;
        }

        public Comment Add(CommentDTO commentDto)
        {
            Comment comment = new Comment { };
            comment.Content = commentDto.Content;
            comment.Date = DateTime.Now;
            comment.AuthorId = commentDto.AuthorId;
            comment.PostId = commentDto.PostId;

            return _commentRepository.Add(comment);
        }

        public void Delete(int id, int accountId)
        {
            Comment comment = _context.Comment.Find(id);
            Account account = _context.Account.Find(accountId);

            if (account != null && comment != null)
            {
                if (comment.AuthorId == accountId || account.RoleId == 1)
                {
                    _commentRepository.Delete(id);
                }
            }
        }

    }
}
