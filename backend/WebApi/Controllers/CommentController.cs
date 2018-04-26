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

        [HttpGet]
        public IEnumerable<Comment> GetAllForPost(int postId)
        {
            return _service.GetAllForPost(postId);
        }

        /*[HttpPost("add")]
        public IActionResult Add(int postId, int authorId, string content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _service.Add(postId, authorId, content);


            return Ok(result);
        }*/
    }
}
