namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit3OrderMedicineOfPatient : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderMedicineOfPatients", "MedicineOfPatientId");
            AddForeignKey("dbo.OrderMedicineOfPatients", "MedicineOfPatientId", "dbo.MedicineOfPatients", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderMedicineOfPatients", "MedicineOfPatientId", "dbo.MedicineOfPatients");
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "MedicineOfPatientId" });
        }
    }
}
