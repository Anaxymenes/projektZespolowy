using Data.DBModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Comment> GetAllForPost(int postId)
        {
            return _service.GetAllForPost(postId);
        }

        [HttpPost("add")]
        public void Add(string content)
        {
            _service.Add(content);
        }

        [HttpDelete("delete")]
        public void Delete(int commentId)
        {
            _service.Delete(commentId);
        }

        [HttpPut("edit")]
        public void Update(int commentId, string content)
        {
            _service.Update(commentId, content);
        }
    }
}
