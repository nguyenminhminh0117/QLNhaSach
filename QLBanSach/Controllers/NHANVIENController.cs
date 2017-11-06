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
    public class NhanVienController : Controller
    {
        private QLBS db = new QLBS();

        // GET: NHANVIEN
        public ActionResult Index()
        {
            var nHANVIENs = db.NHANVIENs.Include(n => n.QUYEN);
            return View(nHANVIENs.ToList());
        }

        // GET: NHANVIEN/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIEN/Create
        public ActionResult Create()
        {
            ViewBag.maquyen = new SelectList(db.QUYENs, "maquyen", "tenquyen");
            return View();
        }

        // POST: NHANVIEN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "manv,tennv,ngaysinh,diachi,sodienthoai,email,matkhaunv,maquyen,tinhtrang")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maquyen = new SelectList(db.QUYENs, "maquyen", "tenquyen", nHANVIEN.maquyen);
            return View(nHANVIEN);
        }

        // GET: NHANVIEN/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.maquyen = new SelectList(db.QUYENs, "maquyen", "tenquyen", nHANVIEN.maquyen);
            return View(nHANVIEN);
        }

        // POST: NHANVIEN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "manv,tennv,ngaysinh,diachi,sodienthoai,email,matkhaunv,maquyen,tinhtrang")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maquyen = new SelectList(db.QUYENs, "maquyen", "tenquyen", nHANVIEN.maquyen);
            return View(nHANVIEN);
        }

        // GET: NHANVIEN/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
