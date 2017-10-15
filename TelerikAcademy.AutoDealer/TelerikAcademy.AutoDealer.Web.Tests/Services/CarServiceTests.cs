using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Data.Repositories;
using TelerikAcademy.AutoDealer.Data.UnitOfWork;
using TelerikAcademy.AutoDealer.Services;

namespace TelerikAcademy.AutoDealer.Web.Tests.Services
{
    [TestClass]
    public class CarServiceTests
    {
        [TestMethod]
        public void GetAll_ReturnAllCars_WhenValidCarPriceIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Car()
            {
                Price = 200
            });
            carsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var price = 200;
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(price, result[0].Price);
        }

        [TestMethod]
        public void Update_UpdatesCar_WhenValidCarPriceIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            var car = new Car()
            {
                Price = 200
            };

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var price = 200;
            sut.Update(car);

            //Assert
            Assert.AreEqual(price, car.Price);
        }
        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullRepositoryIsPassedAsParameter()
        {
            var uow = new Mock<IUnitOfWork>();
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CarsService(null, uow.Object));
        }
        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullUnitOfWorkIsPassedAsParameter()
        {
            //Arrange 
            var carsRepo = new Mock<IEfRepository<Car>>();
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CarsService(carsRepo.Object, null));
        }
        [TestMethod]
        public void ConstructorShould_NotThrow_WhenValidCarRepositoryIsPassedAsParameter()
        {
            //Arrange
            var uow = new Mock<IUnitOfWork>();
            var carsRepo = new Mock<IEfRepository<Car>>();
            //Act & Assert
            new CarsService(carsRepo.Object, uow.Object);
        }
    }
}
