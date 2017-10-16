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
        public void GetAll_ReturnAllCars_WhenValidCarYearIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Car()
            {
                YearOfProduction = 2010
            });
            carsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var year = 2010;
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(year, result[0].YearOfProduction);
        }

        [TestMethod]
        public void GetAll_ReturnAllCars_WhenValidCarHpIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Car()
            {
                Hp = 100
            });
            carsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var hp = 100;
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(hp, result[0].Hp);
        }

        [TestMethod]
        public void GetAll_ReturnAllCars_WhenValidCarIsDeletedIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Car()
            {
                IsDeleted = true
            });
            carsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var deleted = true;
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(deleted, result[0].IsDeleted);
        }

        [TestMethod]
        public void GetAll_ReturnAllCars_WhenValidCarCreatedOnIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Car()
            {
                CreatedOn = new DateTime()
            });
            carsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var createdOn = new DateTime();
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(createdOn, result[0].CreatedOn);
        }

        [TestMethod]
        public void GetAll_ReturnAllCars_WhenValidImageOnIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Car()
            {
                Image1 = "test"
            });
            carsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var check = "test";
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(check, result[0].Image1);
        }

        [TestMethod]
        public void GetAll_ReturnAllCars_WhenValidCarIsPassedAsParameter()
        {
            //Arrange
            var carsRepo = new Mock<IEfRepository<Car>>();
            var list = new List<Car>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Car()
            {
                Description = "",
                Id = new Guid(),
                Image1 = "test1",
                Image2 = "test2",
                Image3 = "Test3",
                Hp = 0,
                Make = new Make(),
                MakeId = new Guid(),
                Mileage = 2,
                ModifiedOn = new DateTime(),
                YearOfProduction = 2012,
                TransmissionId = new Guid(),
                Transmission = new Transmission(),
                OwnerEmail = "",
                Price = 2,
                DeletedOn = new DateTime(),
                CreatedOn = new DateTime(),
                IsDeleted = true
            });
            carsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new CarsService(carsRepo.Object, uow.Object);

            // Act 
            var model = new Car()
            {
                Description = "",
                Id = new Guid(),
                Image1 = "test1",
                Image2 = "test2",
                Image3 = "Test3",
                Hp = 0,
                Make = new Make(),
                MakeId = new Guid(),
                Mileage = 2,
                ModifiedOn = new DateTime(),
                YearOfProduction = 2012,
                TransmissionId = new Guid(),
                Transmission = new Transmission(),
                OwnerEmail = "",
                Price = 2,
                DeletedOn = new DateTime(),
                CreatedOn = new DateTime(),
                IsDeleted = true
            };
            var result = sut.GetAll().ToList();

            //Assert
            Assert.IsTrue(model.Image3 == result[0].Image3);
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

        [TestMethod]
        public void AddShould_ThrowException_WhenPassedNullAlbum()
        {
            // Arrange
            var carRepo = new Mock<IEfRepository<Car>>();
            var uow = new Mock<IUnitOfWork>();

            // Act
            var carsService = new CarsService(carRepo.Object, uow.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => carsService.Add(null));
        }

        [TestMethod]
        public void AddShould_NotThrow_WhenValuesAreCorrect()
        {
            // Arrange
            var carRepo = new Mock<IEfRepository<Car>>();
            var uow = new Mock<IUnitOfWork>();
            var car = new Mock<Car>();
            // Act
            var carsService = new CarsService(carRepo.Object, uow.Object);

            // Assert
            carsService.Add(car.Object);
        }
    }
}
