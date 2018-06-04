using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pu_system_test.Models
{
    public class Practice
    {
        [Key]
        public int PracticeId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 1)]
        public string PracticeName { get; set; }

        [Required]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public int InternshipId { get; set; }
        public virtual Internship Internships { get; set; }
    }
}