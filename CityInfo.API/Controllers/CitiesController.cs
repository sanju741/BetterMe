using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    //uses controller name as route 
    //[Route("api/[controller]")]
    public class CitiesController : Controller
    {
        public CitiesController()
        {

        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            var result = new List<Object>
            {
                new {Id = 1, Name = "Kathmandu"},
                new {Id = 2, NameOfVillage = "Biratchowk"}
            };

            //return new JsonResult(result);

            //returns result with 200 status code
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var result = new
            {
                Id = id,
                Name = $"City{id}"
            };

            //if id is 7 , let's suppose it is null
            //just for test
            if (id == 7)
                return NotFound();

            return Ok(result);




        }
    }
}
