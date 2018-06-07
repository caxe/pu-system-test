using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using pu_system_test.Models;

namespace pu_system_test.Controllers
{
    [Authorize(Roles = "Firm")]
    public class InternshipsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        // GET: Internships
        public ActionResult Index()
        {
            var internships = context.Internships.Include(i => i.Firm);
            return View(internships.ToList());
        }

        // GET: Internships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internship internship = context.Internships.Find(id);
            if (internship == null)
            {
                return HttpNotFound();
            }
            return View(internship);
        }

        // GET: Internships/Create
        public async System.Threading.Tasks.Task<ActionResult> Create()
        {
            var currentUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var user = context.Users.First(x => x.Id == currentUser.Id);
            var input = user.UserName;
            var pattern = @"@";
            String[] elements = Regex.Split(input, pattern);
            //ViewBag.FirmId = context.Firms.Where(f => f.FirmName == user.UserName);
            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName")
                .Where(i => i.Text == elements[0]);
            return View();
        }

        // POST: Internships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "InternshipId,FirmId,Spots,Technologies")] Internship internship)
        {
            var currentUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var user = context.Users.First(x => x.Id == currentUser.Id);
            var input = user.UserName;
            var pattern = @"@";
            String[] elements = Regex.Split(input, pattern);
            if (ModelState.IsValid)
            {
                
                context.Internships.Add(internship);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.FirmId = context.Firms.Where(f => f.FirmName == user.UserName);
            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName")
                .Where(i => i.Text == elements[0]);
            return View(internship);
        }

        // GET: Internships/Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internship internship = context.Internships.Find(id);
            if (internship == null)
            {
                return HttpNotFound();
            }
            var currentUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var user = context.Users.First(x => x.Id == currentUser.Id);
            var input = user.UserName;
            var pattern = @"@";
            String[] elements = Regex.Split(input, pattern);
            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName")
                .Where(i => i.Text == elements[0]);
            return View(internship);
        }

        // POST: Internships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Edit([Bind(Include = "InternshipId,FirmId,Spots,Technologies")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                context.Entry(internship).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            var currentUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var user = context.Users.First(x => x.Id == currentUser.Id);
            var input = user.UserName;
            var pattern = @"@";
            String[] elements = Regex.Split(input, pattern);
            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName")
                .Where(i => i.Text == elements[0]);
            return View(internship);
        }

        // GET: Internships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internship internship = context.Internships.Find(id);
            if (internship == null)
            {
                return HttpNotFound();
            }
            return View(internship);
        }

        // POST: Internships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Internship internship = context.Internships.Find(id);
            context.Internships.Remove(internship);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}
