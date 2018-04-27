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
        void Save();
        void Update(T entity);
    }
}
