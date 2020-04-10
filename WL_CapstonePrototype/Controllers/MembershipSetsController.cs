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
    public class MembershipSetsController : Controller
    {
        private CapstonePrototypeDBEntities db = new CapstonePrototypeDBEntities();

        // GET: MembershipSets
        public ActionResult Index()
        {
            return View(db.MembershipSet.ToList());
        }

        // GET: MembershipSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipSet membershipSet = db.MembershipSet.Find(id);
            if (membershipSet == null)
            {
                return HttpNotFound();
            }
            return View(membershipSet);
        }

        // GET: MembershipSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MembershipType,MembershipFee")] MembershipSet membershipSet)
        {
            if (ModelState.IsValid)
            {
                db.MembershipSet.Add(membershipSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipSet);
        }

        // GET: MembershipSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipSet membershipSet = db.MembershipSet.Find(id);
            if (membershipSet == null)
            {
                return HttpNotFound();
            }
            return View(membershipSet);
        }

        // POST: MembershipSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MembershipType,MembershipFee")] MembershipSet membershipSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipSet);
        }

        // GET: MembershipSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipSet membershipSet = db.MembershipSet.Find(id);
            if (membershipSet == null)
            {
                return HttpNotFound();
            }
            return View(membershipSet);
        }

        // POST: MembershipSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembershipSet membershipSet = db.MembershipSet.Find(id);
            db.MembershipSet.Remove(membershipSet);
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

        public static implicit operator MembershipSetsController(UsersController v)
        {
            throw new NotImplementedException();
        }
    }
}
