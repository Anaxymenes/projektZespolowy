<<<<<<< HEAD
﻿using Data.DBModel;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
=======
﻿
using Data.DBModels;
using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;
>>>>>>> parent of 907ef6e... Many changes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace WebAPI.Controllers
=======
namespace WebApi.Controllers
>>>>>>> parent of 907ef6e... Many changes
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
<<<<<<< HEAD
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
=======
        private IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<PostDTO> GetAll()
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
>>>>>>> parent of 907ef6e... Many changes
