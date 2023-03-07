using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.Models;
using TaskMasterWeb.ViewModels.Clients;

namespace TaskMasterWeb.Controllers
{
    public class ClientsController : Controller
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new ClientDetailsViewModel(id);

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            var viewModel = new ClientCreateViewModel();

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = new ClientCreateViewModel();
                return View(viewModel);
            }

            var client = viewModel.CopyToModel(viewModel);


            // Save to DB
            db.Clients.Add(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,CompanyName,EmailAddress,ContactNumber")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
