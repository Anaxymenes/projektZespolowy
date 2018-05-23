using Data.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : Entity {
        void Add(T t);
        int Count();
        void Delete(T entity);
        void Dispose();
        T Get(int id);
        IQueryable<T> GetAll();
<<<<<<< HEAD
        T Add(T entity);
        T Edit(T entity);
        void Delete(int id);
        void Save();
=======
        void Save();
        void Update(T entity);
>>>>>>> parent of 907ef6e... Many changes
    }
}
