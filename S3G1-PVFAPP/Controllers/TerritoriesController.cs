using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S3G1_PVFAPP.Models;

namespace S3G1_PVFAPP.Controllers
{
    public class TerritoriesController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Territories
        public ActionResult Index(int? sort)
        {
            if (sort == 1)
            {
                return View(db.Territory.ToList().OrderBy(Territory=>Territory.TerritoryID));
            }
            return View(db.Territory.ToList());
        }

        // GET: Territories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territory territory = db.Territory.Find(id);
            if (territory == null)
            {
                return HttpNotFound();
            }
            return View(territory);
        }

        // GET: Territories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Territories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerritoryID,TerritoryName")] Territory territory)
        {
            if (ModelState.IsValid)
            {
                db.Territory.Add(territory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(territory);
        }

        // GET: Territories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territory territory = db.Territory.Find(id);
            if (territory == null)
            {
                return HttpNotFound();
            }
            return View(territory);
        }

        // POST: Territories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerritoryID,TerritoryName")] Territory territory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(territory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(territory);
        }

        // GET: Territories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territory territory = db.Territory.Find(id);
            if (territory == null)
            {
                return HttpNotFound();
            }
            return View(territory);
        }

        // POST: Territories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Territory territory = db.Territory.Find(id);
            db.DoesBusinessIn.RemoveRange(territory.DoesBusinessIn);
            db.SaveChanges();
            db.Salesperson.RemoveRange(territory.Salesperson);
            db.SaveChanges();
            db.Territory.Remove(territory);
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
