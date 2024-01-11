namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editRelationMedicalTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "MedicalTestId", "dbo.MedicalTests");
            DropIndex("dbo.Patients", new[] { "MedicalTestId" });
            DropColumn("dbo.Patients", "MedicalTestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "MedicalTestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "MedicalTestId");
            AddForeignKey("dbo.Patients", "MedicalTestId", "dbo.MedicalTests", "Id", cascadeDelete: true);
        }
    }
}
