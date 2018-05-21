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
    public class PostHobbyController : Controller {
        private IPostHobbyService _postHobbyService;

        public PostHobbyController(IPostHobbyService postHobbyService) {
            _postHobbyService = postHobbyService;
        }

        [HttpGet("")]
        public List<PostHobby> GetAll() {
            return _postHobbyService.GetAll();
        }
        
        //public List<PostDTO> GetAllPostsByHobbyId(int id)
        //{
        //    return _postHobbyService.GetAllPostsByHobbyId(id);
        //}
    }
}
