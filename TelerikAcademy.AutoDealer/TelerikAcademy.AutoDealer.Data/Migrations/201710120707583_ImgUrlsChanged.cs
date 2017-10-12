namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImgUrlsChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Image1", c => c.String());
            AddColumn("dbo.Cars", "Image3", c => c.String());
            AddColumn("dbo.Cars", "Image2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Image2");
            DropColumn("dbo.Cars", "Image3");
            DropColumn("dbo.Cars", "Image1");
        }
    }
}
