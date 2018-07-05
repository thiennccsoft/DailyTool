using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Database
{
    public class Items
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime Created_At { get; set; }

       
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày hoàn thành")]
        public DateTime? Finish_At { get; set; }

        public Items()
        {
        }

        public Items(Guid itemId, string title, string description, int status, DateTime created_At, DateTime finish_At)
        {
            ItemId = itemId;
            Title = title;
            Description = description;
            Status = status;
            Created_At = created_At;
            Finish_At = finish_At;
        }

        public virtual ICollection<Plan_Items> Plan_Items { get; set; }
    }
}