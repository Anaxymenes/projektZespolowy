//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Data.DBModel;
//using Data.DTO;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Service.Services;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace WebAPI.Controllers
//{

//    public class CRUDPostController : Controller
//    {
//        private PostHobbyService _postHobbyService;

//        public CRUDPostController(PostHobbyService postHobbyService)
//        {
//            _postHobbyService = postHobbyService;
//        }

//        [HttpPost]
//        public IActionResult CreatePostHobby(PostDTO post)
//        {
//            if (post == null || ModelState.IsValid)
//            {
//                return BadRequest();
//            }
//            _postHobbyService.CreatePostHobby(post);
//            return Ok();
//        }
        

//        /*
//        [HttpPost]
//        public IActionResult AddEditPost(int? id, PostDTO model)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    bool isNew = !id.HasValue;
//                    PostDTO post = isNew ? new PostDTO
//                    {
//                        Date = DateTime.Now
//                    } : _postHobbyService.Set<PostDTO>().SingleOrDefault(x => x.Id == id.Value);
//                    post.Content = model.Content;
//                    post.Author = model.Author;
//                    post.Hobby = model.Hobby;
//                    post.Pictures = model.Pictures;
//                    post.Event = model.Event;
//                    if(isNew)
//                    {
//                        _postHobbyService.Add(post);
//                    }
//                    _postHobbyService.SaveChanges();
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return RedirectToAction("Index");
//        }
        
//        [HttpDelete]
//        public IActionResult DeletePost(int id, FormCollection form)
//        {
//            PostHobby post = _postHobbyService.Set<Customer>().SingleOrDefault(x => x.PostId == id);
//            _postHobbyService.Entry(post).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
//            _postHobbyService.SaveChanges();
//            return RedirectToAction("Index"); //????
//        }
//        */
//    }
//}