using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTValueObjects;
using DTBLL.Controllers;
namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        ItemDTcontroller itemDT = new ItemDTcontroller();
        ReportDTcontroller reportDT = new ReportDTcontroller();
        PlanDTcontroller planDT = new PlanDTcontroller();
        [HttpPost("insert-item")]
        public IActionResult Insert([FromBody] vItems item)
        {
            vItems vItem = new vItems
            {
                Created_At = DateTime.Now.Date,
                Status = 0,
                Finish_At = item.Finish_At,
                Description = item.Description,
                Title = item.Title
            };
            if (itemDT.Insert(vItem))
                return new OkObjectResult(vItem);
            else return new OkObjectResult("Insert failed");
        }
        [HttpPost("insert-report")]
        public IActionResult InsertReport([FromBody] vReports report)
        {
            if (reportDT.Insert(report))
                return new OkObjectResult(report);
            else return new OkObjectResult("Insert failed");
        }

        //insert plan
        [HttpPost("insert-plan")]
        public IActionResult InsertPlan([FromBody]vPlans plan)
        {
            if (planDT.Insert(plan))
                return new OkObjectResult(plan);
            else return new OkObjectResult("Insert failed");
        }        

        //get item no finish
        [HttpGet("get-item")]
        public IEnumerable<vItems> GetItem()
        {            
            return itemDT.GetItemsNoFinish();
        }
    }
}