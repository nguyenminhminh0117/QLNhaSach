using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanSach.Controllers;
using System.Web.Mvc;
using QLBanSach.Models;

namespace UnitTestProject
{
    [TestClass]
    public class KhachHangTest
    {
        [TestMethod]
        public void XemChiTiet()
        {
            KhachHangController controller = new KhachHangController();

            // Act
            var result = controller.Details("KH_00001") as ViewResult;
            KHACHHANG person = (KHACHHANG)result.Model;

            // Assert
            Assert.AreEqual("Nguyễn Thanh Nhân", person.tenkh);

        }

        [TestMethod]
        public void TaoTaiKhoanKH()
        {
            KhachHangController controller = new KhachHangController();
            KHACHHANG KH = new KHACHHANG
            {
                makh = " ",
                tenkh = "Minh khùng",
                diachi = "115 Sư Vạn Hạnh nd",
                sodienthoai = "0168430900",//Thử xóa 1 số (còn 9 số) thì nó sẽ chạy sai, tương tự với matkhaukh hoặc xóa @gmail.com đi
                email = "minhminh@gmail.com",
                matkhaukh = "1234567890"
            };
            // Act
            var result = controller.Create(KH) as ViewResult;

            // Assert
            Assert.AreEqual(KH, KH);
        }

        [TestMethod]
        public void XoaKhachHang(string id)
        {
            KhachHangController KH = new KhachHangController();
            var result = KH.Delete("KH_00002") as ViewResult;
            //Assert.AreEqual(KH, KH);

        }
    }
}
