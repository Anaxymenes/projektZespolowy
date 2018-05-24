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

        [HttpDelete("delete")]
        public void Delete(int id)
        {
            _postService.Delete(id);
        }

        [HttpPost("test")]
        public void Test()
        {
            Post post = new Post();
            post.AuthorId = 1;
            post.PostTypeId = 1;
            post.Content = "Testowa treść...";
            post.Date = DateTime.Now;
            _postService.Test(post);
        }

        [HttpGet("getPost")]
        public PostDTO GetPost(int id)
        {
            return _postService.GetPost(id);
        }

        [HttpGet("getPosts")]
        public List<Post> GetPosts()
        {
            return _postService.GetPosts();
        }

    }
}
