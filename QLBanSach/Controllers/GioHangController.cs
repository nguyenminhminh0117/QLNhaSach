using QLBanSach.Dao;
using QLBanSach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
            if (Session["Taikhoan"] == null)
            {
                TempData["ThemGioHangError"] = "Bạn cân đăng nhập để thực hiện tính năng này.";
                return RedirectToAction("Index", "Home");
            }
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

        [HttpGet]
        public ActionResult DatHang()
        {
            //kiểm tra đăng nhập
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //lấy giỏ hàng từ session
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();

            return View(lstGioHang);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection collection, string sdt, string diachi, string ngaygiao)
        {
            KHACHHANG kh = new KHACHHANG();
            DATHANG ddh = new DATHANG();
            List<GioHang> gh = LayGioHang();
            ddh.madathang = "";
            ddh.makh = Session["TaiKhoan"].ToString();
            ddh.sdt = sdt;
            ddh.diachi = diachi;
            ddh.ngaydat = DateTime.Now;
            var NgayGiao = String.Format("{0:MM/dd/yyyy}", ngaygiao);
            ddh.ngaygiao = DateTime.Parse(NgayGiao);
            ddh.tongdonhang = int.Parse(TongTien().ToString());
            ddh.tinhtrang = false;
            //db.DATHANGs.Add(ddh);
            //db.SaveChanges();
            var id = new DatHangDao().Insert(ddh);
            var ctddh = new CTDatHangDao();
            foreach (var item in gh)
            {
                CT_DATHANG ctdh = new CT_DATHANG();
                ctdh.madathang = ddh.madathang;
                ctdh.masach = item.sMaSach;
                ctdh.soluongdat = item.iSoLuong;
                ctdh.dongia = int.Parse(item.dDonGia.ToString());
                ctdh.thanhtien = int.Parse(item.dThanhTien.ToString());
                ctdh.delflag = 0;
                //db.CT_DATHANG.Add(ctdh);
                ctddh.Insert(ctdh);
            }
            //db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}
