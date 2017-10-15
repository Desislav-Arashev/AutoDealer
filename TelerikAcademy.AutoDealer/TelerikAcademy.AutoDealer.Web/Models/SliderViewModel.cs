using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Web.Infrastructure;

namespace TelerikAcademy.AutoDealer.Web.Models
{
    public class SliderViewModel : IMapFrom<Car>
    {
        [Required]
        public Make Make { get; set; }
        [Required]
        public Guid? MakeId { get; set; }
        [Required]
        public int YearOfProduction { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Range(20, 1500)]
        [Required]
        public int Hp { get; set; }
        [Range(0, 1000000)]
        [Required]
        public int? Mileage { get; set; }
        [Required]
        public Transmission Transmission { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string Image1 { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}