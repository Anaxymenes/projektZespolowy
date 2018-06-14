using Data.DBModel;
using Data.Edit;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class HobbyRepository : IHobbyRepository {
        private readonly DatabaseContext _context;

        public HobbyRepository(DatabaseContext context) {
            _context = context;
        }

        public bool Add(Hobby entity) {
            var result = false;
                try
                {
                    _context.Hobby.Add(entity);
                    _context.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    return false;
                }
            return result;
        }

        public void Delete(int id) {
            Hobby hobby = _context.Hobby.SingleOrDefault(x => x.Id == id);
            _context.Remove(hobby);
            _context.SaveChanges();
        }

        public Hobby Edit(Hobby entity, int userId) {
            //if (entity.AdministratorId == userId)
           // {
                try
                {
                    var hobby = _context.Hobby.First(x => x.Id == entity.Id);
                    if (entity.Description != null)
                        hobby.Description = entity.Description;
                    if (entity.Name != null)
                        hobby.Name = entity.Name;
                    if (entity.Color != null)
                        hobby.Color = entity.Color;
                    if (entity.Logo != null)
                        hobby.Logo = entity.Logo;

                    _context.Update(hobby);
                    _context.SaveChanges();
                    return entity;
                }
                catch (Exception e)
                {
                    return null;
                }
           // }
            //return null;
        }

        public Hobby Edit(Hobby entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Hobby> GetAllHobbiesForAccountId(int accountId) {
            var hobbyId = _context.AccountHobby.Where(x => x.AccountId == accountId).Select(z => z.HobbyId).ToHashSet();
            return _context.Hobby.Where(x => hobbyId.Contains(x.Id)).AsQueryable()
                    .Include(x => x.AccountHobbies)
                    .Include(x => x.Administrator)
                        .ThenInclude( x => x.AccountDetails);

        }

        public IQueryable<Hobby> GetAll()
        {
            try
            {
                return _context.Hobby
                    .Include(x => x.Administrator)
                        .ThenInclude(x => x.AccountDetails)
                    .Include(x => x.AccountHobbies);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Hobby> GetAllWithPagination(int countOfItem, int page) {
            try {
                return _context.Hobby
                    .Include(x=> x.Administrator)
                        .ThenInclude(x=>x.AccountDetails)
                    .Include(x => x.AccountHobbies)
                    .Skip((page - 1) * countOfItem).Take(countOfItem);
            }catch(Exception e) {
                throw e;
            }
        }

        public Hobby GetHobby(int id)
        {
            return _context.Hobby.Find(id);
        }

        public void Save() {
            throw new NotImplementedException();
        }

        Hobby IRepository<Hobby>.Add(Hobby entity) {
            throw new NotImplementedException();
        }

        public bool Delete(int hobbyId, int accountId) {
            if (!_context.Hobby.Any(x => x.Id == hobbyId) ||
                !_context.Account.Any(x=>x.Id == accountId)
                )
                return false;
            var hobby = _context.Hobby.First(x => x.Id == hobbyId);
            if (!(hobby.AdministratorId == accountId
                || _context.Account.First(x => x.Id == accountId).RoleId != 3))
                return false;

            using(var transaction  = _context.Database.BeginTransaction()) {
                try {
                    var postsId = _context.PostHobby
                       .Where(x => x.HobbyId == hobbyId)
                       .Select(y => y.PostId).ToList();
                    foreach(var id in postsId) {
                        if(_context.PostHobby.Where(x=>x.PostId == id).Count() == 1) {
                            var post = _context.Post.First(x => x.Id == id);
                            if(_context.Comment.Any(x=>x.PostId==id))
                            _context.RemoveRange(_context.Comment.Where(x => x.PostId == id).ToList());
                            if(_context.Picture.Any(x=>x.PostId==id))
                            _context.Picture.RemoveRange(
                                _context.Picture.Where(x => x.PostId == id).ToList());
                            if(_context.EventDetails.Any(x=>x.PostId==id))
                            _context.EventDetails.Remove(
                                _context.EventDetails.First(x => x.PostId == id));
                            if(!_context.PostHobby.Any(x=> x.PostId == id && x.HobbyId != hobbyId))
                                _context.Remove(post);
                        }
                    }
                    _context.AccountHobby.RemoveRange(
                        _context.AccountHobby.Where(x=>x.HobbyId==hobbyId).ToList()
                        );
                    _context.Hobby.Remove(hobby);
                    _context.SaveChanges();
                    //var posthobbies = _context.PostHobby.Where(x => x.HobbyId == hobbyId).ToList();
                    //var postsId = posthobbies.Select(x => x.PostId).ToList();
                    //var posts = _context.Post.Where(x => postsId.Contains(x.Id));
                    //_context.PostHobby.RemoveRange(posthobbies);
                    //_context.Post.RemoveRange(posts);
                    //var hobby = _context.Hobby.First(x => x.Id == hobbyId);
                    //_context.Remove(hobby);
                    transaction.Commit();
                    return true;
                }catch(Exception e) {
                    transaction.Rollback();
                    return false;
                }
                }
        }

        public IQueryable<Hobby> GetHobbysWhereIAmAdmin(int accountId)
        {
            try
            {
                return _context.Hobby.Where(x => x.AdministratorId == accountId);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
