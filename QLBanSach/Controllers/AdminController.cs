using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLBanSach.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        QLBS db = new QLBS();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NHANVIEN U)
        {
            var count = db.NHANVIENs.Where(x => x.email == U.email && x.matkhaunv == U.matkhaunv).Count();
            if (count == 0)
            {
                ViewBag.Msg = "AAAAAAAAAAAAAAA";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.email, false);
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}