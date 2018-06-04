using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pu_system_test.Models
{
    public class UserProfile
    {
        [Key]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        public bool ProfileCreated { get; set; }
    }
}