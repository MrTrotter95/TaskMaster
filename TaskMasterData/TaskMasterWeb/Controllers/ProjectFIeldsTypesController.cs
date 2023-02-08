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
    public class ProjectFIeldsTypesController : Controller
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        // GET: ProjectFIeldsTypes
        public ActionResult Index()
        {
            var projectFIeldsTypes = db.ProjectFIeldsTypes.Include(p => p.ProjectField);
            return View(projectFIeldsTypes.ToList());
        }

        // GET: ProjectFIeldsTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFIeldsType projectFIeldsType = db.ProjectFIeldsTypes.Find(id);
            if (projectFIeldsType == null)
            {
                return HttpNotFound();
            }
            return View(projectFIeldsType);
        }

        // GET: ProjectFIeldsTypes/Create
        public ActionResult Create()
        {
            ViewBag.FK_FieldID = new SelectList(db.ProjectFields, "FieldID", "FieldValue");
            return View();
        }

        // POST: ProjectFIeldsTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldTypeID,FK_FieldID,FieldTypeValue")] ProjectFIeldsType projectFIeldsType)
        {
            if (ModelState.IsValid)
            {
                db.ProjectFIeldsTypes.Add(projectFIeldsType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_FieldID = new SelectList(db.ProjectFields, "FieldID", "FieldValue", projectFIeldsType.FK_FieldID);
            return View(projectFIeldsType);
        }

        // GET: ProjectFIeldsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFIeldsType projectFIeldsType = db.ProjectFIeldsTypes.Find(id);
            if (projectFIeldsType == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_FieldID = new SelectList(db.ProjectFields, "FieldID", "FieldValue", projectFIeldsType.FK_FieldID);
            return View(projectFIeldsType);
        }

        // POST: ProjectFIeldsTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FieldTypeID,FK_FieldID,FieldTypeValue")] ProjectFIeldsType projectFIeldsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectFIeldsType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_FieldID = new SelectList(db.ProjectFields, "FieldID", "FieldValue", projectFIeldsType.FK_FieldID);
            return View(projectFIeldsType);
        }

        // GET: ProjectFIeldsTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectFIeldsType projectFIeldsType = db.ProjectFIeldsTypes.Find(id);
            if (projectFIeldsType == null)
            {
                return HttpNotFound();
            }
            return View(projectFIeldsType);
        }

        // POST: ProjectFIeldsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectFIeldsType projectFIeldsType = db.ProjectFIeldsTypes.Find(id);
            db.ProjectFIeldsTypes.Remove(projectFIeldsType);
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
