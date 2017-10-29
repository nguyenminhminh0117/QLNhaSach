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
    public class CT_PHIEUNHAPController : Controller
    {
        private DBQLBS db = new DBQLBS();

        // GET: CT_PHIEUNHAP
        public ActionResult Index()
        {
            var cT_PHIEUNHAP = db.CT_PHIEUNHAP.Include(c => c.PHIEUNHAP).Include(c => c.SACH);
            return View(cT_PHIEUNHAP.ToList());
        }

        // GET: CT_PHIEUNHAP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUNHAP cT_PHIEUNHAP = db.CT_PHIEUNHAP.Find(id);
            if (cT_PHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEUNHAP);
        }

        // GET: CT_PHIEUNHAP/Create
        public ActionResult Create()
        {
            ViewBag.mapn = new SelectList(db.PHIEUNHAPs, "mapn", "manv");
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach");
            return View();
        }

        // POST: CT_PHIEUNHAP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masach,mapn,soluong,gianhap,thanhtien")] CT_PHIEUNHAP cT_PHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                db.CT_PHIEUNHAP.Add(cT_PHIEUNHAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mapn = new SelectList(db.PHIEUNHAPs, "mapn", "manv", cT_PHIEUNHAP.mapn);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_PHIEUNHAP.masach);
            return View(cT_PHIEUNHAP);
        }

        // GET: CT_PHIEUNHAP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUNHAP cT_PHIEUNHAP = db.CT_PHIEUNHAP.Find(id);
            if (cT_PHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.mapn = new SelectList(db.PHIEUNHAPs, "mapn", "manv", cT_PHIEUNHAP.mapn);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_PHIEUNHAP.masach);
            return View(cT_PHIEUNHAP);
        }

        // POST: CT_PHIEUNHAP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masach,mapn,soluong,gianhap,thanhtien")] CT_PHIEUNHAP cT_PHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_PHIEUNHAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mapn = new SelectList(db.PHIEUNHAPs, "mapn", "manv", cT_PHIEUNHAP.mapn);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_PHIEUNHAP.masach);
            return View(cT_PHIEUNHAP);
        }

        // GET: CT_PHIEUNHAP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_PHIEUNHAP cT_PHIEUNHAP = db.CT_PHIEUNHAP.Find(id);
            if (cT_PHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(cT_PHIEUNHAP);
        }

        // POST: CT_PHIEUNHAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CT_PHIEUNHAP cT_PHIEUNHAP = db.CT_PHIEUNHAP.Find(id);
            db.CT_PHIEUNHAP.Remove(cT_PHIEUNHAP);
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
