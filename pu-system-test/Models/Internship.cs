using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pu_system_test.Models
{
    public class Internship
    {
        [Key]
        public int InternshipId { get; set; }

        public int FirmId { get; set; }
        public virtual Firm Firm { get; set; }

        [Required]
        public int Spots { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Technologies { get; set; }
    }
}