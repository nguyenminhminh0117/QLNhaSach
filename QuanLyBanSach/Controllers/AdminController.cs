using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyBanSach.Models;

namespace QuanLyBanSach.Controllers
{
    public class AdminController : Controller
    {
        DBQLBS db = new DBQLBS();
        // GET: Admin
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginAd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAd(NHANVIEN U)
        {
            var count = db.NHANVIENs.Where(x => x.email == U.email && x.matkhaunv == U.matkhaunv).Count();
            if (count == 0)
            {
                ViewBag.Msg = "Người dùng không đúng";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.email, false);
                return RedirectToAction("Index", "Admin");
            }
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }
    }
}