using pu_system_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pu_system_test.GlobalMethods
{
    public class LoadInternships
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public SelectList LoadDropDownInternship(object selectedInternship = null)
        {
            var listInternship = from i in context.Internships select i;
            return new SelectList(listInternship, "InternshipId", "Firm", selectedInternship);
        }
    }
}