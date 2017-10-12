namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "OwnerEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "OwnerEmail");
        }
    }
}
