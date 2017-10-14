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
    public class TransmissionsService : IService, ITransmissionsService
    {
        private readonly IEfRepository<Transmission> carsRepo;
        private readonly IUnitOfWork context;

        public TransmissionsService(IEfRepository<Transmission> postsRepo, IUnitOfWork context)
        {
            this.carsRepo = postsRepo;
            this.context = context;
        }

        public void Add(Transmission car)
        {
            this.carsRepo.Add(car);
            this.context.Commit();
        }

        public IQueryable<Transmission> GetAll()
        {
            return this.carsRepo.All;
        }

        public void Update(Transmission car)
        {
            this.carsRepo.Update(car);
            this.context.Commit();
        }
    }
}
