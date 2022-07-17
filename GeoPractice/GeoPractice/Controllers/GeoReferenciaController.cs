using GeoPractice.Data;
using GeoPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoReferenciaController : ControllerBase
    {
        private GeoDBContext _dbContext;

        public GeoReferenciaController(GeoDBContext geoDBContext)
        {
            _dbContext = geoDBContext;
        }

        [HttpGet("GetGeodata")]
        public IActionResult GetGeodata()
        {
            try {
                var geoData = _dbContext.GeorReferencia.ToList();

                return (geoData.Count == 0) ? StatusCode(404, "No users found") : Ok(geoData);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); return StatusCode(500, "Oops, an errors has ocurred :("); }

            
        }

        [HttpPost("CreateGeodata")]
        public IActionResult CreateGeodata([FromBody] UserRequest userRequest)
        {
            return Ok();
        }

        [HttpPut("UpdateGeodata")]
        public IActionResult UpdateGeodata([FromBody] UserRequest userRequest)
        {
            return Ok();
        }

        [HttpDelete("DeleteGeodata/{IdGeodata}")]
        public IActionResult DeleteGeodata(int IdUser)
        {
            return Ok();
        }


        private List<UserRequest> GetUser()
        {
            return new List<UserRequest>
            {
                new UserRequest { UserName = "Pablo.Net", DateBirthday = "06/02/03", Id = 1, Password = "12345", RFC = "00000000000"}
            };
        }
    }
}
