
using Data.DBModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Post> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("{author}")]
        public IEnumerable<Post> GetByAuthor(int authorId)
        {
            return _service.GetByAuthor(authorId);
        }

        [HttpGet]
        [Route("{id}")]
        public Post GetById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception e)
            {
                var result = e;

            }
            return null;

        }
    }
}