using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostHobbyController : Controller {
        private IPostHobbyService _postHobbyService;

        private PostHobbyService _context;

        public PostHobbyController(IPostHobbyService postHobbyService) {
            _postHobbyService = postHobbyService;
        }

        [HttpGet("")]
        public List<PostHobby> GetAll() {
            return _postHobbyService.GetAll();
        }

        [HttpPost("create")]
        public IActionResult CreatePostHobby([FromBody] PostDTO post)
        {
            if (post == null )
            {
                return BadRequest("errorr");
            }
            _postHobbyService.CreatePostHobby(post);
            return Ok();
        }

        [HttpGet("findHobbyPosts")]
        public List<PostDTO> GetAllPostsByHobbyId(int hobbyId)
        {
           return _postHobbyService.GetAllPostsByHobbyId(hobbyId);
        }
    }
}
