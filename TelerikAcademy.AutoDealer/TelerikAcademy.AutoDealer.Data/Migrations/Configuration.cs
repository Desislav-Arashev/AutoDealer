using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using TelerikAcademy.AutoDealer.Data.Model;

namespace TelerikAcademy.AutoDealer.Data.Migrations
{

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        private const string AdministratorUserName = "admin@autodealer.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedUsers(context);
            this.SeedSampleData(context);

            base.Seed(context);
        }

        private void SeedUsers(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedSampleData(MsSqlDbContext context)
        {
            string[] makeNames = { "AC", "Acura", "Alfa Romeo", "Aston martin", "Audi, Austin", "BMW, Bentley", "Berliner", "Borgward", "Brilliance", "Bugatti", "Buick", "Cadillac", "Chevrolet", "Chrysler", "Citroen", "Corvette", "Dacia", "Daewoo", "Daihatsu", "Daimler", "Datsun", "Dkw", "Dodge", "Dr", "Eagle", "FSO", "Ferrari", "Fiat", "Ford", "Geo", "Great Wall", "Heinkel", "Honda", "Hyundai", "Ifa", "Infiniti", "Innocenti", "Isuzu", "Jaguar", "Kia", "Lada", "Lamborghini", "Lancia", "Lexus", "Lifan", "Lincoln", "Lotus", "Maserati", "Matra", "Maybach", "Mazda", "McLaren", "Mercedes-Benz", "Mercury", "Mg", "Microcar", "Mini", "Mitsubishi", "Morgan", "Moskvich", "Nissan", "Oldsmobile", "Opel", "Perodua", "Peugeot", "Pontiac", "Porsche", "Proton", "Renault", "Rolls-Royce", "Rover", "SECMA", "Saab", "Samand", "Saturn", "Scion", "Seat", "Shatenet", "Shuanghuan", "Simca", "Skoda", "Smart", "Subaru", "Suzuki", "Talbot", "Tata", "Tavria", "Tazzari", "Terberg", "Tesla", "Tofas", "Toyota", "Trabant", "Triumph", "VROMOS", "VW", "Volga", "Volvo", "Warszawa", "Wartburg", "Wiesmann", "Xinshun", "Zastava", "Zaz" };
            if (!context.Makes.Any())
            {
                for (int i = 0; i < makeNames.Length; i++)
                {
                    var make = new Make { Name = makeNames[i] };
                    context.Makes.Add(make);
                }
            }
        }
    }
}