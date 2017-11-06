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
    public class ChiTietPhieuNhapController : Controller
    {
        private QLBS db = new QLBS();

        // GET: ChiTietPhieuNhap
        public ActionResult Index()
        {
            return View(db.CT_PHIEUNHAP.ToList());
        }

        // GET: ChiTietPhieuNhap/Details/5
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

        // GET: ChiTietPhieuNhap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietPhieuNhap/Create
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

            return View(cT_PHIEUNHAP);
        }

        // GET: ChiTietPhieuNhap/Edit/5
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
            return View(cT_PHIEUNHAP);
        }

        // POST: ChiTietPhieuNhap/Edit/5
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
            return View(cT_PHIEUNHAP);
        }

        // GET: ChiTietPhieuNhap/Delete/5
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

        // POST: ChiTietPhieuNhap/Delete/5
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
