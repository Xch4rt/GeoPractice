using GeoPractice.Data;
using GeoPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            tblUser user = new tblUser();
            user.Contraseña = userRequest.Password;
            user.Nombre = userRequest.UserName;
            user.FechaNacimiento = userRequest.DateBirthday;
            user.RFC = userRequest.RFC;

            try 
            { 
                _dbContext.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception) { return StatusCode(500, "An error has ocurred:("); }

            var users = _dbContext.Usuario.ToList();
            return Ok(users);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserRequest userRequest)
        {
            try 
            {
                var user = _dbContext.Usuario.FirstOrDefault(x => x.IdUsuario == userRequest.Id);

                if (user == null) { return StatusCode(404, "User not found"); }

                user.Contraseña = userRequest.Password;
                user.Nombre = userRequest.UserName;
                user.FechaNacimiento = userRequest.DateBirthday;
                user.RFC = userRequest.RFC;

                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception) { return StatusCode(500, "An error has ocurred:("); }

            var users = _dbContext.Usuario.ToList();
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{IdUser}")]
        public IActionResult DeleteUser([FromRoute] int IdUser)
        {
            try 
            {
                var user = _dbContext.Usuario.FirstOrDefault(x => x.IdUsuario == IdUser);

                if (user == null) { return StatusCode(404, "User not found"); }

                _dbContext.Entry(user).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception) { return StatusCode(500, "An error has ocurred:("); }

            var users = _dbContext.Usuario.ToList();
            return Ok(users);
        }


        
    }
}
