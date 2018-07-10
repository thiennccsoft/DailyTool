using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTValueObjects;
using DTBLL.Controllers;

namespace DailyTool.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        // GET: api/Plans
        [HttpGet]
        public IEnumerable<vPlans> Get()
        {
            return new PlanDTcontroller().GetAll();
        }

        // GET: api/Plans/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            if(id == null || id == Guid.Empty)
            {
                return BadRequest();
            }
            else
            {
                PlanDTcontroller plandt = new PlanDTcontroller();
                var plan = plandt.GetbyId(id);
                if(plan == null)
                {
                    return NotFound();
                }
                return new ObjectResult(plan);
            }
        }

        // POST: api/Plans
        [HttpPost]
        public IActionResult Post([FromBody] vPlans value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                PlanDTcontroller plandt = new PlanDTcontroller();
                plandt.Insert(value);
                return new NoContentResult();
            }
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] vPlans value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                PlanDTcontroller plandt = new PlanDTcontroller();
                plandt.Update(value);
                return new NoContentResult();
            }
        }
    }
}
