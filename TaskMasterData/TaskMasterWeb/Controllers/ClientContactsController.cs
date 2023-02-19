using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.ViewModels.ClientContacts;

namespace TaskMasterWeb.Models
{
    public class ClientContactsController : Controller
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        // GET: ClientContacts
        public ActionResult Index()
        {
            var clientContacts = db.ClientContacts.Include(c => c.Client);
            return View(clientContacts.ToList());
        }

        // GET: ClientContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContact clientContact = db.ClientContacts.Find(id);
            if (clientContact == null)
            {
                return HttpNotFound();
            }
            return View(clientContact);
        }

        // GET: ClientContacts/Create
        public ActionResult Create()
        {
            var viewModel = new ClientContactCreateViewModel();

            return View(viewModel);
        }

        // GET: ClientContacts/Create
        public ActionResult Create(int fk_ClientID)
        {
            var viewModel = new ClientContactCreateViewModel(fk_ClientID);

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientContactCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = new ClientContactCreateViewModel(viewModel.FK_ClientID);

                return View(viewModel);
            }

            var clientContact = viewModel.CopyToModel(viewModel);

            // Save to DB
            db.ClientContacts.Add(clientContact);
            db.SaveChanges();

            return RedirectToAction("Details", "Clients", new { id = viewModel.FK_ClientID });
        }

        // GET: ClientContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContact clientContact = db.ClientContacts.Find(id);
            if (clientContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", clientContact.FK_ClientID);
            return View(clientContact);
        }

        // POST: ClientContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,FK_ClientID,FirstName,LastName,EmailAddress,ContactNumber")] ClientContact clientContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", clientContact.FK_ClientID);
            return View(clientContact);
        }

        // GET: ClientContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientContact clientContact = db.ClientContacts.Find(id);
            if (clientContact == null)
            {
                return HttpNotFound();
            }
            return View(clientContact);
        }

        // POST: ClientContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientContact clientContact = db.ClientContacts.Find(id);
            db.ClientContacts.Remove(clientContact);
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
