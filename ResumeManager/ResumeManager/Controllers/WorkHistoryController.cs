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
    public class WorkHistoryController : Controller
    {
        private dbResumeManagerEntities1 db = new dbResumeManagerEntities1();

        // GET: WorkHistroy
        public ActionResult Index()
        {
            var tbl_work_history = db.tbl_work_history.Include(t => t.tbl_users);
            return View(tbl_work_history.ToList());
        }

        // GET: WorkHistroy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_work_history tbl_work_history = db.tbl_work_history.Find(id);
            if (tbl_work_history == null)
            {
                return HttpNotFound();
            }
            return View(tbl_work_history);
        }

        // GET: WorkHistroy/Create
        public ActionResult Create()
        {
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname");
            return View();
        }

        // POST: WorkHistroy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,company_name,position,start_date,leave_date,description,isWorkingCurrently,fk_user_id")] tbl_work_history tbl_work_history)
        {
            if (ModelState.IsValid)
            {
                db.tbl_work_history.Add(tbl_work_history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_work_history.fk_user_id);
            return View(tbl_work_history);
        }

        // GET: WorkHistroy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_work_history tbl_work_history = db.tbl_work_history.Find(id);
            if (tbl_work_history == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_work_history.fk_user_id);
            return View(tbl_work_history);
        }

        // POST: WorkHistroy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,company_name,position,start_date,leave_date,description,isWorkingCurrently,fk_user_id")] tbl_work_history tbl_work_history)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_work_history).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_work_history.fk_user_id);
            return View(tbl_work_history);
        }

        // GET: WorkHistroy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_work_history tbl_work_history = db.tbl_work_history.Find(id);
            if (tbl_work_history == null)
            {
                return HttpNotFound();
            }
            return View(tbl_work_history);
        }

        // POST: WorkHistroy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_work_history tbl_work_history = db.tbl_work_history.Find(id);
            db.tbl_work_history.Remove(tbl_work_history);
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
