using Data.DBModels;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller {
        private PostService _service;
        public PostController(PostService service) {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Post> GetAll() {
            return _service.GetAll();
        }
    }
}
