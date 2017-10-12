using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.AutoDealer.Data.Model.Abstracts;

namespace TelerikAcademy.AutoDealer.Data.Model
{
    public class Make : DataModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
