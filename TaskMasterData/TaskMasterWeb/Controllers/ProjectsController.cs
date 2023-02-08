using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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
            ViewBag.FK_ClientID = new SelectList(db.Clients, "ClientID", "CompanyName");
            ViewBag.FK_StatusID = new SelectList(db.ProjectStatus, "StatusID", "StatusValue");
            ViewBag.FK_StaffID = new SelectList(db.Staffs, "StaffID", "FirstName");

            //Don't think I need this?
            var viewModel = new ProjectCreateViewModel
            {
                Clients = db.Clients.ToList(),
                Staff = db.Staffs.ToList(),
                Statuses = db.ProjectStatus.ToList()
            };


            return View(viewModel);
        }

        //// GET: Projects/Create
        //public ActionResult Create()
        //{
        //    ViewBag.FK_ClientID = new SelectList(db.Clients, "ClientID", "CompanyName");
        //    ViewBag.FK_StatusID = new SelectList(db.ProjectStatus, "StatusID", "StatusValue");
        //    return View();
        //}

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,FK_ClientID,FK_StatusID,ProjectName,CreationDate,FK_StaffID")] ProjectCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clients = new SelectList(db.Clients, "ClientID", "CompanyName");
                ViewBag.Status = new SelectList(db.ProjectStatus, "StatusID", "StatusValue");
                ViewBag.Staff = new SelectList(db.Staffs, "StaffID", "FirstName");

                viewModel.Clients = db.Clients.ToList();
                viewModel.Staff = db.Staffs.ToList();
                viewModel.Statuses = db.ProjectStatus.ToList();
                return View(viewModel);
            }

            var project = new Project
            {
                FK_ClientID = viewModel.FK_ClientID,
                FK_StatusID = viewModel.FK_StatusID,
                ProjectName = viewModel.ProjectName,
                CreationDate = null

                //FK_ClientID = viewModel.SelectedClientId,
                //FK_StatusID = viewModel.SelectedStatusId,
                //ProjectName = viewModel.ProjectName,
                //CreationDate = null
            };

            // Save Project
            db.Projects.Add(project);
            db.SaveChanges();

            var projectAssignedTo = new AssignedProject
            {
                FK_StaffID = viewModel.FK_StaffID,
                FK_ProjectID = project.ProjectID
            };

            //var assignedProjects = viewModel.SelectedStaffIds.Select(staffId => new AssignedProject
            //{
            //    FK_ProjectID = project.ProjectID,
            //    FK_StaffID = staffId
            //});

            // Save Projects Assigned to staff
            db.AssignedProjects.Add(projectAssignedTo);
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
