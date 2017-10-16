using System.Collections.Generic;

namespace TelerikAcademy.AutoDealer.Web.Providers
{
    public interface IMapProvider
    {
        T Map<T>(object source);

        ICollection<T> GetCollection<T>(object source);
    }
}