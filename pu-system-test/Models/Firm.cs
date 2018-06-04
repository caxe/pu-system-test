using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pu_system_test.Models
{
    public class Firm
    {
        [Key]
        public int FirmId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 1)]
        public string FirmName { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string Address { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
    }
}