using System;
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
    public class MakesService : IService, IMakesService
    {
        private readonly IEfRepository<Make> carsRepo;
        private readonly IUnitOfWork context;

        public MakesService(IEfRepository<Make> postsRepo, IUnitOfWork context)
        {
            if (postsRepo == null || context == null)
            {
                throw new ArgumentNullException();
            }
            this.carsRepo = postsRepo;
            this.context = context;
        }

        public void Add(Make car)
        {
            this.carsRepo.Add(car);
            this.context.Commit();
        }

        public IQueryable<Make> GetAll()
        {
            return this.carsRepo.All;
        }

        public void Update(Make car)
        {
            this.carsRepo.Update(car);
            this.context.Commit();
        }
    }
}
