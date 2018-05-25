using Data.DBModel;
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

        public Hobby Add(Hobby entity) {
            _context.Hobby.Add(entity);
            _context.SaveChanges();
            return _context.Hobby.Last();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Hobby Edit(Hobby entity) {
            throw new NotImplementedException();
        }

        public IQueryable<Hobby> GetAll() {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
