namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editRelationMedicalTest2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalTests", "PatientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MedicalTests", "PatientId");
            AddForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalTests", "PatientId", "dbo.Patients");
            DropIndex("dbo.MedicalTests", new[] { "PatientId" });
            DropColumn("dbo.MedicalTests", "PatientId");
        }
    }
}
