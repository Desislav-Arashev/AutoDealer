using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Services;
using TelerikAcademy.AutoDealer.Web.Models;

namespace TelerikAcademy.AutoDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private ICarsService carsService;
        private ITransmissionsService transmissionsService;
        private IMakesService makesService;
        private IMapper mapper;
        public CarsController(IMakesService makesService, ITransmissionsService transmissionsService, ICarsService carsService, IMapper mapper)
        {
            this.transmissionsService = transmissionsService;
            this.makesService = makesService;
            this.mapper = mapper;
            this.carsService = carsService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(Guid id)
        {
            var viewModel = this.carsService.GetAll().ProjectTo<DetailsViewModel>().SingleOrDefault(x => x.Id == id);
            

            return View(viewModel);
        }
        public ActionResult New()
        {
            var makes = this.makesService.GetAll().ToList();
            var transmissions = this.transmissionsService.GetAll().ToList();
            var viewModel = new NewCarViewModel();
            viewModel.Makes = makes;
            viewModel.Transmissions = transmissions.OrderBy(x => x.Name);
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult New(NewCarViewModel car)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCarViewModel();
                return View(viewModel);
            }
            Car carModel = this.mapper.Map<Car>(car);
            var count = 0;
            if (Request.Files[0].ContentLength == 0)
            {
                carModel.Image1 = "/Content/Images/default.jpg";
            }
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].ContentLength == 0)
                {
                    continue;
                }
                string pathToSave = Server.MapPath("~/Content/Images/");
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                Request.Files[upload].SaveAs(Path.Combine(pathToSave, filename));
                switch (count)
                {
                    case 0:
                        carModel.Image1 = Path.Combine("/Content/Images/", filename);
                        break;
                    case 1:
                        carModel.Image2 = Path.Combine("/Content/Images/", filename);
                        break;
                    case 2:
                        carModel.Image3 = Path.Combine("/Content/Images/", filename);
                        break;
                    default:
                        break;
                }
                count++;
            }

            carModel.OwnerEmail = this.User.Identity.Name;
            carsService.Add(carModel);
            return RedirectToAction("Index", "Home");
        }
    }
}