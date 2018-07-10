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
    public class PlanItemsController : ControllerBase
    {
        // GET: api/PlanItems
        [HttpGet]
        public IEnumerable<vPlanItems> Get()
        {
            return new PlanItemDTcontroller().GetAll();
        }

        // GET: api/PlanItems/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return BadRequest();
            }
            else
            {
                PlanItemDTcontroller planitemdt = new PlanItemDTcontroller();
                var planitem = planitemdt.GetbyId(id);
                if (planitem == null)
                {
                    return NotFound();
                }
                return new ObjectResult(planitem);
            }
        }

        // POST: api/PlanItems
        [HttpPost]
        public IActionResult Post([FromBody] vPlanItems value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                PlanItemDTcontroller planitemdt = new PlanItemDTcontroller();

                planitemdt.Insert(value);
                return new NoContentResult();
            }
        }
    }
}
