using Data.DBModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _context;

        public PostRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Post Add(Post entity)
        {
            _context.Post.Add(entity);
            _context.SaveChanges();
            return _context.Post.Last();
        }

        public void Delete(int id)
        {
            Post post = _context.Post.SingleOrDefault(x => x.Id == id);
            _context.Remove(post);
            _context.SaveChanges();
        }

        public Post Edit(Post entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Post.AsQueryable()
                .Include(comment => comment.Comments)
                .ThenInclude(author => author.Author)
                .Include(author => author.Author);
        }

        public IQueryable GetPost(int id)
        {
            return _context.Post.Where(x => x.Id == id)
                .Include(comment => comment.Comments)
                .ThenInclude(author => author.Author)
                .Include(author => author.Author);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
