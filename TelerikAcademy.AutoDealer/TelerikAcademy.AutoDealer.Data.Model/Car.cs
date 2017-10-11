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
        public Guid Id { get; set; }
        [Required]
        public String Make { get; set; }
        [Required]
        public int YearOfProduction { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Hp { get; set; }
        public int Mileage { get; set; }
        public int Transmission { get; set; }
        public string Description { get; set; }
    }
}
