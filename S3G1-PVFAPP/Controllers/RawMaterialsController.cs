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
    public class RawMaterialsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: RawMaterials
        public ActionResult Index()
        {
            return View(db.RawMaterial.ToList());
        }

        // GET: RawMaterials/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawMaterial rawMaterial = db.RawMaterial.Find(id);
            if (rawMaterial == null)
            {
                return HttpNotFound();
            }
            return View(rawMaterial);
        }

        // GET: RawMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RawMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialID,MaterialName,MaterialStandardCost,UnitOfMeasure")] RawMaterial rawMaterial)
        {
            if (ModelState.IsValid)
            {
                db.RawMaterial.Add(rawMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rawMaterial);
        }

        // GET: RawMaterials/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawMaterial rawMaterial = db.RawMaterial.Find(id);
            if (rawMaterial == null)
            {
                return HttpNotFound();
            }
            return View(rawMaterial);
        }

        // POST: RawMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialID,MaterialName,MaterialStandardCost,UnitOfMeasure")] RawMaterial rawMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rawMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rawMaterial);
        }

        // GET: RawMaterials/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawMaterial rawMaterial = db.RawMaterial.Find(id);
            if (rawMaterial == null)
            {
                return HttpNotFound();
            }
            return View(rawMaterial);
        }

        // POST: RawMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RawMaterial rawMaterial = db.RawMaterial.Find(id);
            db.Supplies.RemoveRange(rawMaterial.Supplies);
            db.SaveChanges();
            db.Uses.RemoveRange(rawMaterial.Uses);
            db.SaveChanges();
            db.RawMaterial.Remove(rawMaterial);
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
