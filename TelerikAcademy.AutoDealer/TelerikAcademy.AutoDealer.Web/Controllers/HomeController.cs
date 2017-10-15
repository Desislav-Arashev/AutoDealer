using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.AutoDealer.Services;
using TelerikAcademy.AutoDealer.Web.Models;

namespace TelerikAcademy.AutoDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICarsService carsService;
        private ITransmissionsService transmissionsService;
        private IMakesService makesService;
        public HomeController(ICarsService carsService, IMakesService makesService, ITransmissionsService transmissionsService)
        {
            this.makesService = makesService;
            this.transmissionsService = transmissionsService;
            this.carsService = carsService;
        }
        public ActionResult Index()
        {
            IEnumerable<SliderViewModel> cars = 
                carsService.GetAll().
                Include(m => m.Make).OrderByDescending(x => x.CreatedOn).Take(5).ProjectTo<SliderViewModel>().ToList();
            var viewModel = new HomeViewModel();
            viewModel.Slides = cars;
            viewModel.Search = new SearchViewModel();
            var makes = this.makesService.GetAll().ToList();
            var transmissions = this.transmissionsService.GetAll().ToList();
            viewModel.Search.Makes = makes;
            viewModel.Search.Transmissions = transmissions.OrderBy(x => x.Name);
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}