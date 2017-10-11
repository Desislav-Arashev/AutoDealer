using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademy.AutoDealer.Data.Model
{
    public class Make
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        string Name { get; set; }
    }
}
