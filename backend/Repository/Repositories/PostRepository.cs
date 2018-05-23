<<<<<<< HEAD
﻿using Data.DBModel;
=======
﻿using Data.DBModels;
using Microsoft.EntityFrameworkCore;
>>>>>>> parent of 907ef6e... Many changes
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
<<<<<<< HEAD
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _context;

        public PostRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Post Add(Post entity)
        {
            _context.Post.Add(entity);
            _context.SaveChanges();
            return _context.Post.Last();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Post Edit(Post entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
=======
    public class PostRepository : IPostRepository {

        protected DatabaseContext _context;

        public PostRepository(DatabaseContext context) {
            _context = context;
        }

        public void Add(Post t) {
            _context.Post.Add(t);
            _context.SaveChanges();
        }

        public int Count() {
            return _context.Post.Count();
        }

        public void Delete(Post entity) {
            _context.Post.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public Post Get(int id) {
            return _context.Post.First(x => x.Id == id);
        }

        public IQueryable<Post> GetAll() {
            return _context.Post.Include(x=>x.PostHobbies);
        }

        public void Save() {
            _context.SaveChanges();
        }

        public void Update(Post entity) {
            _context.Add(entity);
            Save();
>>>>>>> parent of 907ef6e... Many changes
        }
    }
}
