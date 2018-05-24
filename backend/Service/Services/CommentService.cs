using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CommentService : ICommentService{

        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }
    }
}
