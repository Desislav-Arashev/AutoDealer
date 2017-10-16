using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace TelerikAcademy.AutoDealer.Web.Areas.Administrator.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Administrator/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}