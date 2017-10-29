using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach.Models;
using PagedList;
using PagedList.Mvc;

namespace QuanLyBanSach.Controllers
{
    public class BAOCAOTONGsController : Controller
    {
        private DBQLBS db = new DBQLBS();

        // GET: BAOCAOTONGs
        public ActionResult Index(int? page)
        {
            return View(db.BAOCAOTONGs.ToList().ToPagedList((page ?? 1), 100));
        }

        // GET: BAOCAOTONGs/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOTONG bAOCAOTONG = db.BAOCAOTONGs.Find(id);
            if (bAOCAOTONG == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOTONG);
        }

        // GET: BAOCAOTONGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BAOCAOTONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ngay,tongthu,tongchi,chenhlech,delflag,timedel")] BAOCAOTONG bAOCAOTONG)
        {
            if (ModelState.IsValid)
            {
                db.BAOCAOTONGs.Add(bAOCAOTONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bAOCAOTONG);
        }

        // GET: BAOCAOTONGs/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOTONG bAOCAOTONG = db.BAOCAOTONGs.Find(id);
            if (bAOCAOTONG == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOTONG);
        }

        // POST: BAOCAOTONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ngay,tongthu,tongchi,chenhlech,delflag,timedel")] BAOCAOTONG bAOCAOTONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAOCAOTONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bAOCAOTONG);
        }

        // GET: BAOCAOTONGs/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAOCAOTONG bAOCAOTONG = db.BAOCAOTONGs.Find(id);
            if (bAOCAOTONG == null)
            {
                return HttpNotFound();
            }
            return View(bAOCAOTONG);
        }

        // POST: BAOCAOTONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            BAOCAOTONG bAOCAOTONG = db.BAOCAOTONGs.Find(id);
            db.BAOCAOTONGs.Remove(bAOCAOTONG);
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
