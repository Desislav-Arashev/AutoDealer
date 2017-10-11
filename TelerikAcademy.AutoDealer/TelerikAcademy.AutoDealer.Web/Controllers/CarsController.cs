using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.AutoDealer.Web.Models;

namespace TelerikAcademy.AutoDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        public CarsController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            var viewModel = new NewCarViewModel();
            return View(viewModel);
        }
    }
}