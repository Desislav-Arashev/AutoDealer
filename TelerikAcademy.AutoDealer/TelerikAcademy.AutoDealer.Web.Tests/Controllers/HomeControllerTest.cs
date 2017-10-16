using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelerikAcademy.AutoDealer.Web;
using TelerikAcademy.AutoDealer.Web.Controllers;
using Moq;
using TelerikAcademy.AutoDealer.Services;
using TelerikAcademy.AutoDealer.Web.Models;
using TelerikAcademy.AutoDealer.Data.Model;
using AutoMapper;
using TelerikAcademy.AutoDealer.Web.App_Start;
using TestStack.FluentMVCTesting;

namespace TelerikAcademy.AutoDealer.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void About_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            HomeController controller = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_ShouldReturnDefaultView_WhenCalled()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var sliderViewModel = new SliderViewModel()
            {
                Hp = 2,
                Description = "",
                Id = new Guid(),
                YearOfProduction = 2,
                Image1 = "",
                Mileage = 2,
                Price = 1,
                MakeId = new Guid(),
                Transmission = new Transmission() { Name = "" },
                Make = new Make() { Name = "" }
            };
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, SliderViewModel>();
            });
            HomeController homeController = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act & Assert
            homeController
                .WithCallTo(x => x.Index())
                .ShouldRenderDefaultView();
        }
        [TestMethod]
        public void About_ShouldReturnDefaultView_WhenCalled()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            HomeController homeController = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act & Assert
            homeController
                .WithCallTo(x => x.About())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Index_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var mapperMock = new Mock<IMapper>();
            var list = new List<Car>();
            var queryableCountries = list.AsQueryable();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, SliderViewModel>();
            });
            carServiceMock.Setup(x => x.GetAll()).Returns(queryableCountries);
            HomeController controller = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            HomeController controller = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void Contact_ShouldReturnDefaultView_WhenCalled()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            HomeController homeController = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act & Assert
            homeController
                .WithCallTo(x => x.Contact())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void AboutContent_ShouldPassPageTitleInViewbag_WhenCalled()
        {
            // Arrange
            var about = "";
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            HomeController homeController = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act 
            var result = homeController.About() as ViewResult;

            // Assert
            Assert.AreEqual(about, result.ViewName);
        }

        [TestMethod]
        public void ContactContent_ShouldPassPageTitleInViewbag_WhenCalled()
        {
            // Arrange
            var about = "";
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            HomeController homeController = new HomeController(carServiceMock.Object, makesServiceMock.Object, tranmissionsServiceMock.Object);

            // Act 
            var result = homeController.Contact() as ViewResult;

            // Assert
            Assert.AreEqual(about, result.ViewName);
        }
    }
}
