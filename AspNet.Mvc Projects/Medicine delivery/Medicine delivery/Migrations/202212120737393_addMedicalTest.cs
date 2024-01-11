namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedicalTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Image = c.Binary(nullable: false),
                        UploadTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "MedicalTestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "MedicalTestId");
            AddForeignKey("dbo.Patients", "MedicalTestId", "dbo.MedicalTests", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "MedicalTestId", "dbo.MedicalTests");
            DropIndex("dbo.Patients", new[] { "MedicalTestId" });
            DropColumn("dbo.Patients", "MedicalTestId");
            DropTable("dbo.MedicalTests");
        }
    }
}
