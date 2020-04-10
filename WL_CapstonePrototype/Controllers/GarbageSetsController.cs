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
    public class GarbageSetsController : Controller
    {
        private CapstonePrototypeDBEntities db = new CapstonePrototypeDBEntities();

        // GET: GarbageSets
        public ActionResult Index()
        {
            return View(db.GarbageSet.ToList());
        }

        // GET: GarbageSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarbageSet garbageSet = db.GarbageSet.Find(id);
            if (garbageSet == null)
            {
                return HttpNotFound();
            }
            return View(garbageSet);
        }

        // GET: GarbageSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GarbageSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GarbageName,GarbageDetails")] GarbageSet garbageSet)
        {
            if (ModelState.IsValid)
            {
                db.GarbageSet.Add(garbageSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garbageSet);
        }

        // GET: GarbageSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarbageSet garbageSet = db.GarbageSet.Find(id);
            if (garbageSet == null)
            {
                return HttpNotFound();
            }
            return View(garbageSet);
        }

        // POST: GarbageSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GarbageName,GarbageDetails")] GarbageSet garbageSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garbageSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garbageSet);
        }

        // GET: GarbageSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GarbageSet garbageSet = db.GarbageSet.Find(id);
            if (garbageSet == null)
            {
                return HttpNotFound();
            }
            return View(garbageSet);
        }

        // POST: GarbageSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GarbageSet garbageSet = db.GarbageSet.Find(id);
            db.GarbageSet.Remove(garbageSet);
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
