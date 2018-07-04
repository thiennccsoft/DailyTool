using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace DTValueObjects
{
    public class vItems
    {
        public vItems()
        {
            
        }

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
    }
}
