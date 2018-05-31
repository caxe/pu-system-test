using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using pu_system_test.Models;

namespace pu_system_test.Controllers
{
	public class RolesController : Controller
	{
		ApplicationDbContext context = new ApplicationDbContext();

		// GET: Roles
		[Authorize(Roles = "Admin")]
		public ActionResult Index()
		{
			var roles = context.Roles.ToList();
			return View(roles);
		}

		// GET: Roles/Create
		[Authorize(Roles = "Admin")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Roles/Create
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					context.Roles.Add(new IdentityRole { Name = collection["RoleName"].ToString() });
					context.SaveChanges();
				}
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Roles/Edit/5
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(string id)
		{
			if (String.IsNullOrEmpty(id))
			{
				return HttpNotFound();
			}
			var role = context.Roles.Find(id);
			if (role == null)
			{
				return HttpNotFound();
			}

			return View(role);
		}

		// POST: Roles/Edit/5
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(IdentityRole role)
		{
			try
			{
				if (ModelState.IsValid)
				{
					context.Entry(role).State = EntityState.Modified;
					context.SaveChanges();
				}
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Roles/Delete/5
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(string id)
		{
			if (String.IsNullOrEmpty(id))
			{
				return HttpNotFound();
			}
			var role = context.Roles.Find(id);
			if (role == null)
			{
				return HttpNotFound();
			}

			return View(role);
		}

		// POST: Roles/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(string id, FormCollection collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var role = context.Roles.Find(id);
					context.Roles.Remove(role);
					context.SaveChanges();
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		[Authorize(Roles = "Admin")]
		public ActionResult ManageRoleToUser()
		{
			var listRole = context.Roles.Select(e => new SelectListItem { Text = e.Name, Value = e.Name });
			var filteredListRole = listRole.Where(role => role.Value != "Admin");
			ViewBag.ListRoleName = filteredListRole;

			return View();
		}

		[Authorize(Roles = "Admin")]
		public ActionResult AddRoleToUser(string UserName, string RoleName)
		{
			IdentityUser user = context.Users.Where(e => e.UserName == UserName).FirstOrDefault();

			var _UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			_UserManager.AddToRole(user.Id, RoleName);

			var listRole = context.Roles.Select(e => new SelectListItem { Text = e.Name, Value = e.Name });
			var filteredListRole = listRole.Where(role => role.Value != "Admin");
			ViewBag.ListRoleName = filteredListRole;

			return View("ManageRoleToUser");
		}
	}
}
