using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QLBanSach.Models;
using QLBanSach.Controllers;
using System.Web.Mvc;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            HomeController controller = new HomeController();
            var sp = new Mock<SACH>();

            //Act
            ViewResult expected = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual(expected, sp);
        }
    }
}
