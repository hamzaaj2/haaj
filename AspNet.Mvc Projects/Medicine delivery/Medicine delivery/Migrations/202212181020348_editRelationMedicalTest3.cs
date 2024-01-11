namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editRelationMedicalTest3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients");
            DropIndex("dbo.MedicalTests", new[] { "PatientId" });
            AlterColumn("dbo.MedicalTests", "PatientId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.MedicalTests", "PatientId");
            AddForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients");
            DropIndex("dbo.MedicalTests", new[] { "PatientId" });
            AlterColumn("dbo.MedicalTests", "PatientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MedicalTests", "PatientId");
            AddForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients", "Id");
        }
    }
}
