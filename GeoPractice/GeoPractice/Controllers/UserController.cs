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
    public class UserController : ControllerBase
    {
        private GeoDBContext _dbContext;

        public UserController(GeoDBContext geoDBContext)
        {
            _dbContext = geoDBContext;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            try {
                var users = _dbContext.Usuario.ToList();

                return (users.Count == 0) ? StatusCode(404, "No users found") : Ok(users);
            }
            catch (Exception e) { Console.WriteLine( e.ToString()); return StatusCode(500, "Oops, an errors has ocurred :("); }

            //return Ok();
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserRequest userRequest)
        { 
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserRequest userRequest)
        {
            return Ok();
        }

        [HttpDelete("DeleteUser/{IdUser}")]
        public IActionResult DeleteUser(int IdUser)
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
