using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KHACHHANG U)
        {
            var count = db.KHACHHANGs.Where(x => x.email == U.email && x.matkhaukh == U.matkhaukh).Count();
            if(count == 0)
            {
                ViewBag.Msg = "Sai mật khẩu hoặc email! Mời nhập lại!";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.email, false);
                return RedirectToAction(Url.Action("Index","Home"));
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}