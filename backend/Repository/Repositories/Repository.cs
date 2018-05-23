using Data.DBModel;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity {
        public IQueryable<T> GetAll() {
            throw new NotImplementedException();
        }
    }
}
