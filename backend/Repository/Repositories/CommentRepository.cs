using Data.DBModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class CommentRepository : ICommentRepository {
        private readonly DatabaseContext _context;

        public CommentRepository(DatabaseContext context) {
            _context = context;
        }
        public void Add(Comment t) {
            throw new NotImplementedException();
        }

        public int Count() {
            throw new NotImplementedException();
        }

        public void Delete(Comment entity) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Comment Get(int id) {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetAll() {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetAllByPost(int postId) {
            return _context.Comment.Where(x => x.PostId == postId);
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public void Update(Comment entity) {
            throw new NotImplementedException();
        }
    }
}
