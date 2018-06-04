using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pu_system_test.Models
{
    public class Student
    {
        [Key]
        [Required]
        [Display(Name = "Faculty Number")]
        [StringLength(10, MinimumLength = 10)]
        public string StudentFN { get; set; }

        [Required]
        [Display(Name ="Frist name")]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        public int AssignedTo { get; set; }
        public virtual Firm Firm { get; set; }
    }
}