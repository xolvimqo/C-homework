using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResumeManager.Models;

namespace ResumeManager.Controllers
{
    public class EducationController : Controller
    {
        private dbResumeManagerEntities1 db = new dbResumeManagerEntities1();

        // GET: Education
        public ActionResult Index()
        {
            var tbl_education = db.tbl_education.Include(t => t.tbl_users);
            return View(tbl_education.ToList());
        }

        // GET: Education/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_education tbl_education = db.tbl_education.Find(id);
            if (tbl_education == null)
            {
                return HttpNotFound();
            }
            return View(tbl_education);
        }

        // GET: Education/Create
        public ActionResult Create()
        {
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname");
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,school_name,degree,start_date,finish_date,program_name,description,isEnrolledCurrently,fk_user_id")] tbl_education tbl_education)
        {
            if (ModelState.IsValid)
            {
                db.tbl_education.Add(tbl_education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_education.fk_user_id);
            return View(tbl_education);
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_education tbl_education = db.tbl_education.Find(id);
            if (tbl_education == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_education.fk_user_id);
            return View(tbl_education);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,school_name,degree,start_date,finish_date,program_name,description,isEnrolledCurrently,fk_user_id")] tbl_education tbl_education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_education.fk_user_id);
            return View(tbl_education);
        }

        // GET: Education/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_education tbl_education = db.tbl_education.Find(id);
            if (tbl_education == null)
            {
                return HttpNotFound();
            }
            return View(tbl_education);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_education tbl_education = db.tbl_education.Find(id);
            db.tbl_education.Remove(tbl_education);
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
