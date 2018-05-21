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

        public IQueryable<PostHobby> GetAll() {
            return _context.PostHobby.AsQueryable()
                .Include(postHobby => postHobby.Hobby)
                .ThenInclude(hobby => hobby.Administrator)
                .Include(c => c.Post)
                .ThenInclude(v => v.Author)
                .Include(c => c.Post)
                .ThenInclude(v => v.Comments);
        }
        
    }
}
