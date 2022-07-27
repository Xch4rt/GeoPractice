using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using GeoPractice.Models;
using GeoPractice.Data;
using Microsoft.EntityFrameworkCore;

namespace GeoPractice.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private GeoDBContext _dbContext;
        private static Random random = new Random();
        private string domain = @"https://pablo.com/";
        public UrlShortenerController(GeoDBContext geoDBContext)
        {
            _dbContext = geoDBContext;
        }
        

        [HttpGet("{code}")]
        public IActionResult GetOriginalUrl([FromRoute] string code)
        {
            try {
                var url = _dbContext.UrlShort.FirstOrDefault(x => x.ShortURL == code);

                if (url == null) { return StatusCode(404, "User not found"); }
                return new RedirectResult(@"https://www.google.com");
            }
            catch (Exception) { return StatusCode(500, "An error has ocurred:("); }
        }

        [HttpPost("CreateUrl")]
        public IActionResult Create([FromBody] UrlModel urlReq)
        {
            tblUrl url = new tblUrl();
            url.Url_ = urlReq.Url;
            url.ShortURL = RepeatCode(RandomString());


            var urlSearch = _dbContext.UrlShort.FirstOrDefault(x => x.Url_ == urlReq.Url);
            if (urlSearch != null) { return Ok(); }

            try {
                _dbContext.Add(url);
                _dbContext.SaveChanges();
            }
            catch (Exception) { return StatusCode(500, "An error has ocurred:("); }

            var urls = _dbContext.UrlShort.ToList();
            
            return Ok($"{domain}"+url.ShortURL);
        }

        
        private  string RepeatCode(string code_)
        {
            var code = _dbContext.UrlShort.FirstOrDefault(x => x.ShortURL == code_);
            
            if (code != null) {
                var shurl = code.ShortURL;
                bool flag = true;
                while (flag == true) {
                    code_ = RandomString();
                    if (code_ != shurl) { flag = false; break; }
                }
                return code_;
            }
            return code_;
        }


        private static string RandomString()
        {
            int length = 7;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        
    }
}
