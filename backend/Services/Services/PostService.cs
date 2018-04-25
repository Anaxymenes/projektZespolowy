using Data.DBModels;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class PostService : IPostService {
        private IRepository<Post> _repository;

        public PostService(IRepository<Post> repository) {
            _repository = repository;
        }

        public IEnumerable<Post> GetAll() {
            return _repository.GetAll().AsEnumerable();
        }

        //public IEnumerable<Post> GetByAuthor()
        //{
        //    return _repository.GetAll().Where(x => x.Author == "user").AsNumerable();
        //}

        public Post GetById(int id) 
        {
            return _repository.Find(x => x.Id == id);
        }
    }
}
