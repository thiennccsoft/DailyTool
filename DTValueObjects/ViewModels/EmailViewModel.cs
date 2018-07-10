using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObjects.ViewModels
{
    public class EmailViewModel
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
