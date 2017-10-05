using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using TelerikAcademy.AutoDealer.Web.App_Start;

namespace TelerikAcademy.AutoDealer.Web.Infrastructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> MapTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}