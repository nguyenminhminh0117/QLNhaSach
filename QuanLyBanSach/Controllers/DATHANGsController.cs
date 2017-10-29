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
    public class DATHANGsController : Controller
    {
        private DBQLBS db = new DBQLBS();

        // GET: DATHANGs
        public ActionResult Index()
        {
            var dATHANGs = db.DATHANGs.Include(d => d.KHACHHANG);
            return View(dATHANGs.ToList());
        }

        // GET: DATHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATHANG dATHANG = db.DATHANGs.Find(id);
            if (dATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dATHANG);
        }

        // GET: DATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.makh = new SelectList(db.KHACHHANGs, "makh", "tenkh");
            return View();
        }

        // POST: DATHANGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madathang,makh,sdt,diachi,ngaydat,ngaygiao,tongdonhang,tinhtrang")] DATHANG dATHANG)
        {
            if (ModelState.IsValid)
            {
                db.DATHANGs.Add(dATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.makh = new SelectList(db.KHACHHANGs, "makh", "tenkh", dATHANG.makh);
            return View(dATHANG);
        }

        // GET: DATHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATHANG dATHANG = db.DATHANGs.Find(id);
            if (dATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.makh = new SelectList(db.KHACHHANGs, "makh", "tenkh", dATHANG.makh);
            return View(dATHANG);
        }

        // POST: DATHANGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "madathang,makh,sdt,diachi,ngaydat,ngaygiao,tongdonhang,tinhtrang")] DATHANG dATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makh = new SelectList(db.KHACHHANGs, "makh", "tenkh", dATHANG.makh);
            return View(dATHANG);
        }

        // GET: DATHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATHANG dATHANG = db.DATHANGs.Find(id);
            if (dATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dATHANG);
        }

        // POST: DATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DATHANG dATHANG = db.DATHANGs.Find(id);
            db.DATHANGs.Remove(dATHANG);
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
