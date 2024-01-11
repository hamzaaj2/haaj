namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PatientInfo_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "PatientInfo_Id");
            AddForeignKey("dbo.Orders", "PatientInfo_Id", "dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PatientInfo_Id", "dbo.Patients");
            DropIndex("dbo.Orders", new[] { "PatientInfo_Id" });
            DropColumn("dbo.Orders", "PatientInfo_Id");
        }
    }
}
