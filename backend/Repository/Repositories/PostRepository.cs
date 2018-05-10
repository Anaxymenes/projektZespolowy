using Data.DBModels;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class PostRepository : IPostRepository {

        protected DatabaseContext _context;

        public PostRepository(DatabaseContext context) {
            _context = context;
        }

        public void Add(Post t) {
            _context.Post.Add(t);
            _context.SaveChanges();
        }

        public int Count() {
            return _context.Post.Count();
        }

        public void Delete(Post entity) {
            _context.Post.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Post Get(int id) {
            return _context.Post.First(x => x.Id == id);
        }

        public IQueryable<Post> GetAll() {
            return _context.Post.Include(x=>x.PostHobbies);
        }

        public void Save() {
            _context.SaveChanges();
        }

        public void Update(Post entity) {
            _context.Add(entity);
            Save();
        }
    }
}
