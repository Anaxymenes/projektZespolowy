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
                    _context.Update(entity);
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

        public IQueryable<Hobby> GetAll() {
            return _context.Hobby.AsQueryable();
        }

        public IQueryable<Hobby> GetAllHobbiesForAccountId(int accountId) {
            var hobbyId = _context.AccountHobby.Where(x => x.AccountId == accountId).Select(z => z.HobbyId).ToHashSet();
            return _context.Hobby.Where(x => hobbyId.Contains(x.Id)).AsQueryable();
        }

        public IQueryable<Hobby> GetAllWithPagination(int countOfItem, int page) {
            try {
                return _context.Hobby
                    .Include(x=> x.Administrator)
                        .ThenInclude(x=>x.AccountDetails)
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
    }
}
