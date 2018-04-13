using Data.DBModels;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class Repository<T>: IRepository<T> where T : Entity
    {
        protected readonly DbContext _context;
        protected DbSet<T> _dbSet;

        public Repository(DatabaseContext context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) {
            _context.Set<T>().Add(entity);
        }

        public T Get<TKey>(TKey key) {
            return _dbSet.Find(key);
        }

        public IQueryable<T> GetAll() {
            return _dbSet;
        }

        public void Update(T entity) {
            Save();
        }
        protected void Save() {
            _context.SaveChanges();
        }
    }
}
