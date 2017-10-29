﻿using QuanLyBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyBanSach.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        DBQLBS db = new DBQLBS();
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
            if (count == 0)
            {
                ViewBag.Msg = "Người dùng không đúng";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.email, false);
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}