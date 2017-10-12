namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransmissions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transmissions", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transmissions", "Name");
        }
    }
}
