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
    public class SalespersonsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Salespersons
        public ActionResult Index()
        {
            var salesperson = db.Salesperson.Include(s => s.Territory);
            return View(salesperson.ToList());
        }

        // GET: Salespersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salesperson.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // GET: Salespersons/Create
        public ActionResult Create()
        {
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName");
            return View();
        }

        // POST: Salespersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalespersonID,SalespersonName,SalespersonPhone,SalespersonFax,TerritoryID")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Salesperson.Add(salesperson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", salesperson.TerritoryID);
            return View(salesperson);
        }

        // GET: Salespersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salesperson.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", salesperson.TerritoryID);
            return View(salesperson);
        }

        // POST: Salespersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalespersonID,SalespersonName,SalespersonPhone,SalespersonFax,TerritoryID")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesperson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", salesperson.TerritoryID);
            return View(salesperson);
        }

        // GET: Salespersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesperson salesperson = db.Salesperson.Find(id);
            if (salesperson == null)
            {
                return HttpNotFound();
            }
            return View(salesperson);
        }

        // POST: Salespersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salesperson salesperson = db.Salesperson.Find(id);
            db.Salesperson.Remove(salesperson);
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
