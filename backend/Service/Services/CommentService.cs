using AutoMapper;
using Data.Add;
using Data.DBModel;
using Data.DTO;
using Data.EditViewModel;
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
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository, DatabaseContext context, IMapper mapper) {
            _commentRepository = commentRepository;
            _context = context;
            _mapper = mapper;
        }

        public CommentDTO Add(CommentAdd commentAdd, List<ClaimDTO> claimsList)
        {
            int authorId = Convert.ToInt32(claimsList.Find(x => x.Type == "nameidentifier").Value);
            var comment = _mapper.Map<Comment>(commentAdd);
            comment.AuthorId = authorId;

            var result = _commentRepository.Add(comment);
            if (result != null)
                return _mapper.Map<CommentDTO>(result);
            return null;

            //if (_context.Post.Find(comment.PostId) != null && _context.Account.Find(comment.AuthorId) != null)
            //{
            //    return _commentRepository.Add(comment);
            //}

            return null;
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

        public Comment Edit(CommentEdit commentEdit)
        {
            Comment comment = _context.Comment.Find(commentEdit.Id);
            Account account = _context.Account.Find(commentEdit.accountId);

            if (account != null && comment != null)
            {
                if (comment.AuthorId == commentEdit.accountId || account.RoleId == 1)
                {
                    comment.Content = commentEdit.content;
                    return _commentRepository.Edit(comment);
                }
            }
            return null;
        }

    }
}
