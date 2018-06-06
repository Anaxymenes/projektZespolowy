using Data.DBModel;
using Microsoft.EntityFrameworkCore;
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

        public PostHobby Add(PostHobby entity) {
            _context.PostHobby.Add(entity);
            _context.SaveChanges();
            return _context.PostHobby.Last();

        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public PostHobby Edit(PostHobby entity) {
            throw new NotImplementedException();
        }

        public IQueryable<PostHobby> GetAll() {
            return _context.PostHobby.AsQueryable()
                .Include(postHobby => postHobby.Hobby)
                    .ThenInclude(hobby => hobby.Administrator)
                .Include(c => c.Post)
                     .ThenInclude(v => v.Author)
                .Include(c => c.Post)
                    .ThenInclude(v => v.Comments)
                        .ThenInclude(b => b.Author)
                .Include(p => p.Post)
                    .ThenInclude(e => e.EventDetalis);
        }

        public IQueryable<PostHobby> GetAllPostByHobbyId(int hobbyId) {
            return _context.PostHobby.AsQueryable().Where(x => x.HobbyId == hobbyId)
                .Include(c => c.Post)
                    .ThenInclude(v => v.Comments)
                        .ThenInclude(b => b.Author)
                .Include(p => p.Post)
                    .ThenInclude(e => e.EventDetalis)
                .Include(p => p.Post)
                    .ThenInclude(pictures => pictures.Pictures)
                .Include(h => h.Hobby)
                .Include(x => x.Post)
                    .ThenInclude(a => a.Author)
                        .ThenInclude(d => d.AccountDetails);
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
