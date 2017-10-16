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
    public class TransmissionsServiceTests
    {
        [TestMethod]
        public void GetAll_ReturnAlltransmissions_WhenValidtransmissionIsPassedAsParameter()
        {
            //Arrange
            var transmissionsRepo = new Mock<IEfRepository<Transmission>>();
            var list = new List<Transmission>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Transmission()
            {
                Name = "test"
            });
            transmissionsRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new TransmissionsService(transmissionsRepo.Object, uow.Object);

            // Act 
            var name = "test";
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(name, result[0].Name);
        }

        [TestMethod]
        public void Update_Updatestransmission_WhenValidtransmissionIsPassedAsParameter()
        {
            //Arrange
            var transmissionsRepo = new Mock<IEfRepository<Transmission>>();
            var list = new List<Transmission>();
            var uow = new Mock<IUnitOfWork>();
            var car = new Transmission()
            {
                Name = "test"
            };

            var sut = new TransmissionsService(transmissionsRepo.Object, uow.Object);

            // Act 
            var name = "test";
            sut.Update(car);

            //Assert
            Assert.AreEqual(name, car.Name);
        }
        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullRepositoryIsPassedAsParameter()
        {
            var uow = new Mock<IUnitOfWork>();
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TransmissionsService(null, uow.Object));
        }
        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullUnitOfWorkIsPassedAsParameter()
        {
            //Arrange 
            var transmissionsRepo = new Mock<IEfRepository<Transmission>>();
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new TransmissionsService(transmissionsRepo.Object, null));
        }
        [TestMethod]
        public void ConstructorShould_NotThrow_WhenValidtransmissionRepositoryIsPassedAsParameter()
        {
            //Arrange
            var uow = new Mock<IUnitOfWork>();
            var transmissionsRepo = new Mock<IEfRepository<Transmission>>();
            //Act & Assert
            new TransmissionsService(transmissionsRepo.Object, uow.Object);
        }
        [TestMethod]
        public void AddShould_ThrowException_WhenPassedNullAlbum()
        {
            // Arrange
            var carRepo = new Mock<IEfRepository<Transmission>>();
            var uow = new Mock<IUnitOfWork>();

            // Act
            var carsService = new TransmissionsService(carRepo.Object, uow.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => carsService.Add(null));
        }
        [TestMethod]
        public void AddShould_NotThrow_WhenValuesAreCorrect()
        {
            // Arrange
            var transmissionRepo = new Mock<IEfRepository<Transmission>>();
            var uow = new Mock<IUnitOfWork>();
            var transmission = new Mock<Transmission>();
            // Act
            var makesService = new TransmissionsService(transmissionRepo.Object, uow.Object);

            // Assert
            makesService.Add(transmission.Object);
        }
    }
}
