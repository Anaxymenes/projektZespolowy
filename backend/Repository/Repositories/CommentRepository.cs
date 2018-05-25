using Data.DBModel;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class CommentRepository : ICommentRepository {

        private readonly DatabaseContext _context;

        public CommentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Comment Add(Comment entity) {
            _context.Comment.Add(entity);
            _context.SaveChanges();
            return _context.Comment.Last();
        }

        public void Delete(int id) {
            Comment comment = _context.Comment.SingleOrDefault(x => x.Id == id);
            _context.Remove(comment);
            _context.SaveChanges();
        }

        public Comment Edit(Comment entity) {
            _context.Update(entity);
            _context.SaveChanges();
            return _context.Comment.Last();
        }

        public IQueryable<Comment> GetAll() {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
