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
    public class MakesServiceTests
    {
        [TestMethod]
        public void GetAll_ReturnAllMakes_WhenValidMakeIsPassedAsParameter()
        {
            //Arrange
            var makesRepo = new Mock<IEfRepository<Make>>();
            var list = new List<Make>();
            var uow = new Mock<IUnitOfWork>();
            list.Add(new Make()
            {
                Name = "test"
            });
            makesRepo.Setup(u => u.All).Returns(list.AsQueryable);

            var sut = new MakesService(makesRepo.Object, uow.Object);

            // Act 
            var name = "test";
            var result = sut.GetAll().ToList();

            //Assert
            Assert.AreEqual(name, result[0].Name);
        }

        [TestMethod]
        public void Update_UpdatesMake_WhenValidMakeIsPassedAsParameter()
        {
            //Arrange
            var makesRepo = new Mock<IEfRepository<Make>>();
            var list = new List<Make>();
            var uow = new Mock<IUnitOfWork>();
            var car = new Make()
            {
                Name = "test"
            };

            var sut = new MakesService(makesRepo.Object, uow.Object);

            // Act 
            var name = "test";
            sut.Update(car);

            //Assert
            Assert.AreEqual("test", car.Name);
        }
        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullRepositoryIsPassedAsParameter()
        {
            var uow = new Mock<IUnitOfWork>();
            //Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new MakesService(null, uow.Object));
        }
        [TestMethod]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullUnitOfWorkIsPassedAsParameter()
        {
            //Arrange 
            var makesRepo = new Mock<IEfRepository<Make>>();
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new MakesService(makesRepo.Object, null));
        }
        [TestMethod]
        public void ConstructorShould_NotThrow_WhenValidMakeRepositoryIsPassedAsParameter()
        {
            //Arrange
            var uow = new Mock<IUnitOfWork>();
            var makesRepo = new Mock<IEfRepository<Make>>();
            //Act & Assert
            new MakesService(makesRepo.Object, uow.Object);
        }
    }
}
