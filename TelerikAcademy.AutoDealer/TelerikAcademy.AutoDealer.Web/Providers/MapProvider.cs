using AutoMapper;
using System.Collections.Generic;

namespace TelerikAcademy.AutoDealer.Web.Providers
{
    public class MapProvider : IMapProvider
    {
        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public ICollection<T> GetCollection<T>(object source)
        {
            return Mapper.Map<ICollection<T>>(source);
        }
    }
}