using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikAcademy.AutoDealer.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SliderViewModel> Slides { get; set; }
        public SearchViewModel Search { get; set; }
    }
}