using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        [HttpGet("[action]")]
        public void Insert()
        {
            DailyDBContext db = new DailyDBContext();
            Guid g = Guid.Parse("b0a22c23-1ea8-48ba-ae1b-08d5dcb1beaf");
            Items item = db.Items.Where(a => a.PlanId == g).Single();
            item.Name = "hahahahhahah";
            db.Items.Attach(item);
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
