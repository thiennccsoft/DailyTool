using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTBLL.Controllers;
using DTValueObjects;

namespace DailyTool.Controllers.Admin
{
    [Route("quan-ly/[controller]")]
    [ApiController]
    public class UserManageController : ControllerBase
    {
        // GET: quan-ly/UserManage
        [HttpGet]
        public IEnumerable<vUsers> Get()
        {
            UserDTcontroller uControl = new UserDTcontroller();
            
            return uControl.GetAll();
        }

        // GET: quan-ly/UserManage/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return BadRequest();
            }
            else
            {
                UserDTcontroller uControl = new UserDTcontroller();
                vUsers user = uControl.GetbyId(id);
                if(user == null)
                {
                    return NotFound();
                }
                return new ObjectResult(user);
            }
        }

        // POST: quan-ly/UserManage
        [HttpPost]
        public IActionResult Post([FromBody] vUsers nuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                UserDTcontroller uControl = new UserDTcontroller();
                
                uControl.Insert(nuser);
                return new NoContentResult();
            }
            
        }

        // PUT: quan-ly/UserManage/5
        [HttpPut("{id}")]
        public IActionResult Put(string UserName, [FromBody] vUsers value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                UserDTcontroller uControl = new UserDTcontroller();
                uControl.Update(value);
                return new NoContentResult();
            }

        }

        // DELETE: quan-ly/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] vUsers value)
        {
            if(value.UserId == null || value.UserId == Guid.Empty)
            {
                return BadRequest();
            }
            else
            {
                UserDTcontroller uControl = new UserDTcontroller();
                uControl.Delete(value);
                return new NoContentResult();
            }
        }
    }
}
