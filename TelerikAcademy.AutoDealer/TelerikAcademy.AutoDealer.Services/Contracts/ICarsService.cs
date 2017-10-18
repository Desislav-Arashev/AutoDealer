﻿using System.Linq;
using TelerikAcademy.AutoDealer.Data.Model;

namespace TelerikAcademy.AutoDealer.Services
{
    public interface ICarsService
    {
        void Add(Car car);
        IQueryable<Car> GetAll();
        IQueryable<Car> GetAllAndDeleted();
        void Update(Car car);
        void Delete(Car car);
    }
}