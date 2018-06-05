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
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return _context.Comment.Last();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Delete(int id) {
            Comment comment = _context.Comment.SingleOrDefault(x => x.Id == id);
            _context.Remove(comment);
            _context.SaveChanges();
        }

        public Comment Edit(Comment entity, int userId)
        {
            var user = _context.Account.First(x => x.Id == userId);
            var comment = _context.Comment.First(x => x.Id == entity.Id);
            if (comment.AuthorId == userId)
            {
                try
                {
                    comment.Date = entity.Date;
                    comment.Content = entity.Content;
                    _context.Update(comment);
                    _context.SaveChanges();
                    return comment;
                }
                catch (Exception e)
                {
                    return null;
                }
            };
            return null;
        }

        public Comment Edit(Comment entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetAll() {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
