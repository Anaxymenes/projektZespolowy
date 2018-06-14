using Data.Add;
using Data.DBModel;
using Data.DTO;
using Data.EditViewModel;
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
    public class CommentController : Controller{

        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService) {
            _commentService = commentService;
        }

        [Authorize]
        [HttpPost("add")]
        public IActionResult Add([FromBody]CommentAdd commentAdd)
        {
            var result = _commentService.Add(commentAdd, ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
            if (result != null)
                return Ok(result);
            return BadRequest("Nie ma takiego posta.");
        }

        [Authorize]
        [HttpDelete("delete/{commentId}")]
        public IActionResult Delete(int commentId)
        {
            if (_commentService.Delete(commentId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok();
            return BadRequest("Nie ma takiego komentarza");
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult Edit([FromBody]CommentEditV2 commentEdit)
        {
            var result = _commentService.Edit(commentEdit, ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
            if (result != null)
                return Ok(result);
            return BadRequest("Błąd podczas edytowania danych.");
        }
    }
}
