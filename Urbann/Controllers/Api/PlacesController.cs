﻿using System;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var places = await _placeService.GetAllAsync();

            return Ok(places);
        }


        [HttpGet("Take")]
        public async Task<IActionResult> Get(int skip, int limit)
        {
            Thread.Sleep(2000);
            var places = await _placeService.GetAllAsync(limit, skip);

            return Ok(places);
        }


        [HttpGet("Search")]
        public async Task<IActionResult> Search(string name, string country, string category)
        {
            var places = await _placeService.SearchAsync(name, country, category );

            return Ok(places);
        }

        // GET: api/Places
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Places/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Places
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Places/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}