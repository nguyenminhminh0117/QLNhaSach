using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanSach.Controllers
{
    public class HomeController : Controller
    {
        QLBS db = new QLBS();
        private List<SACH> Laysp(int count)
        {
            return db.SACHes.OrderByDescending(x => x.dongiaban).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var sp = Laysp(9);
            return View(sp);
        }
        public ActionResult TheLoai()
        {
            var s = from nh in db.THELOAIs select nh;
            return PartialView(s);
        }

        public ActionResult SPTheoTL(string id)
        {
            var s = from nh in db.SACHes where nh.matheloai == id select nh;
            return View(s);
        }
    }
}