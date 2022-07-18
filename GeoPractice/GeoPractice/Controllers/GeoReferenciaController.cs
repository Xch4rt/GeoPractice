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
        public IActionResult CreateGeodata([FromBody] GeoReferenciasRequest geoRequest)
        {
            tblGeodata geoData = new tblGeodata();
            geoData.IdEstado = geoRequest.IdEstado;
            geoData.Latitud = geoRequest.Latitud;
            geoData.Longitud = geoRequest.Longitud;
            

            try {
                _dbContext.Add(geoData);
                _dbContext.SaveChanges();
            }
            catch (Exception) { return StatusCode(500, "An error has ocurred:("); }

            var geoDatas = _dbContext.GeorReferencia.ToList();
            return Ok(geoDatas);
        }

        [HttpPut("UpdateGeodata")]
        public IActionResult UpdateGeodata([FromBody] GeoReferenciasRequest geoRequest)
        {
            return Ok();
        }

        [HttpDelete("DeleteGeodata/{IdGeodata}")]
        public IActionResult DeleteGeodata(int IdGeo)
        {
            return Ok();
        }


        
    }
}
