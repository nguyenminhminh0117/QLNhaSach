using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBanSach.Models;

namespace QLBanSach.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        private QLBS db = new QLBS();

        // GET: CT_HOADON
        public ActionResult Index()
        {
            var cT_HOADON = db.CT_HOADON.Include(c => c.HOADON).Include(c => c.SACH);
            return View(cT_HOADON.ToList());
        }

        // GET: CT_HOADON/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOADON cT_HOADON = db.CT_HOADON.Find(id);
            if (cT_HOADON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOADON);
        }

        // GET: CT_HOADON/Create
        public ActionResult Create()
        {
            ViewBag.mahoadon = new SelectList(db.HOADONs, "mahoadon", "manv");
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach");
            return View();
        }

        // POST: CT_HOADON/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahoadon,masach,soluongban,dongia,thanhtien,delflag,timedel")] CT_HOADON cT_HOADON)
        {
            if (ModelState.IsValid)
            {
                db.CT_HOADON.Add(cT_HOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mahoadon = new SelectList(db.HOADONs, "mahoadon", "manv", cT_HOADON.mahoadon);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_HOADON.masach);
            return View(cT_HOADON);
        }

        // GET: CT_HOADON/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOADON cT_HOADON = db.CT_HOADON.Find(id);
            if (cT_HOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.mahoadon = new SelectList(db.HOADONs, "mahoadon", "manv", cT_HOADON.mahoadon);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_HOADON.masach);
            return View(cT_HOADON);
        }

        // POST: CT_HOADON/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahoadon,masach,soluongban,dongia,thanhtien,delflag,timedel")] CT_HOADON cT_HOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mahoadon = new SelectList(db.HOADONs, "mahoadon", "manv", cT_HOADON.mahoadon);
            ViewBag.masach = new SelectList(db.SACHes, "masach", "tensach", cT_HOADON.masach);
            return View(cT_HOADON);
        }

        // GET: CT_HOADON/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOADON cT_HOADON = db.CT_HOADON.Find(id);
            if (cT_HOADON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOADON);
        }

        // POST: CT_HOADON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CT_HOADON cT_HOADON = db.CT_HOADON.Find(id);
            db.CT_HOADON.Remove(cT_HOADON);
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
