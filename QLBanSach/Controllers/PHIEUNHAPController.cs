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
    public class PHIEUNHAPController : Controller
    {
        private QLBS db = new QLBS();

        // GET: PHIEUNHAP
        public ActionResult Index()
        {
            var pHIEUNHAPs = db.PHIEUNHAPs.Include(p => p.NHACUNGCAP).Include(p => p.NHANVIEN);
            return View(pHIEUNHAPs.ToList());
        }

        // GET: PHIEUNHAP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            if (pHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAP);
        }

        // GET: PHIEUNHAP/Create
        public ActionResult Create()
        {
            ViewBag.mancc = new SelectList(db.NHACUNGCAPs, "mancc", "tenncc");
            ViewBag.manv = new SelectList(db.NHANVIENs, "manv", "tennv");
            return View();
        }

        // POST: PHIEUNHAP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mapn,manv,mancc,soluongnhap,ngaylapphieu,tongtiennhap")] PHIEUNHAP pHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUNHAPs.Add(pHIEUNHAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mancc = new SelectList(db.NHACUNGCAPs, "mancc", "tenncc", pHIEUNHAP.mancc);
            ViewBag.manv = new SelectList(db.NHANVIENs, "manv", "tennv", pHIEUNHAP.manv);
            return View(pHIEUNHAP);
        }

        // GET: PHIEUNHAP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            if (pHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.mancc = new SelectList(db.NHACUNGCAPs, "mancc", "tenncc", pHIEUNHAP.mancc);
            ViewBag.manv = new SelectList(db.NHANVIENs, "manv", "tennv", pHIEUNHAP.manv);
            return View(pHIEUNHAP);
        }

        // POST: PHIEUNHAP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mapn,manv,mancc,soluongnhap,ngaylapphieu,tongtiennhap")] PHIEUNHAP pHIEUNHAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUNHAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mancc = new SelectList(db.NHACUNGCAPs, "mancc", "tenncc", pHIEUNHAP.mancc);
            ViewBag.manv = new SelectList(db.NHANVIENs, "manv", "tennv", pHIEUNHAP.manv);
            return View(pHIEUNHAP);
        }

        // GET: PHIEUNHAP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            if (pHIEUNHAP == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAP);
        }

        // POST: PHIEUNHAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUNHAP pHIEUNHAP = db.PHIEUNHAPs.Find(id);
            db.PHIEUNHAPs.Remove(pHIEUNHAP);
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
