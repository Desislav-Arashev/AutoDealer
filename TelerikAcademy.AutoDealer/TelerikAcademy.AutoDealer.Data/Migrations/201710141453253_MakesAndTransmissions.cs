namespace TelerikAcademy.AutoDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakesAndTransmissions : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "Make_Id", newName: "MakeId");
            RenameColumn(table: "dbo.Cars", name: "Transmission_Id", newName: "TransmissionId");
            RenameIndex(table: "dbo.Cars", name: "IX_Make_Id", newName: "IX_MakeId");
            RenameIndex(table: "dbo.Cars", name: "IX_Transmission_Id", newName: "IX_TransmissionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cars", name: "IX_TransmissionId", newName: "IX_Transmission_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_MakeId", newName: "IX_Make_Id");
            RenameColumn(table: "dbo.Cars", name: "TransmissionId", newName: "Transmission_Id");
            RenameColumn(table: "dbo.Cars", name: "MakeId", newName: "Make_Id");
        }
    }
}
