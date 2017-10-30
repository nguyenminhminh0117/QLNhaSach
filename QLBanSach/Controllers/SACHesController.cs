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
    public class SACHesController : Controller
    {
        private QLBS db = new QLBS();

        // GET: SACHes
        public ActionResult Index()
        {
            var sACHes = db.SACHes.Include(s => s.THELOAI);
            return View(sACHes.ToList());
        }

        // GET: SACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: SACHes/Create
        public ActionResult Create()
        {
            ViewBag.matheloai = new SelectList(db.THELOAIs, "matheloai", "tentheloai");
            return View();
        }

        // POST: SACHes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masach,tensach,matheloai,dongiaban,luotmua,khuyenmai,anhbia,tinhtrang,mota,nhaxuatban,tacgia,ngayxuatban,soluongton,delflag,timedel")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.SACHes.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.matheloai = new SelectList(db.THELOAIs, "matheloai", "tentheloai", sACH.matheloai);
            return View(sACH);
        }

        // GET: SACHes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.matheloai = new SelectList(db.THELOAIs, "matheloai", "tentheloai", sACH.matheloai);
            return View(sACH);
        }

        // POST: SACHes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masach,tensach,matheloai,dongiaban,luotmua,khuyenmai,anhbia,tinhtrang,mota,nhaxuatban,tacgia,ngayxuatban,soluongton,delflag,timedel")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.matheloai = new SelectList(db.THELOAIs, "matheloai", "tentheloai", sACH.matheloai);
            return View(sACH);
        }

        // GET: SACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: SACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
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
