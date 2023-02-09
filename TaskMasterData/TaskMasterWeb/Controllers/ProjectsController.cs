﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskMasterWeb.Models;
using TaskMasterWeb.ViewModels;

namespace TaskMasterWeb.Controllers
{
    public class ProjectsController : Controller
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Client).Include(p => p.ProjectStatus);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new ProjectCreateViewModel();

            return View(viewModel);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = new ProjectCreateViewModel();

                return View(viewModel);
            }


            // Copy viewModel data to Project model.
            var project = new Project
            {
                ProjectName = viewModel.ProjectName,
                FK_ClientID = viewModel.SelectedClientId,
                FK_StatusID = viewModel.SelectedStatusId,
                CreationDate = null
            };

            // Save project
            db.Projects.Add(project);
            db.SaveChanges();


            var assignedProjects = viewModel.SelectedStaffIds.Select(id => new AssignedProject
            {
                FK_StaffID = id,
                FK_ProjectID = project.ProjectID
            });


            // Save assigned project
            db.AssignedProjects.AddRange(assignedProjects);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", project.FK_ClientID);
            ViewBag.FK_StatusID = new SelectList(db.ProjectStatus, "StatusID", "StatusValue", project.FK_StatusID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,FK_ClientID,FK_StatusID,ProjectName,CreationDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", project.FK_ClientID);
            ViewBag.FK_StatusID = new SelectList(db.ProjectStatus, "StatusID", "StatusValue", project.FK_StatusID);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
