using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Controllers
{
    public class AssignedProjectsController : Controller
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        // GET: AssignedProjects
        public ActionResult Index()
        {
            var assignedProjects = db.AssignedProjects.Include(a => a.Project).Include(a => a.Staff);
            return View(assignedProjects.ToList());
        }

        // GET: AssignedProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedProject assignedProject = db.AssignedProjects.Find(id);
            if (assignedProject == null)
            {
                return HttpNotFound();
            }
            return View(assignedProject);
        }

        // GET: AssignedProjects/Create
        public ActionResult Create()
        {
            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.FK_StaffID = new SelectList(db.Staffs, "StaffID", "FirstName");
            return View();
        }

        // POST: AssignedProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignedProjectsID,FK_StaffID,FK_ProjectID")] AssignedProject assignedProject)
        {
            if (ModelState.IsValid)
            {
                db.AssignedProjects.Add(assignedProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", assignedProject.FK_ProjectID);
            ViewBag.FK_StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", assignedProject.FK_StaffID);
            return View(assignedProject);
        }

        // GET: AssignedProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedProject assignedProject = db.AssignedProjects.Find(id);
            if (assignedProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", assignedProject.FK_ProjectID);
            ViewBag.FK_StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", assignedProject.FK_StaffID);
            return View(assignedProject);
        }

        // POST: AssignedProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignedProjectsID,FK_StaffID,FK_ProjectID")] AssignedProject assignedProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", assignedProject.FK_ProjectID);
            ViewBag.FK_StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", assignedProject.FK_StaffID);
            return View(assignedProject);
        }

        // GET: AssignedProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedProject assignedProject = db.AssignedProjects.Find(id);
            if (assignedProject == null)
            {
                return HttpNotFound();
            }
            return View(assignedProject);
        }

        // POST: AssignedProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedProject assignedProject = db.AssignedProjects.Find(id);
            db.AssignedProjects.Remove(assignedProject);
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
