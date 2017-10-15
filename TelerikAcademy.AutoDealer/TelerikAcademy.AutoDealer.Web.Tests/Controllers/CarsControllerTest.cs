using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Services;
using TelerikAcademy.AutoDealer.Web.App_Start;
using TelerikAcademy.AutoDealer.Web.Controllers;
using TelerikAcademy.AutoDealer.Web.Models;

namespace TelerikAcademy.AutoDealer.Web.Tests.Controllers
{
    [TestClass]
    public class CarsControllerTest
    {
        [TestMethod]
        public void Contact_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object,  mapperMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Car, SliderViewModel>();
            });
            var viewModelMock = new Mock<SearchViewModel>();
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = controller.Search(viewModelMock.Object, 1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Details_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Car, DetailsViewModel>();
            });
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = controller.Details(new Guid()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        public void New_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var carMock = new Mock<NewCarViewModel>();
            var mapperMock = new Mock<IMapper>();
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = controller.New(carMock.Object) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
