﻿using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Examples;
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
        private readonly IAccountHobbyService _accountHobbyService;

        public PostHobbyController(IPostHobbyService postHobbyService,
                                   IAccountHobbyService accountHobbyService) {
            _postHobbyService = postHobbyService;
            _accountHobbyService = accountHobbyService;
        }

        [HttpGet("")]
        public List<PostDTO> GetAll() {
            return _postHobbyService.GetAll();
        }

        [HttpGet("findHobbyPosts/{hobbyId}")]
        public List<PostDTO> GetAllPostsByHobbyId(int hobbyId)
        {
            return _postHobbyService.GetAllPostsByHobbyId(hobbyId);
        }


        [Authorize]
        [HttpGet("findUserHobbyPosts")]
        public List<PostDTO> GetAllPostsByUserHobbys()
        {
            return _postHobbyService.GetAllPostsByUserHobbys(ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
        }
        
        [HttpGet("getUserPosts/{authorId}")]
        public IActionResult GetUserPostByAuthorId(int authorId)
        {
            var result = _postHobbyService.GetAllPostByAuthorId(authorId);
            if (result == null)
                return BadRequest();
            return Ok(result);
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
        
        [Authorize]
        [HttpPost("joinToGroup/{hobbyId}")]
        public IActionResult JoinToGroup(int hobbyId)
        {
            if (_accountHobbyService.JoinToGroup(hobbyId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims))) 
                return Ok();
            return BadRequest("Coś poszło nie tak.");
        }

        [Authorize]
        [HttpPost("leaveGroup/{hobbyId}")]
        public IActionResult leaveGroup(int hobbyId)
        {
            if (_accountHobbyService.leaveGroup(hobbyId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok();
            return BadRequest("Coś poszło nie tak.");
        }


        [Authorize]
        [HttpPost("upload")]
        [AddSwaggerFileUploadButton]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string result = await _postHobbyService.UploadFile(file);
            if (result != "")
                return Ok(result);
            return BadRequest();
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult Update([FromBody] PostEdit postEdit)
        {
            if (_postHobbyService.Update(postEdit, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok("Edytowano pomyślnie.");
            return BadRequest("Coś poszło nie tak.");
        }

        [Authorize]
        [HttpDelete("delete/{postId}")]
        public IActionResult Delete(int postId)
        {
            if (_postHobbyService.Delete(postId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok("Post został pomyślnie usunięty.");
            return BadRequest("Coś poszło nie tak...");

        }
        
    }
}
