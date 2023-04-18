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
    public class SuppliesController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Supplies
        public ActionResult Index()
        {
            var supplies = db.Supplies.Include(s => s.RawMaterial).Include(s => s.Vendor);
            return View(supplies.ToList());
        }

        // GET: Supplies/Details/5
        public ActionResult Details(string id1, string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplies supplies = db.Supplies.FirstOrDefault(u => (u.RawMaterial.MaterialName == id1) && (u.Vendor.VendorName == id2));
            if (supplies == null)
            {
                return HttpNotFound();
            }
            return View(supplies);
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            ViewBag.MaterialID = new SelectList(db.RawMaterial, "MaterialID", "MaterialName");
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName");
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,MaterialID,SuppliesUnitPrice")] Supplies supplies)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supplies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialID = new SelectList(db.RawMaterial, "MaterialID", "MaterialName", supplies.MaterialID);
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName", supplies.VendorID);
            return View(supplies);
        }

        // GET: Supplies/Edit/5
        public ActionResult Edit(string id1, string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplies supplies = db.Supplies.FirstOrDefault(u => (u.RawMaterial.MaterialName == id1) && (u.Vendor.VendorName == id2));
            if (supplies == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialID = new SelectList(db.RawMaterial, "MaterialID", "MaterialName", supplies.MaterialID);
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName", supplies.VendorID);
            return View(supplies);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,MaterialID,SuppliesUnitPrice")] Supplies supplies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialID = new SelectList(db.RawMaterial, "MaterialID", "MaterialName", supplies.MaterialID);
            ViewBag.VendorID = new SelectList(db.Vendor, "VendorID", "VendorName", supplies.VendorID);
            return View(supplies);
        }

        // GET: Supplies/Delete/5
        public ActionResult Delete(string id1, string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplies supplies = db.Supplies.FirstOrDefault(u => (u.RawMaterial.MaterialName == id1) && (u.Vendor.VendorName == id2));
            if (supplies == null)
            {
                return HttpNotFound();
            }
            return View(supplies);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplies supplies = db.Supplies.Find(id);
            db.Supplies.Remove(supplies);
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
