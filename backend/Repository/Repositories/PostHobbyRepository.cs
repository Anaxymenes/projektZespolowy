

using Data.DBModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class PostHobbyRepository : IPostHobbyRepository
    {
        private readonly DatabaseContext _context;

        public PostHobbyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public PostHobby Add(PostHobby entity)
        {
            _context.PostHobby.Add(entity);
            return _context.PostHobby.Last();

        }

        public void Delete(int id)
        {
            PostHobby postHobby = _context.PostHobby.SingleOrDefault(x => x.Id == id);
        }

        public PostHobby Edit(PostHobby entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PostHobby> GetAll()
        {
            return _context.PostHobby.AsQueryable()
                .Include(postHobby => postHobby.Hobby)
                .ThenInclude(hobby => hobby.Administrator)
                .Include(c => c.Post)
                .ThenInclude(v => v.Author)
                .Include(c => c.Post)
                .ThenInclude(v => v.Comments)
                .ThenInclude(b => b.Author);
        }


        public IQueryable<PostHobby> GetAllPostsHobbyByHobbyId(int hobbyId)
        {
            return _context.PostHobby.Where(x => x.HobbyId == hobbyId).AsQueryable()
                 .Include(post => post.Post)
                     .ThenInclude(author => author.Author)
                         .ThenInclude(authorDetails => authorDetails.AccountDetails)
                 .Include(hobby => hobby.Hobby)
                 .Include(post => post.Post)
                     .ThenInclude(comment => comment.Comments)
                 .Include(post => post.Post)
                     .ThenInclude(picture => picture.Pictures)
                 .Include(post => post.Post)
                     .ThenInclude(events => events.EventDetalis);
        }

        public IQueryable<PostHobby> GetHobbysByPostId(PostHobby postHobby)
        {
            return _context.PostHobby.Where(x => x.Id == postHobby.Id).AsQueryable()
                .Include(hobby => hobby.Hobby);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}


