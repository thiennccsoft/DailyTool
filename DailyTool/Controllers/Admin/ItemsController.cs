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
    public class ItemsController : ControllerBase
    {
        // GET: api/Items
        [HttpGet]
        public IEnumerable<vItems> Get()
        {
            return new ItemDTcontroller().GetAll();
        }

        // GET: api/Items/5
        [HttpGet("{id}", Name = "Getbyrole")]
        public IActionResult Get(Guid id)
        {
            if(id == null || id == Guid.Empty)
            {
                return BadRequest();
            }
            ItemDTcontroller itemdt = new ItemDTcontroller();
            var item = itemdt.GetbyId(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Items
        [HttpPost]
        public IActionResult Post([FromBody] vItems value)
        {
            if (ModelState.IsValid)
            {
                ItemDTcontroller itemdt = new ItemDTcontroller();
                itemdt.Insert(value);
                return new NoContentResult();
            }
            return BadRequest();
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public IActionResult Put(string title, [FromBody] vItems value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                ItemDTcontroller itemdt = new ItemDTcontroller();
                itemdt.Update(value);
                return new NoContentResult();
            }
        }
    }
}
