using Data.DBModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class PictureRepository : IPictureRepository {
        private DatabaseContext _context;

        public PictureRepository(DatabaseContext context) {
            _context = context;
        }

        public void Add(Picture t) {
            throw new NotImplementedException();
        }

        public int Count() {
            throw new NotImplementedException();
        }

        public void Delete(Picture entity) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Picture Get(int id) {
            throw new NotImplementedException();
        }

        public IQueryable<Picture> GetAll() {
            throw new NotImplementedException();
        }

        public IEnumerable<Picture> GetByPost(int postId) {
            return _context.Picture.Where(x=>x.PostId == postId);
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public void Update(Picture entity) {
            throw new NotImplementedException();
        }
    }
}
