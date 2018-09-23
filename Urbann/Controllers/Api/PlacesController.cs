using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urbann.Services;

namespace Urbann.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var place = await _placeService.GetAsync(id);
            return Ok(place);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var places = await _placeService.GetAllAsync();

            return Ok(places);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string name, string country, string category)
        {
            var places = await _placeService.SearchAsync(name, country, category );

            return Ok(places);
        }

        [HttpGet("SearchComplex")]
        public async Task<IActionResult> SearchComplex(string name, [FromQuery(Name = "country")] string[] countries, [FromQuery(Name = "category")] string[] categories, int limit, int skip = 0)
        {
            var places = await _placeService.SearchAsync(name, countries, categories, limit, skip);

            Thread.Sleep(1555);
            return Ok(places);
        }


        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Places/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
