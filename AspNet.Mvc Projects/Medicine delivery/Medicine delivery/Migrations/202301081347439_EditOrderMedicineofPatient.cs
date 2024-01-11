namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderMedicineofPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicineOfPatients", "OrderMedicineOfPatientId", "dbo.OrderMedicineOfPatients");
            DropIndex("dbo.MedicineOfPatients", new[] { "OrderMedicineOfPatientId" });
            RenameColumn(table: "dbo.Orders", name: "DrivertId", newName: "DriverId");
            RenameIndex(table: "dbo.Orders", name: "IX_DrivertId", newName: "IX_DriverId");
            AddColumn("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id", c => c.Int());
            CreateIndex("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id");
            AddForeignKey("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id", "dbo.OrderMedicineOfPatients", "Id");
            DropColumn("dbo.MedicineOfPatients", "OrderMedicineOfPatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicineOfPatients", "OrderMedicineOfPatientId", c => c.Int());
            DropForeignKey("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id", "dbo.OrderMedicineOfPatients");
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "OrderMedicineOfPatient_Id" });
            DropColumn("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_DriverId", newName: "IX_DrivertId");
            RenameColumn(table: "dbo.Orders", name: "DriverId", newName: "DrivertId");
            CreateIndex("dbo.MedicineOfPatients", "OrderMedicineOfPatientId");
            AddForeignKey("dbo.MedicineOfPatients", "OrderMedicineOfPatientId", "dbo.OrderMedicineOfPatients", "Id");
        }
    }
}
