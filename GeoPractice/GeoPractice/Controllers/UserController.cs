using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok();
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser()
        { 
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser()
        {
            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser()
        { 
            return Ok();
        }
    }
}
