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
    public class DoesBusinessInsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: DoesBusinessIns
        public ActionResult Index()
        {
            var doesBusinessIn = db.DoesBusinessIn.Include(d => d.Customer).Include(d => d.Territory);
            return View(doesBusinessIn.ToList());
        }

        // GET: DoesBusinessIns/Details/5
        public ActionResult Details(string id1,string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIn.FirstOrDefault(u => (u.Customer.CustomerName == id1) && (u.Territory.TerritoryName == id2));
            if (doesBusinessIn == null)
            {
                return HttpNotFound();
            }
            return View(doesBusinessIn);
        }

        // GET: DoesBusinessIns/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName");
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName");
            return View();
        }

        // POST: DoesBusinessIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,TerritoryID,CreatedDate")] DoesBusinessIn doesBusinessIn)
        {
            if (ModelState.IsValid)
            {
                db.DoesBusinessIn.Add(doesBusinessIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", doesBusinessIn.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", doesBusinessIn.TerritoryID);
            return View(doesBusinessIn);
        }

        // GET: DoesBusinessIns/Edit/5
        public ActionResult Edit(string id1,string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIn.FirstOrDefault(u => (u.Customer.CustomerName == id1) && (u.Territory.TerritoryName == id2));
            if (doesBusinessIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", doesBusinessIn.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", doesBusinessIn.TerritoryID);
            return View(doesBusinessIn);
        }

        // POST: DoesBusinessIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,TerritoryID,CreatedDate")] DoesBusinessIn doesBusinessIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doesBusinessIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", doesBusinessIn.CustomerID);
            ViewBag.TerritoryID = new SelectList(db.Territory, "TerritoryID", "TerritoryName", doesBusinessIn.TerritoryID);
            return View(doesBusinessIn);
        }

        // GET: DoesBusinessIns/Delete/5
        public ActionResult Delete(string id1, string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIn.FirstOrDefault(u => (u.Customer.CustomerName == id1) && (u.Territory.TerritoryName == id2));
            if (doesBusinessIn == null)
            {
                return HttpNotFound();
            }
            return View(doesBusinessIn);
        }

        // POST: DoesBusinessIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoesBusinessIn doesBusinessIn = db.DoesBusinessIn.Find(id);
            db.DoesBusinessIn.Remove(doesBusinessIn);
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
