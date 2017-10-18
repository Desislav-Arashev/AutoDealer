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
    public class CarsService : IService, ICarsService
    {
        private readonly IEfRepository<Car> carsRepo;
        private readonly IUnitOfWork context;

        public CarsService(IEfRepository<Car> postsRepo, IUnitOfWork context)
        {
            if (postsRepo == null || context == null)
            {
                throw new ArgumentNullException();
            }
            this.carsRepo = postsRepo;
            this.context = context;
        }

        public void Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException();
            }
             this.carsRepo.Add(car);
            this.context.Commit();
        }

        public void Delete(Car car)
        {
            this.carsRepo.Delete(car);
            this.context.Commit();
        }

        public IQueryable<Car> GetAll()
        {
            return this.carsRepo.All;
        }

        public IQueryable<Car> GetAllAndDeleted()
        {
            return this.carsRepo.AllAndDeleted;
        }

        public void Update(Car car)
        {
            this.carsRepo.Update(car);
            this.context.Commit();
        }
    }
}
