using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
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
        public HomeController(ICarsService carsService)
        {
            this.carsService = carsService;
        }
        public ActionResult Index()
        {
            IEnumerable<SliderViewModel> cars = carsService.GetAll().OrderByDescending(x=>x.CreatedOn).Take(5).ProjectTo<SliderViewModel>().ToList();
            return View(cars);
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