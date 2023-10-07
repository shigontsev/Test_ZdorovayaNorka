using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using ZdorovayaNorka.Common.Helpers;
using ZdorovayaNorka.DAL;

namespace ZdorovayaNorka.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        private ApplicationDBContext _db;

        [HttpGet("Get/{id}")]
        public string Get(int id)
        {
            string name = "";
            
            using (_db = new ApplicationDBContext())
            {
                name =  _db.Positions.FirstOrDefault(x=>x.Id == id).Name;
                var a = _db.Shifts;
            }
            return name;
        }

        [HttpGet("GetAllPosition")]
        public IActionResult GetAllPosition()
        {

            using (_db = new ApplicationDBContext())
            {
                //return Ok(_db.Positions.Include(u=>u.Employees).ToList());
                var a = JsonHelper.Serialize(_db.Positions.Include(u => u.Employees).ToList());
                return Ok(a);
            }
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {

            using (_db = new ApplicationDBContext())
            {
                //var a = _db.Employees.Include(u => u.Position).ToList();
                var a = JsonHelper.Serialize(_db.Employees.Include(u => u.Position).ToList());
                return Ok(a);
            }
        }
    }
}
