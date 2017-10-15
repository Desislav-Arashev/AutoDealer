using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelerikAcademy.AutoDealer.Data.Model;

namespace TelerikAcademy.AutoDealer.Web.Models
{
    public class SearchViewModel
    {
        [Display(Name = "Make")]
        public Guid? MakeId { get; set; }

        [Display(Name = "Year From")]
        public int? YearFrom { get; set; }

        [Display(Name = "Year To")]
        public int? YearTo { get; set; }

        [Display(Name = "Price From")]
        public decimal? PriceFrom { get; set; }

        [Display(Name = "Price To")]
        public decimal? PriceTo { get; set; }

        [Range(20, 1500)]
        [Display(Name = "Hp From")]
        public int? HpFrom { get; set; }

        [Range(20, 1500)]
        [Display(Name = "Hp To")]
        public int? HpTo { get; set; }

        [Display(Name = "Mileage From")]
        [Range(0, 1000000)]
        public int? MileageFrom { get; set; }

        [Display(Name = "Mileage To")]
        [Range(0, 1000000)]
        public int? MileageTo { get; set; }

        [Display(Name = "Transmission")]
        public Guid? TransmissionId { get; set; }

        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }
    }
}