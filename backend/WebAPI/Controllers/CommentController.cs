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
    public class CommentController{

        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService) {
            _commentService = commentService;
        }

        [HttpPost("add")]
        public Comment Add([FromBody]CommentDTO commentDto)
        {
            return _commentService.Add(commentDto);
        }

        [HttpDelete("delete")]
        public void Delete(int id, int accountId)
        {
            _commentService.Delete(id, accountId);
        }
    }
}
