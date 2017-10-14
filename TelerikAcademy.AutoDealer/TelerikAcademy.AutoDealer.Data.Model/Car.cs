using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.AutoDealer.Data.Model.Abstracts;

namespace TelerikAcademy.AutoDealer.Data.Model
{
    public class Car : DataModel
    {
        public Make Make { get; set; }
        [Required]
        public Guid MakeId { get; set; }
        [Required]
        [Range(1900, 2017)]
        public int YearOfProduction { get; set; }
        [Required]
        [Range(10, 10000000)]
        public decimal Price { get; set; }
        [Range(20, 1500)]
        [Required]
        public int Hp { get; set; }
        [Range(0, 1000000)]
        [Required]
        public int Mileage { get; set; }
        public Transmission Transmission { get; set; }
        [Required]
        public Guid TransmissionId { get; set; }
        [Required]
        [StringLength(600)]
        public string Description { get; set; }
        [Required]
        public string OwnerEmail { get; set; }
        public string Image1 { get; set; }
        public string Image3 { get; set; }
        public string Image2 { get; set; }
    }
}
