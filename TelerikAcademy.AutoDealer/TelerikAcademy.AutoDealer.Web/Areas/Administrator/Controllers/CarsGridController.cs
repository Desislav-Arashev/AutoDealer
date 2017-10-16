using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Services;
using TelerikAcademy.AutoDealer.Web.Areas.Administrator.Models;
using TelerikAcademy.AutoDealer.Web.Providers;

namespace TelerikAcademy.AutoDealer.Web.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsGridController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IMapProvider mapProvider;

        public CarsGridController(ICarsService carsService, IMapProvider mapper)
        {
            this.carsService = carsService ?? throw new ArgumentNullException();
            this.mapProvider = mapper ?? throw new ArgumentNullException();
        }

        public ActionResult GetCars([DataSourceRequest] DataSourceRequest request)
        {
            var cars = this.carsService.GetAllAndDeleted();

            var carsView = this.mapProvider.GetCollection<CarViewModel>(cars).ToList().ToDataSourceResult(request);
            

            return Json(carsView);
        }

        public ActionResult UpdateCar(CarViewModel carModel)
        {
            var car = this.mapProvider.Map<Car>(carModel);

            carsService.Update(car);

            return Json(new[] { carModel });
        }

        public ActionResult DeleteCar(CarViewModel carModel)
        {
            var car = this.mapProvider.Map<Car>(carModel);
            carsService.Delete(car);

            return Json(new[] { carModel });
        }
    }
}