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
    public class ChiTietDatHangController : Controller
    {
        private QLBS db = new QLBS();

        // GET: ChiTietDatHang
        public ActionResult Index()
        {
            return View(db.CT_DATHANG.ToList());
        }

        // GET: ChiTietDatHang/Details/5
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

        // GET: ChiTietDatHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietDatHang/Create
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

            return View(cT_DATHANG);
        }

        // GET: ChiTietDatHang/Edit/5
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
            return View(cT_DATHANG);
        }

        // POST: ChiTietDatHang/Edit/5
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
            return View(cT_DATHANG);
        }

        // GET: ChiTietDatHang/Delete/5
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

        // POST: ChiTietDatHang/Delete/5
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
