using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanSach.Models
{
    public class GioHang
    {
        QLBS db = new QLBS();
        public string sMaSach { set; get; }
        public string sTenSach { set; get; }
        public string sAnh { set; get; }
        public double dDonGia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhTien { get { return dDonGia * iSoLuong; } }

        public GioHang (string MaSach)
        {
            sMaSach = MaSach;
            SACH s = db.SACHes.Single(x => x.masach == sMaSach);
            sTenSach = s.tensach;
            sAnh = s.anhbia;
            dDonGia = double.Parse(s.dongiaban.ToString());
            iSoLuong = 1;
        }
    }
}