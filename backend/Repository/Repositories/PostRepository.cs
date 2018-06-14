using Data.DBModel;
using Data.DTO;
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
                .Include(x=> x.Author)
                    .ThenInclude(x=>x.AccountDetails)
                .Include(comment => comment.Comments)
                    .ThenInclude(a => a.Author)
                        .ThenInclude(d => d.AccountDetails)
                .Include(x=>x.EventDetalis)
                .Include(x=>x.Pictures)
                .Include(x => x.PostHobbies)
                    .ThenInclude(a => a.Hobby)
                .Include(x=>x.PostType);
        }

        public IQueryable GetPost(int id)
        {
            return _context.Post.Where(x => x.Id == id)
                .Include(comment => comment.Comments)
                .ThenInclude(author => author.Author)
                .Include(author => author.Author);
        }
        public IQueryable<Post> GetAllPostByHobbyId(int hobbyId) {
            var postId = _context.PostHobby.Where(x => x.HobbyId == hobbyId).Select(x => x.PostId).ToHashSet();
            return _context.Post.Where(x => postId.Contains(x.Id))
                .Include(x=>x.Author)
                    .ThenInclude(x=>x.AccountDetails)
                .Include(x=>x.PostHobbies)
                    .ThenInclude(x=>x.Hobby)
                .Include(x=>x.PostType)
                .Include(x=>x.EventDetalis)
                .Include(x=>x.Pictures)
                .Include(x=>x.Comments)
                    .ThenInclude(x=>x.Author)
                        .ThenInclude(x=>x.AccountDetails);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAllPostByAuthorId(int authorId) {
            if (!_context.Post.Any())
                return null;
            return _context.Post.Where(x=>x.AuthorId == authorId)
                .Include(x => x.Author)
                    .ThenInclude(x => x.AccountDetails)
                .Include(x => x.PostHobbies)
                    .ThenInclude(x => x.Hobby)
                .Include(x => x.PostType)
                .Include(x => x.EventDetalis)
                .Include(x => x.Pictures)
                .Include(x => x.Comments)
                    .ThenInclude(x => x.Author)
                        .ThenInclude(x => x.AccountDetails);
        }
        
        public bool Delete(int postId, int userId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var post = _context.Post.First(x => x.Id == postId);
                    if (post.AuthorId == userId || post.Author.RoleId == 1)
                    {
                        var comments = _context.Comment.Where(x => x.PostId == postId);
                        if (comments != null)
                        {
                            _context.RemoveRange(comments);
                        }

                        _context.Remove(post);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    return false;
                    
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Update(PostEdit post, int userId)
        {
            try
            {
                var postData = _context.Post.First(x => x.Id == post.Id);
                if(postData.AuthorId == userId)
                {
                    postData.Content = post.Content;
                    _context.Update(postData);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
