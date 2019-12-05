using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesSchoolController : Controller
    {
        public class MyClass
        {
            public int CityId { get; set; }
            public string SchoolName { get; set; }
            public int SchoolId { get; set; }
        }

        [HttpGet("{cityId}/schools")]
        public IActionResult GetSchoolsOfCity(int cityId)
        {
            //we assume city with 7 do not exist
            //just for testing
            if (cityId == 7)
                return NotFound();

            return Ok(new List<MyClass>
            {
                new MyClass {CityId = 1, SchoolName = "Subijimur", SchoolId = 1},
                new MyClass {CityId = 1, SchoolName = "BrightFuture", SchoolId = 2}
            });
        }

        [HttpGet("{cityId}/schools/{schoolid}")]
        public IActionResult GetSchool(int cityId, int schoolId)
        {
            if (cityId == 7)
                return NotFound("No Such city");
            if (schoolId == 7)
                return NotFound("no Such School");

            return Ok(new { CityId = 1, SchoolName = "Subijimur", SchoolId = 1 });

        }
    }
}
