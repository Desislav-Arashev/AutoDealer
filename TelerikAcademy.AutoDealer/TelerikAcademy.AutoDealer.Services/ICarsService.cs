using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.AutoDealer.Data.Model;

namespace TelerikAcademy.AutoDealer.Services
{
    public interface ICarsService
    {
        IQueryable<Car> GetAll();
    }
}
