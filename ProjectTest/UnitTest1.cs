using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanSach.Controllers;

namespace ProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController controller = new HomeController();

            ViewResult rs = controller.Index();



        }
    }
}
