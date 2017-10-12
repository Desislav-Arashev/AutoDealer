namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add__Makes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Cars", "Make_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Cars", "Transmission_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cars", "Description", c => c.String(nullable: false, maxLength: 600));
            CreateIndex("dbo.Cars", "Make_Id");
            CreateIndex("dbo.Cars", "Transmission_Id");
            AddForeignKey("dbo.Cars", "Make_Id", "dbo.Makes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "Transmission_Id", "dbo.Transmissions", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "Make");
            DropColumn("dbo.Cars", "Transmission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Transmission", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Make", c => c.String(nullable: false));
            DropForeignKey("dbo.Cars", "Transmission_Id", "dbo.Transmissions");
            DropForeignKey("dbo.Cars", "Make_Id", "dbo.Makes");
            DropIndex("dbo.Transmissions", new[] { "IsDeleted" });
            DropIndex("dbo.Makes", new[] { "IsDeleted" });
            DropIndex("dbo.Cars", new[] { "Transmission_Id" });
            DropIndex("dbo.Cars", new[] { "Make_Id" });
            AlterColumn("dbo.Cars", "Description", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Cars", "Transmission_Id");
            DropColumn("dbo.Cars", "Make_Id");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Makes");
        }
    }
}
