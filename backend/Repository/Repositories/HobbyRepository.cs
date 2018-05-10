using Data.DBModels;
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

        public void Add(Hobby t) {
            throw new NotImplementedException();
        }

        public int Count() {
            throw new NotImplementedException();
        }

        public void Delete(Hobby entity) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Hobby Get(int id) {
            return _context.Hobby.FirstOrDefault(x => x.Id == id);
        }



        public IQueryable<Hobby> GetAll() {
            throw new NotImplementedException();
        }

        public List<PostHobby> GetAllHobbiesByPost(List<int> postIdList) {
            return null; // _context.Hobby.Where(x=> postIdList.Contains(x.Id));
        }

        public IQueryable<Hobby> GetAllHobbiesForIdList(List<int> hobbyIdList) {
            return _context.Hobby.Where(r => hobbyIdList.Contains(r.Id)).AsQueryable();
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public void Update(Hobby entity) {
            throw new NotImplementedException();
        }
    }
}
