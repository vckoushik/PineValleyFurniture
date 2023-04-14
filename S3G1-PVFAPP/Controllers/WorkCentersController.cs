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
    public class WorkCentersController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: WorkCenters
        public ActionResult Index()
        {
            return View(db.WorkCenter.ToList());
        }

        // GET: WorkCenters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCenter workCenter = db.WorkCenter.Find(id);
            if (workCenter == null)
            {
                return HttpNotFound();
            }
            return View(workCenter);
        }

        // GET: WorkCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkCenterID,WorkCenterLocation")] WorkCenter workCenter)
        {
            if (ModelState.IsValid)
            {
                db.WorkCenter.Add(workCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workCenter);
        }

        // GET: WorkCenters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCenter workCenter = db.WorkCenter.Find(id);
            if (workCenter == null)
            {
                return HttpNotFound();
            }
            return View(workCenter);
        }

        // POST: WorkCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkCenterID,WorkCenterLocation")] WorkCenter workCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workCenter);
        }

        // GET: WorkCenters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCenter workCenter = db.WorkCenter.Find(id);
            if (workCenter == null)
            {
                return HttpNotFound();
            }
            return View(workCenter);
        }

        // POST: WorkCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WorkCenter workCenter = db.WorkCenter.Find(id);
            db.ProducedIn.RemoveRange(workCenter.ProducedIn);
            db.SaveChanges();
            db.WorkCenter.Remove(workCenter);
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
