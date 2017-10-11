﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.AutoDealer.Data.Model;
using TelerikAcademy.AutoDealer.Data.Repositories;
using TelerikAcademy.AutoDealer.Data.UnitOfWork;
using TelerikAcademy.AutoDealer.Services.Contracts;

namespace TelerikAcademy.AutoDealer.Services
{
    class CarsService : ICarsService
    {
        private readonly IEfRepository<Car> carsRepo;
        private readonly IUnitOfWork context;

        public CarsService(IEfRepository<Car> postsRepo, IUnitOfWork context)
        {
            this.carsRepo = postsRepo;
            this.context = context;
        }

        public IQueryable<Car> GetAll()
        {
            return this.carsRepo.All;
        }

        public void Update(Car car)
        {
            this.carsRepo.Update(car);
            this.context.Commit();
        }
    }
}
