using Data.DBModel;
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
            throw new NotImplementedException();
        }

        public Post Edit(Post entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
