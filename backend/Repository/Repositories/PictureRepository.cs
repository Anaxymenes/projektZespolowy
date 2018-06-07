using Data.DBModel;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class PictureRepository : IPictureRepository {
        private readonly DatabaseContext _context;

        public PictureRepository(DatabaseContext context) {
            this._context = context;
        }

        public Picture Add(Picture entity) {
            throw new NotImplementedException();
        }

        public bool AddAll(List<Picture> entities) {
            try {
                _context.Picture.AddRange(entities);
                return true;
            }catch(Exception e) {
                return false;
            }
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Picture Edit(Picture entity) {
            throw new NotImplementedException();
        }

        public IQueryable<Picture> GetAll() {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
