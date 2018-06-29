using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Database
{
    public class Plan_Items
    {
        [Key]
        public Guid Plan_ItemId { get; set; }
        [Required]
        public Guid PlanId { get; set; }
        [Required]
        public Guid ItemId { get; set; }

        public Plans Plans { get; set; }
        public Items Items { get; set; }
        public Plan_Items(Guid idplan_item, Guid planid, Guid itemid)
        {
            Plan_ItemId = idplan_item;
            PlanId = planid;
            ItemId = itemid;
        }

        public Plan_Items()
        {
        }

    }
}