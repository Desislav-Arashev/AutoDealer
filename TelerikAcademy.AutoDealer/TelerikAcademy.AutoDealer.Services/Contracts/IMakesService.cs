using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.AutoDealer.Data.Model;

namespace TelerikAcademy.AutoDealer.Services
{
    public interface IMakesService
    {
        void Add(Make make);
        IQueryable<Make> GetAll();
        void Update(Make make);
    }
}
