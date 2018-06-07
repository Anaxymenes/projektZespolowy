using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostHobbyController : Controller {
        private IPostHobbyService _postHobbyService;

        public PostHobbyController(IPostHobbyService postHobbyService) {
            _postHobbyService = postHobbyService;
        }

        [HttpGet("")]
        public List<PostHobby> GetAll() {
            return _postHobbyService.GetAll();
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult CreatePostHobby([FromBody] PostAdd postAdd) {
            if (postAdd == null) {
                return BadRequest("errorr");
            }
            _postHobbyService.CreatePostHobby(postAdd, ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
            return Ok();
        }

        [HttpGet("findHobbyPosts")]
        public List<PostDTO> GetAllPostsByHobbyId(int hobbyId) {
            return _postHobbyService.GetAllPostsByHobbyId(hobbyId);
        }

        [Authorize]
        [HttpGet("findUserHobbyPosts")]
        public List<PostDTO> GetAllPostsByUserHobbys()
        {
            return _postHobbyService.GetAllPostsByUserHobbys(ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
        }

    }
}
