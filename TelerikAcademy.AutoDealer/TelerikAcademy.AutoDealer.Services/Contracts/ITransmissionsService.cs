using System.Linq;
using TelerikAcademy.AutoDealer.Data.Model;

namespace TelerikAcademy.AutoDealer.Services
{
    public interface ITransmissionsService
    {
        void Add(Transmission transmission);
        IQueryable<Transmission> GetAll();
        void Update(Transmission transmission);
    }
}