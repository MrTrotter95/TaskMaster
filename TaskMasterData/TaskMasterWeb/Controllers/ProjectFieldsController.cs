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
    public class ProjectFieldsController : Controller
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        // GET: ProjectFields
        public ActionResult Index()
        {
            var projectFields = db.ProjectFields.Include(p => p.Project);
            return View(projectFields.ToList());
        }

        // GET: ProjectFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectField projectField = db.ProjectFields.Find(id);
            if (projectField == null)
            {
                return HttpNotFound();
            }
            return View(projectField);
        }

        // GET: ProjectFields/Create
        public ActionResult Create()
        {
            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: ProjectFields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldID,FK_ProjectID,FieldValue")] ProjectField projectField)
        {
            if (ModelState.IsValid)
            {
                db.ProjectFields.Add(projectField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectField.FK_ProjectID);
            return View(projectField);
        }

        // GET: ProjectFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectField projectField = db.ProjectFields.Find(id);
            if (projectField == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectField.FK_ProjectID);
            return View(projectField);
        }

        // POST: ProjectFields/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FieldID,FK_ProjectID,FieldValue")] ProjectField projectField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectField.FK_ProjectID);
            return View(projectField);
        }

        // GET: ProjectFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectField projectField = db.ProjectFields.Find(id);
            if (projectField == null)
            {
                return HttpNotFound();
            }
            return View(projectField);
        }

        // POST: ProjectFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectField projectField = db.ProjectFields.Find(id);
            db.ProjectFields.Remove(projectField);
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
