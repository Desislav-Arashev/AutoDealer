namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Make = c.String(nullable: false),
                        YearOfProduction = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hp = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        Transmission = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cars", new[] { "IsDeleted" });
            DropTable("dbo.Cars");
        }
    }
}
