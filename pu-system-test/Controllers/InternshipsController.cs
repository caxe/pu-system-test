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
    public class InternshipsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

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
        public ActionResult Create()
        {
            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName");
            return View();
        }

        // POST: Internships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InternshipId,FirmId,Spots,Technologies")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                context.Internships.Add(internship);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName", internship.FirmId);
            return View(internship);
        }

        // GET: Internships/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName", internship.FirmId);
            return View(internship);
        }

        // POST: Internships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InternshipId,FirmId,Spots,Technologies")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                context.Entry(internship).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmId = new SelectList(context.Firms, "FirmId", "FirmName", internship.FirmId);
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
    }
}
