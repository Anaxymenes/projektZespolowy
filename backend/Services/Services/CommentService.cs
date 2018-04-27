using Data.DBModels;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class CommentService : ICommentService
    {
        private IRepository<Comment> _commentRepository;
        private IRepository<Post> _postRepository;

        public CommentService(IRepository<Comment> commentRepository, IRepository<Post> postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public IEnumerable<Comment> GetAllForPost(int postId)
        {
            var commentList = _commentRepository.FindAll(x => x.Post.Id == postId);

            if (commentList == null)
            {
                return null;
            }

            return commentList.AsEnumerable();
        }

        public void Add(string content)
        {
            Comment comment = new Comment(DateTime.Now, content);

            _commentRepository.Add(comment);
        }

        public void Delete(int commentId)
        {
            _commentRepository.Delete(_commentRepository.Get(commentId));
        }

        public void Update(int commentId, string content)
        {
            Comment comment = _commentRepository.Get(commentId);
            comment.Content = content;
            comment.Date = DateTime.Now;

            _commentRepository.Update(comment, commentId);
        }

    }
}
