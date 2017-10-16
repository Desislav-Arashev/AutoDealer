using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Services;
using TelerikAcademy.AutoDealer.Web.App_Start;
using TelerikAcademy.AutoDealer.Web.Controllers;
using TelerikAcademy.AutoDealer.Web.Models;
using TestStack.FluentMVCTesting;

namespace TelerikAcademy.AutoDealer.Web.Tests.Controllers
{
    [TestClass]
    public class CarsControllerTest
    {
        [TestMethod]
        public void Index_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDetailsViewData()
        {
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, DetailsViewModel>();
            });
            var detailsModel = new DetailsViewModel() { YearOfProduction = 2010, CreatedOn = DateTime.Now, Transmission = new Transmission() { Name = "" }, Description = "", Hp = 10, Id = new Guid(), Image1 = "", Image2 = "", Image3 = "", Make = new Make() { Name = "" }, MakeId = new Guid(), Mileage = 1000, OwnerEmail = "", Price = 200 };
            CarsController homeController = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            var result = homeController.Details(new Guid()) as ViewResult;
            var product = (DetailsViewModel)result.ViewData.Model;
            Assert.IsNull(product);
        }

        [TestMethod]
        public void TestNewViewData()
        {
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
            });
            CarsController homeController = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            var result = homeController.New() as ViewResult;
            var product = (NewCarViewModel)result.ViewData.Model;
            Assert.IsNotNull(product);
        }
        [TestMethod]
        public void TestSearchViewData()
        {
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, SliderViewModel>();
            });
            var searchViewModel = new SearchViewModel() { HpFrom=0, HpTo=10, MakeId = new Guid(), Makes = new List<Make>(), MileageFrom = 0, MileageTo = 10, pageNumber = 1, PriceFrom = 1, PriceTo = 10, TransmissionId = new Guid(), YearFrom = 10, YearTo = 20, Transmissions = new List<Transmission>()};
            CarsController homeController = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            var result = homeController.Search(searchViewModel, 1) as ViewResult;
            var product = (SearchViewModel)result.ViewData.Model;
            Assert.IsNotNull(product);
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
            Mapper.Initialize(cfg =>
            {
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
        public void Search_ShouldReturnResult_WhenInvoked()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, SliderViewModel>();
            });
            var viewModelMock = new Mock<SearchViewModel>();
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            var result = controller.Search(viewModelMock.Object, 1);

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Search_ShouldReturnDefaultView_WhenInvoked()
        {
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, SliderViewModel>();
            });
            var search = new SearchViewModel() { HpFrom = 0, HpTo = 0, MakeId = new Guid(), MileageFrom = 0, MileageTo = 0, PriceFrom = 0, PriceTo = 0, YearFrom = 0, YearTo = 0 };
            CarsController carsController = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act & Assert
            carsController
                .WithCallTo(x => x.Search(search, 1))
                .ShouldRenderDefaultView();
        }
        [TestMethod]
        public void New_ShouldReturnDefaultView_WhenInvoked()
        {
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = new AutoMapperConfig();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, SliderViewModel>();
            });
            CarsController carsController = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act & Assert
            carsController
                .WithCallTo(x => x.New())
                .ShouldRenderDefaultView();
        }
        [TestMethod]
        public void Details_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, DetailsViewModel>();
            });
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = controller.Details(new Guid()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Details_ShouldReturnDefaultView_WhenInvoked()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var detailsModel = new DetailsViewModel()
            {
                CreatedOn = DateTime.Now,
                Description = "test",
                Hp = 2,
                Id = new Guid(),
                MakeId = new Guid(),
                Mileage = 200,
                OwnerEmail = "test@abv.bg",
                Price = 2,
                YearOfProduction = 2010,
                Image1 = "test1",
                Image2 = "test2",
                Image3 = "test3",
                Make = new Make(),
                Transmission = new Transmission()
            };
            var mapperMock = new Mock<IMapper>();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, DetailsViewModel>();
            });
            CarsController carsController = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = carsController.Details(new Guid()) as ViewResult;

            // Assert
            carsController
                .WithCallTo(x => x.Details(detailsModel.Id))
                .ShouldRenderDefaultView();
        }
        [TestMethod]
        public void New_ShouldNotBeNull()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var mapperMock = new Mock<IMapper>();
            CarsController controller = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = controller.New() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void New_ShouldReturnDefaultView()
        {
            // Arrange
            var carServiceMock = new Mock<ICarsService>();
            var makesServiceMock = new Mock<IMakesService>();
            var tranmissionsServiceMock = new Mock<ITransmissionsService>();
            var car = new NewCarViewModel() { Description = "", Hp = 22, MakeId = new Guid(), Mileage = 200, Price = 2, TransmissionId = new Guid(), YearOfProduction = 2 };
            var mapperMock = new Mock<IMapper>();
            CarsController carsController = new CarsController(makesServiceMock.Object, tranmissionsServiceMock.Object, carServiceMock.Object, mapperMock.Object);

            // Act
            ViewResult result = carsController.New() as ViewResult;

            // Assert
            carsController
                .WithCallTo(x => x.New())
                .ShouldRenderDefaultView();
        }
    }
}
