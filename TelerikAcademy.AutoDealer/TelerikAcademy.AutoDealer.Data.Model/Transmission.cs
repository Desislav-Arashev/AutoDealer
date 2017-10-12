using System.ComponentModel.DataAnnotations;
using TelerikAcademy.AutoDealer.Data.Model.Abstracts;

namespace TelerikAcademy.AutoDealer.Data.Model
{
    public class Transmission : DataModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}