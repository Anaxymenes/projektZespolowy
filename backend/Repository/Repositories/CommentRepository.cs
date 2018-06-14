using Data.DBModel;
using Microsoft.EntityFrameworkCore;
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
                var comments = _context.Comment
                    .Include(x => x.Author)
                        .ThenInclude(a => a.AccountDetails);
                return comments.Last();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Delete(int id, int userId)
        {
            var user = _context.Account.First(x => x.Id == userId);
            var comment = _context.Comment.First(x => x.Id == id);
            if (comment.AuthorId == userId)
            {
                try
                {
                    _context.Remove(comment);
                    _context.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
