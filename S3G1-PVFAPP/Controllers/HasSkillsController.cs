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
    public class HasSkillsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: HasSkills
        public ActionResult Index()
        {
            var hasSkills = db.HasSkills.Include(h => h.Employee).Include(h => h.Skill);
            return View(hasSkills.ToList());
        }

        // GET: HasSkills/Details/5
        public ActionResult Details(string id1,string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasSkills hasSkills = db.HasSkills.FirstOrDefault(u => (u.Employee.EmployeeName == id1) && (u.Skill.SkillDescription == id2));
            if (hasSkills == null)
            {
                return HttpNotFound();
            }
            return View(hasSkills);
        }

        // GET: HasSkills/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName");
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "SkillDescription");
            return View();
        }

        // POST: HasSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,SkillID,CreatedDate")] HasSkills hasSkills)
        {
            if (ModelState.IsValid)
            {
                db.HasSkills.Add(hasSkills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName", hasSkills.EmployeeID);
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "SkillDescription", hasSkills.SkillID);
            return View(hasSkills);
        }

        // GET: HasSkills/Edit/5
        public ActionResult Edit(string id1, string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasSkills hasSkills = db.HasSkills.FirstOrDefault(u => (u.Employee.EmployeeName == id1) && (u.Skill.SkillDescription == id2));
            if (hasSkills == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName", hasSkills.EmployeeID);
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "SkillDescription", hasSkills.SkillID);
            return View(hasSkills);
        }

        // POST: HasSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,SkillID,CreatedDate")] HasSkills hasSkills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hasSkills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName", hasSkills.EmployeeID);
            ViewBag.SkillID = new SelectList(db.Skill, "SkillID", "SkillDescription", hasSkills.SkillID);
            return View(hasSkills);
        }

        // GET: HasSkills/Delete/5
        public ActionResult Delete(string id1, string id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HasSkills hasSkills = db.HasSkills.FirstOrDefault(u => (u.Employee.EmployeeName == id1) && (u.Skill.SkillDescription == id2));
            if (hasSkills == null)
            {
                return HttpNotFound();
            }
            return View(hasSkills);
        }

        // POST: HasSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HasSkills hasSkills = db.HasSkills.Find(id);
            db.HasSkills.Remove(hasSkills);
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
