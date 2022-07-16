using GeoPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = GetUser();
            return Ok(users);
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
