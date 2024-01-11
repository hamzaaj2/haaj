namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedicalExamination : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalExaminations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MedicalTests", "MedicalExaminationId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicalTests", "MedicalExaminationId");
            AddForeignKey("dbo.MedicalTests", "MedicalExaminationId", "dbo.MedicalExaminations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalTests", "MedicalExaminationId", "dbo.MedicalExaminations");
            DropIndex("dbo.MedicalTests", new[] { "MedicalExaminationId" });
            DropColumn("dbo.MedicalTests", "MedicalExaminationId");
            DropTable("dbo.MedicalExaminations");
        }
    }
}
