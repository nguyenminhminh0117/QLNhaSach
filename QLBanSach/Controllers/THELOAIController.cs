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
    public class THELOAIController : Controller
    {
        private QLBS db = new QLBS();

        // GET: THELOAI
        public ActionResult Index()
        {
            return View(db.THELOAIs.ToList());
        }

        // GET: THELOAI/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            if (tHELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHELOAI);
        }

        // GET: THELOAI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THELOAI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matheloai,tentheloai")] THELOAI tHELOAI)
        {
            if (ModelState.IsValid)
            {
                db.THELOAIs.Add(tHELOAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHELOAI);
        }

        // GET: THELOAI/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            if (tHELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHELOAI);
        }

        // POST: THELOAI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matheloai,tentheloai")] THELOAI tHELOAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHELOAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHELOAI);
        }

        // GET: THELOAI/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            if (tHELOAI == null)
            {
                return HttpNotFound();
            }
            return View(tHELOAI);
        }

        // POST: THELOAI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THELOAI tHELOAI = db.THELOAIs.Find(id);
            db.THELOAIs.Remove(tHELOAI);
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
