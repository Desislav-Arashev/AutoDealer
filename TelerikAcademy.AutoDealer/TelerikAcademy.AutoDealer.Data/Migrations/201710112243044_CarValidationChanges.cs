namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarValidationChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Description", c => c.String());
        }
    }
}
