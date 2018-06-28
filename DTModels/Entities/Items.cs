using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Entities
{
    public class Items
    {
        [Key]
        public Guid PlanId { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required]
        public float Finish { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime Created_At { get; set; }

        [Required]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        public Items(Guid planId, string description, float finish, DateTime created_At, string name)
        {
            PlanId = planId;
            Description = description;
            Finish = finish;
            Created_At = created_At;
            Name = name;
        }

        public Items()
        {
        }

        public virtual ICollection<Report_Items> Report_Items { get; set; }
    }
}
