using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Services;
using TelerikAcademy.AutoDealer.Web.Areas.Administrator.Controllers;
using TelerikAcademy.AutoDealer.Web.Areas.Administrator.Models;
using TelerikAcademy.AutoDealer.Web.Providers;

namespace TelerikAcademy.AutoDealer.Web.Tests.Administrator.Controller
{
    [TestClass]
    public class CarsController
    {
        [TestMethod]
        public void DeleteCarsShould_ReturnJSON_WithModelParameter()
        {
            //Arrange
            var carsService = new Mock<ICarsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new CarsGridController(carsService.Object, mapProvider.Object);

            var description = "Description";
            var model = new CarViewModel()
            {
                Description = description
            };

            //Act 
            var result = sut.DeleteCar(model) as JsonResult;

            var data = result.Data as IList<CarViewModel>;

        }

        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullServiceIsPassedAsParameter()
        {
            //Arrange
            var mapProvider = new Mock<IMapProvider>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CarsGridController(null, mapProvider.Object));
        }

        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullMapProviderIsPassedAsParameter()
        {
            //Arrange
            var carsService = new Mock<ICarsService>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CarsGridController(carsService.Object, null));
        }

        [TestMethod]
        public void ConstructorShould_NotThrow_WhenValidArePassedAsParameters()
        {
            //Arrange
            var carsService = new Mock<ICarsService>();
            var mapProvider = new Mock<IMapProvider>();

            //Act & Assert
            var x = new CarsGridController(carsService.Object, mapProvider.Object);
        }

        [TestMethod]
        public void GetCarsShould_CallServiceMethodGetAllAndDeleted()
        {
            //Arrange
            var carsService = new Mock<ICarsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new CarsGridController(carsService.Object, mapProvider.Object);

            var request = new DataSourceRequest();
            var cars = new List<Car>();
            carsService.Setup(c => c.GetAll()).Returns(new List<Car>(cars).AsQueryable());

            var carViewList = new List<CarViewModel>();
            mapProvider.Setup(m => m.GetCollection<CarViewModel>(It.IsAny<Object>())).Returns(carViewList);

            //Act 
            sut.GetCars(request);

            //Assert
            carsService.Verify(c => c.GetAllAndDeleted(), Times.Once);
        }

        [TestMethod]
        public void GetCarsShould_CallMapperProviderMethodGetMapCollection()
        {
            //Arrange
            var carsService = new Mock<ICarsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new CarsGridController(carsService.Object, mapProvider.Object);

            var request = new DataSourceRequest();
            var cars = new List<Car>();
            carsService.Setup(c => c.GetAll()).Returns(new List<Car>(cars).AsQueryable());

            var carViewList = new List<CarViewModel>();
            mapProvider.Setup(m => m.GetCollection<CarViewModel>(It.IsAny<Object>())).Returns(carViewList);

            //Act 
            sut.GetCars(request);

            //Assert
            mapProvider.Verify(m => m.GetCollection<CarViewModel>(cars), Times.Once);
        }

        [TestMethod]
        public void DeleteCarsShould_CallServiceMethodDelete()
        {
            //Arrange
            var carsService = new Mock<ICarsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new CarsGridController(carsService.Object, mapProvider.Object);

            var description = "Description";
            var model = new CarViewModel()
            {
                Description = description
            };

            //Act 
            sut.DeleteCar(model);

            //Assert
            carsService.Verify(c => c.Delete(null), Times.Once);
        }

    }
}
