namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editeMedicalTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Cases", "MedicalExaminationId", "dbo.MedicalExaminations");
            DropIndex("dbo.Cases", new[] { "MedicalExaminationId" });
            DropIndex("dbo.MedicalTests", new[] { "PatientId" });
            AddColumn("dbo.Cases", "Name", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.MedicalTests", "CaseId", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalTests", "UploadTest", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineOfPatients", "SizeOfMedicine", c => c.String());
            AlterColumn("dbo.Cases", "Note", c => c.String(maxLength: 100));
            CreateIndex("dbo.MedicalTests", "CaseId");
            AddForeignKey("dbo.MedicalTests", "CaseId", "dbo.Cases", "Id", cascadeDelete: true);
            DropColumn("dbo.Cases", "MedicalExaminationId");
            DropColumn("dbo.Cases", "ListOfMedicalExamination");
            DropColumn("dbo.MedicalTests", "PatientId");
            DropColumn("dbo.MedicineOfPatients", "ListOfMedicine");
            DropColumn("dbo.Medicines", "Size");
            DropColumn("dbo.Medicines", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicines", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.Medicines", "Size", c => c.String(maxLength: 10));
            AddColumn("dbo.MedicineOfPatients", "ListOfMedicine", c => c.String());
            AddColumn("dbo.MedicalTests", "PatientId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Cases", "ListOfMedicalExamination", c => c.String());
            AddColumn("dbo.Cases", "MedicalExaminationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MedicalTests", "CaseId", "dbo.Cases");
            DropIndex("dbo.MedicalTests", new[] { "CaseId" });
            AlterColumn("dbo.Cases", "Note", c => c.String());
            DropColumn("dbo.MedicineOfPatients", "SizeOfMedicine");
            DropColumn("dbo.MedicalTests", "UploadTest");
            DropColumn("dbo.MedicalTests", "CaseId");
            DropColumn("dbo.Cases", "Name");
            CreateIndex("dbo.MedicalTests", "PatientId");
            CreateIndex("dbo.Cases", "MedicalExaminationId");
            AddForeignKey("dbo.Cases", "MedicalExaminationId", "dbo.MedicalExaminations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
