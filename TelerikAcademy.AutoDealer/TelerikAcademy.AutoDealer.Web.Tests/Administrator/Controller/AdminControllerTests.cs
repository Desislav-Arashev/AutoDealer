using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TelerikAcademy.AutoDealer.Web.Areas.Administrator.Controllers;

namespace TelerikAcademy.AutoDealer.Web.Tests.Administrator.Controller
{
    [TestClass]
   public class AdminControllerTests
    {
        [TestMethod]
        public void IndexActionShould_ReturnNotNullViewResult()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexActionShould_CallViewWithoutName()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [TestMethod]
        public void IndexActionShould_CallViewWithoutModel()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(null, result.Model);
        }
    }
}
