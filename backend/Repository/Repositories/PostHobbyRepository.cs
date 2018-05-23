using Data.DBModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class PostHobbyRepository : IPostHobbyRepository {
        private readonly DatabaseContext _context;

        public PostHobbyRepository(DatabaseContext context) {
            _context = context;
        }

<<<<<<< HEAD
        public PostHobby Add(PostHobby entity)
        {
            _context.PostHobby.Add(entity);
            return _context.PostHobby.Last();

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PostHobby Edit(PostHobby entity)
        {
=======
        public void Add(PostHobby t) {
            throw new NotImplementedException();
        }

        public int Count() {
            throw new NotImplementedException();
        }

        public void Delete(PostHobby entity) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public PostHobby Get(int id) {
>>>>>>> parent of 907ef6e... Many changes
            throw new NotImplementedException();
        }

        public IQueryable<PostHobby> GetAll() {
<<<<<<< HEAD
            return _context.PostHobby.AsQueryable()
                .Include(postHobby => postHobby.Hobby)
                .ThenInclude(hobby => hobby.Administrator)
                .Include(c => c.Post)
                .ThenInclude(v => v.Author)
                .Include(c => c.Post)
<<<<<<< HEAD
                .ThenInclude(v=>v.Author)
                .Include(c=>c.Post)
                .ThenInclude(v=>v.Comments);
=======
                .ThenInclude(v => v.Comments)
                .ThenInclude(b=>b.Author);
        }

        public IQueryable<PostHobby> GetAllPostByHobbyId(int v)
        {
            return _context.PostHobby.AsQueryable().Where(x => x.HobbyId == v);
        }

        public void Save()
        {
            throw new NotImplementedException();
>>>>>>> MateuszV2
=======
            throw new NotImplementedException();
        }

        public IQueryable<PostHobby> GetAllByPost(int postId) {
            return _context.PostHobby.Where(x => x.Post.Id == postId);
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public void Update(PostHobby entity) {
            throw new NotImplementedException();
>>>>>>> parent of 907ef6e... Many changes
        }
    }
}
