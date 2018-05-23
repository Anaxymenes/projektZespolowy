using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("add")]
        public Post Add(PostDTO postDTO)
        {
            return _postService.Add(postDTO);
        }

        [HttpPost("test")]
        public void Test()
        {
            Post post = new Post();
            post.AuthorId = 1;
            post.PostTypeId = 1;
            post.Content = "ddddddud";
            post.Date = DateTime.Now;
            _postService.Test(post);
        }

    }
}
