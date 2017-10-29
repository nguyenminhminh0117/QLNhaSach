using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach.Models;

namespace QuanLyBanSach.Controllers
{
    public class CT_DATHANGController : Controller
    {
        private DBQLBS db = new DBQLBS();

        // GET: CT_DATHANG
        public ActionResult Index()
        {
            var cT_DATHANG = db.CT_DATHANG.Include(c => c.DATHANG).Include(c => c.SACH);
            return View(cT_DATHANG.ToList());
        }

        // GET: CT_DATHANG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DATHANG cT_DATHANG = db.CT_DATHANG.Find(id);
            if (cT_DATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_DATHANG);
        }

        // GET: CT_DATHANG/Create
        public ActionResult Create()
        {
            ViewBag.madathang = new SelectList(db.DATHANGs, "madathang", "makh");
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach");
            return View();
        }

        // POST: CT_DATHANG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madathang,masach,soluongdat,dongia,thanhtien,delflag,timedel")] CT_DATHANG cT_DATHANG)
        {
            if (ModelState.IsValid)
            {
                db.CT_DATHANG.Add(cT_DATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.madathang = new SelectList(db.DATHANGs, "madathang", "makh", cT_DATHANG.madathang);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_DATHANG.masach);
            return View(cT_DATHANG);
        }

        // GET: CT_DATHANG/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DATHANG cT_DATHANG = db.CT_DATHANG.Find(id);
            if (cT_DATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.madathang = new SelectList(db.DATHANGs, "madathang", "makh", cT_DATHANG.madathang);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_DATHANG.masach);
            return View(cT_DATHANG);
        }

        // POST: CT_DATHANG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "madathang,masach,soluongdat,dongia,thanhtien,delflag,timedel")] CT_DATHANG cT_DATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_DATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.madathang = new SelectList(db.DATHANGs, "madathang", "makh", cT_DATHANG.madathang);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_DATHANG.masach);
            return View(cT_DATHANG);
        }

        // GET: CT_DATHANG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DATHANG cT_DATHANG = db.CT_DATHANG.Find(id);
            if (cT_DATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_DATHANG);
        }

        // POST: CT_DATHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CT_DATHANG cT_DATHANG = db.CT_DATHANG.Find(id);
            db.CT_DATHANG.Remove(cT_DATHANG);
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
