using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Web.Infrastructure;

namespace TelerikAcademy.AutoDealer.Web.Models
{
    public class NewCarViewModel : IMapFrom<Car>
    {
        [Required]
        [Display(Name = "Make")]
        public Guid? MakeId { get; set; }
        [Required]
        [Display(Name = "Year")]
        public int? YearOfProduction { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Range(20, 1500)]
        [Required]
        public int? Hp { get; set; }
        [Range(0, 1000000)]
        [Required]
        public int? Mileage { get; set; }
        [Required]
        [Display(Name = "Transmission")]
        public Guid? TransmissionId { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }
    }
}