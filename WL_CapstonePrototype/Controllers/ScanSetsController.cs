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
    public class ScanSetsController : Controller
    {
        private CapstonePrototypeDBEntities db = new CapstonePrototypeDBEntities();

        // GET: ScanSets
        public ActionResult Index()
        {
            var scanSet = db.ScanSet.Include(s => s.AddressSet).Include(s => s.GarbageSet).Include(s => s.Users);
            return View(scanSet.ToList());
        }

        // GET: ScanSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScanSet scanSet = db.ScanSet.Find(id);
            if (scanSet == null)
            {
                return HttpNotFound();
            }
            return View(scanSet);
        }

        // GET: ScanSets/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.AddressSet, "Id", "Country");
            ViewBag.GarbageId = new SelectList(db.GarbageSet, "Id", "GarbageName");
            ViewBag.UsersId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: ScanSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ScanTime,GarbageId,AddressId,UsersId")] ScanSet scanSet)
        {
            if (ModelState.IsValid)
            {
                db.ScanSet.Add(scanSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.AddressSet, "Id", "Country", scanSet.AddressId);
            ViewBag.GarbageId = new SelectList(db.GarbageSet, "Id", "GarbageName", scanSet.GarbageId);
            ViewBag.UsersId = new SelectList(db.Users, "Id", "FirstName", scanSet.UsersId);
            return View(scanSet);
        }

        // GET: ScanSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScanSet scanSet = db.ScanSet.Find(id);
            if (scanSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.AddressSet, "Id", "Country", scanSet.AddressId);
            ViewBag.GarbageId = new SelectList(db.GarbageSet, "Id", "GarbageName", scanSet.GarbageId);
            ViewBag.UsersId = new SelectList(db.Users, "Id", "FirstName", scanSet.UsersId);
            return View(scanSet);
        }

        // POST: ScanSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ScanTime,GarbageId,AddressId,UsersId")] ScanSet scanSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scanSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.AddressSet, "Id", "Country", scanSet.AddressId);
            ViewBag.GarbageId = new SelectList(db.GarbageSet, "Id", "GarbageName", scanSet.GarbageId);
            ViewBag.UsersId = new SelectList(db.Users, "Id", "FirstName", scanSet.UsersId);
            return View(scanSet);
        }

        // GET: ScanSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScanSet scanSet = db.ScanSet.Find(id);
            if (scanSet == null)
            {
                return HttpNotFound();
            }
            return View(scanSet);
        }

        // POST: ScanSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScanSet scanSet = db.ScanSet.Find(id);
            db.ScanSet.Remove(scanSet);
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
