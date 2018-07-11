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
    [Route("Phan-quyen/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // GET: Phan-quyen/Roles
        [HttpGet]
        public List<vRoles> Getall()
        {
            return new RoleDTcotroller().GetAll();
        }

        // GET: Phan-quyen/Roles/5
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {
            RoleDTcotroller roleControl = new RoleDTcotroller();
            var role = roleControl.GetbyId(id);
            if(role == null)
            {
                return BadRequest();
            }
            return new  ObjectResult(role);
        }

        // POST: Phan-quyen/Roles
        [HttpPost]
        public IActionResult PostRole([FromBody] vRoles value)
        {
            RoleDTcotroller roleControl = new RoleDTcotroller();
            roleControl.Insert(value);
            return new NoContentResult();
        }

        // PUT: Phan-quyen/Roles/5
        [HttpPut("{id}")]
        public IActionResult PutRole(int id, [FromBody] vRoles value)
        {
            RoleDTcotroller roleControl = new RoleDTcotroller();
            roleControl.Update(value);
            return new NoContentResult();
        }
    }
}
