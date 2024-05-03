using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class registrationsController : Controller
    {
        private dbUnversityEntities db = new dbUnversityEntities();

        // GET: registrations
        public ActionResult Index()
        {
            var registrations = db.registrations.Include(r => r.admin_).Include(r => r.course).Include(r => r.student);
            return View(registrations.ToList());
        }

        // GET: registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: registrations/Create
        public ActionResult Create()
        {
            ViewBag.admin_id = new SelectList(db.admin_, "ID", "Name");
            ViewBag.Course_id = new SelectList(db.courses, "Course_ID", "Course_Name");
            ViewBag.student_id = new SelectList(db.students, "id", "name");
            return View();
        }

        // POST: registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Course_id,student_id,admin_id,registration_date")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.admin_id = new SelectList(db.admin_, "ID", "Name", registration.admin_id);
            ViewBag.Course_id = new SelectList(db.courses, "Course_ID", "Course_Name", registration.Course_id);
            ViewBag.student_id = new SelectList(db.students, "id", "name", registration.student_id);
            return View(registration);
        }

        // GET: registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_id = new SelectList(db.admin_, "ID", "Name", registration.admin_id);
            ViewBag.Course_id = new SelectList(db.courses, "Course_ID", "Course_Name", registration.Course_id);
            ViewBag.student_id = new SelectList(db.students, "id", "name", registration.student_id);
            return View(registration);
        }

        // POST: registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Course_id,student_id,admin_id,registration_date")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_id = new SelectList(db.admin_, "ID", "Name", registration.admin_id);
            ViewBag.Course_id = new SelectList(db.courses, "Course_ID", "Course_Name", registration.Course_id);
            ViewBag.student_id = new SelectList(db.students, "id", "name", registration.student_id);
            return View(registration);
        }

        // GET: registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registration registration = db.registrations.Find(id);
            db.registrations.Remove(registration);
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
