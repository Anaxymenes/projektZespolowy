using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService) {
            this._searchService = searchService;
        }

        [HttpGet("{value}")]
        public IActionResult GetSearchResult(string value) {
            return BadRequest();
        }
    }
}
