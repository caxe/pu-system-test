using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pu_system_test.Models;

namespace pu_system_test.Controllers
{
    public class PracticesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Practices
        public ActionResult Index()
        {
            var practices = context.Practices.Include(p => p.Internships);
            return View(practices.ToList());
        }

        // GET: Practices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = context.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }
        
        // GET: Practices/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Practices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PracticeId,PracticeName,StartDate,EndDate")] Practice practice)
        {
            if (ModelState.IsValid)
            {
                context.Practices.Add(practice);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practice);
        }

        // GET: Practices/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = context.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // POST: Practices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PracticeId,PracticeName,StartDate,EndDate")] Practice practice)
        {
            if (ModelState.IsValid)
            {
                context.Entry(practice).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practice);
        }

        // GET: Practices/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = context.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // POST: Practices/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Practice practice = context.Practices.Find(id);
            context.Practices.Remove(practice);
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

        public ActionResult Join()
        {
            if (ModelState.IsValid)
            {
                var practice = new Practice
                {
                    InternshipId = 4
                };
                context.Practices.Attach(practice);
                var entry = context.Entry(practice);
                entry.Property(e => e.InternshipId).IsModified = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
