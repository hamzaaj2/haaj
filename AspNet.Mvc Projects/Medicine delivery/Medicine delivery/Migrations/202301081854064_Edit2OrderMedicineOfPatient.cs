namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit2OrderMedicineOfPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id", "dbo.OrderMedicineOfPatients");
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "OrderMedicineOfPatient_Id" });
            AddColumn("dbo.OrderMedicineOfPatients", "MedicineOfPatientId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id", c => c.Int());
            DropColumn("dbo.OrderMedicineOfPatients", "MedicineOfPatientId");
            CreateIndex("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id");
            AddForeignKey("dbo.OrderMedicineOfPatients", "OrderMedicineOfPatient_Id", "dbo.OrderMedicineOfPatients", "Id");
        }
    }
}
