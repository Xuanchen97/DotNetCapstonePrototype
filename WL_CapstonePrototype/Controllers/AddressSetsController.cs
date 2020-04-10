using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WL_CapstonePrototype.Models;

namespace WL_CapstonePrototype.Controllers
{
    public class AddressSetsController : Controller
    {
        private CapstonePrototypeDBEntities db = new CapstonePrototypeDBEntities();

        // GET: AddressSets
        public ActionResult Index()
        {
            return View(db.AddressSet.ToList());
        }

        // GET: AddressSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressSet addressSet = db.AddressSet.Find(id);
            if (addressSet == null)
            {
                return HttpNotFound();
            }
            return View(addressSet);
        }

        // GET: AddressSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Country,Region,City")] AddressSet addressSet)
        {
            if (ModelState.IsValid)
            {
                db.AddressSet.Add(addressSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addressSet);
        }

        // GET: AddressSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressSet addressSet = db.AddressSet.Find(id);
            if (addressSet == null)
            {
                return HttpNotFound();
            }
            return View(addressSet);
        }

        // POST: AddressSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Country,Region,City")] AddressSet addressSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addressSet);
        }

        // GET: AddressSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressSet addressSet = db.AddressSet.Find(id);
            if (addressSet == null)
            {
                return HttpNotFound();
            }
            return View(addressSet);
        }

        // POST: AddressSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressSet addressSet = db.AddressSet.Find(id);
            db.AddressSet.Remove(addressSet);
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
