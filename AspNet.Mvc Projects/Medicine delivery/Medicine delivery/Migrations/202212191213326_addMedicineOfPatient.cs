namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedicineOfPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cases", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.Cases", new[] { "MedicineId" });
            CreateTable(
                "dbo.MedicineOfPatients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicineId = c.Int(nullable: false),
                        CaseId = c.Int(nullable: false),
                        Route = c.String(nullable: false, maxLength: 20),
                        Frequency = c.String(nullable: false, maxLength: 20),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        ListOfMedicine = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.CaseId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.MedicineId)
                .Index(t => t.CaseId);
            
            DropColumn("dbo.Cases", "MedicineId");
            DropColumn("dbo.Cases", "ListOfMedicine");
            DropColumn("dbo.Cases", "MedicalExaminationId2");
            DropColumn("dbo.Cases", "ListOfMedicalExaminationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cases", "ListOfMedicalExaminationDate", c => c.String());
            AddColumn("dbo.Cases", "MedicalExaminationId2", c => c.Int(nullable: false));
            AddColumn("dbo.Cases", "ListOfMedicine", c => c.String());
            AddColumn("dbo.Cases", "MedicineId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MedicineOfPatients", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.MedicineOfPatients", "CaseId", "dbo.Cases");
            DropIndex("dbo.MedicineOfPatients", new[] { "CaseId" });
            DropIndex("dbo.MedicineOfPatients", new[] { "MedicineId" });
            DropTable("dbo.MedicineOfPatients");
            CreateIndex("dbo.Cases", "MedicineId");
            AddForeignKey("dbo.Cases", "MedicineId", "dbo.Medicines", "Id", cascadeDelete: true);
        }
    }
}
