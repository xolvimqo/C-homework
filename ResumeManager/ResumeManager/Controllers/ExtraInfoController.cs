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
    public class ExtraInfoController : Controller
    {
        private dbResumeManagerEntities1 db = new dbResumeManagerEntities1();

        // GET: ExtraInfo
        public ActionResult Index()
        {
            var tbl_extra_info = db.tbl_extra_info.Include(t => t.tbl_users);
            return View(tbl_extra_info.ToList());
        }

        // GET: ExtraInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_extra_info tbl_extra_info = db.tbl_extra_info.Find(id);
            if (tbl_extra_info == null)
            {
                return HttpNotFound();
            }
            return View(tbl_extra_info);
        }

        // GET: ExtraInfo/Create
        public ActionResult Create()
        {
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname");
            return View();
        }

        // POST: ExtraInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,info_title,description,fk_user_id")] tbl_extra_info tbl_extra_info)
        {
            if (ModelState.IsValid)
            {
                db.tbl_extra_info.Add(tbl_extra_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_extra_info.fk_user_id);
            return View(tbl_extra_info);
        }

        // GET: ExtraInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_extra_info tbl_extra_info = db.tbl_extra_info.Find(id);
            if (tbl_extra_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_extra_info.fk_user_id);
            return View(tbl_extra_info);
        }

        // POST: ExtraInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,info_title,description,fk_user_id")] tbl_extra_info tbl_extra_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_extra_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_user_id = new SelectList(db.tbl_users, "Id", "firstname", tbl_extra_info.fk_user_id);
            return View(tbl_extra_info);
        }

        // GET: ExtraInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_extra_info tbl_extra_info = db.tbl_extra_info.Find(id);
            if (tbl_extra_info == null)
            {
                return HttpNotFound();
            }
            return View(tbl_extra_info);
        }

        // POST: ExtraInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_extra_info tbl_extra_info = db.tbl_extra_info.Find(id);
            db.tbl_extra_info.Remove(tbl_extra_info);
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
