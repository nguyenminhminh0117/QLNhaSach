using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanSach.Controllers
{
    public class GioHangController : Controller
    {
        QLBS db = new QLBS();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = 
                Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;

            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(string sMaSach, string strURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.Find(n => n.sMaSach == sMaSach);
            if (sanpham == null)
            {
                sanpham = new GioHang(sMaSach);
                lstGioHang.Add(sanpham);
                return RedirectToAction("GioHangs", "GioHang");
            }
            else
            {
                sanpham.iSoLuong++;
                return RedirectToAction("GioHangs", "GioHang");
            }
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> lstGioHang = Session["Giohang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return iTongTien;
        }
        public ActionResult GioHangs()
        {
            if (LayGioHang().Count == 0)
            {
                TempData["GioHangError"] = "Giỏ hàng của bạn chưa có gì.";
                return RedirectToAction("Index", "Home");
            }
            var list = db.SACHes;
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(list.ToList());
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult XoaGioHang(string sMaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.sMaSach == sMaSP);

            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.sMaSach == sMaSP);
                return RedirectToAction("GioHangs");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHangs");
        }
        public ActionResult CapNhatGioHang(string sMaSP, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.sMaSach == sMaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHangs", "GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("GioHangs", "GioHang");
        }
    }
}