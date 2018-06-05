using Data.DBModel;
using Data.Edit;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Hobby GetHobby(int id)
        {
            return _context.Hobby.Find(id);
        }

        public void Save() {
            throw new NotImplementedException();
        }

        Hobby IRepository<Hobby>.Add(Hobby entity)
        {
            throw new NotImplementedException();
        }
    }
}
