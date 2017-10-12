namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarOwnerRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "OwnerEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "OwnerEmail", c => c.String());
        }
    }
}
