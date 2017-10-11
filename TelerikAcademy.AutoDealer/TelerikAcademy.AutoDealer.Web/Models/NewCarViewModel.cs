using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelerikAcademy.AutoDealer.Data.Model;

namespace TelerikAcademy.AutoDealer.Web.Models
{
    public class NewCarViewModel
    {
        [Required]
        public String Make { get; set; }
        [Required]
        public int YearOfProduction { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Range(20, 1500)]
        [Required]
        public int Hp { get; set; }
        [Range(0, 1000000)]
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int Transmission { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}