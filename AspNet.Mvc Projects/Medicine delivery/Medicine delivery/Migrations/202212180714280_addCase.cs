namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        PatientId = c.String(nullable: false, maxLength: 128),
                        MedicineId = c.Int(nullable: false),
                        ListOfMedicine = c.String(),
                        MedicalExaminationId = c.Int(nullable: false),
                        ListOfMedicalExamination = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.MedicalExaminations", t => t.MedicalExaminationId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: false)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId)
                .Index(t => t.MedicineId)
                .Index(t => t.MedicalExaminationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Cases", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Cases", "MedicalExaminationId", "dbo.MedicalExaminations");
            DropForeignKey("dbo.Cases", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Cases", new[] { "MedicalExaminationId" });
            DropIndex("dbo.Cases", new[] { "MedicineId" });
            DropIndex("dbo.Cases", new[] { "PatientId" });
            DropIndex("dbo.Cases", new[] { "DoctorId" });
            DropTable("dbo.Cases");
        }
    }
}
