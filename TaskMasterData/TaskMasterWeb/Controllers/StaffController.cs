using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.Models;
using TaskMasterWeb.ViewModels.Employees;

namespace TaskMasterWeb.Controllers
{
    public class StaffController : Controller
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        // GET: Staff
        public ActionResult Index()
        {
            var staffs = db.Staffs.Include(s => s.StaffRole);
            return View(staffs.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new EmployeeDashboardViewModel(id);

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            var viewModel = new EmployeeCreateViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = new EmployeeCreateViewModel();

                return View(viewModel);
            }

            var staff = viewModel.CopyToModel(viewModel); 

            // Save to DB
            db.Staffs.Add(staff);
            db.SaveChanges();

            return RedirectToAction("Index", "Staff");
           
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_StaffRoleID = new SelectList(db.StaffRoles, "StaffRoleID", "RoleName", staff.FK_StaffRoleID);
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,FK_StaffRoleID,FirstName,LastName,ContactNumber,EmailAddress")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_StaffRoleID = new SelectList(db.StaffRoles, "StaffRoleID", "RoleName", staff.FK_StaffRoleID);
            return View(staff);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
