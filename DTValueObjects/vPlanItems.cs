using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObjects
{
    public class vPlanItems
    {
        public Guid Plan_ItemId { get; set; }
        
        public Guid PlanId { get; set; }
        
        public Guid ItemId { get; set; }
    }
}
