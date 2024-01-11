namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "PatientInfo_Id", "dbo.Patients");
            DropIndex("dbo.Orders", new[] { "PatientInfo_Id" });
            DropColumn("dbo.Orders", "PatientInfo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "PatientInfo_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "PatientInfo_Id");
            AddForeignKey("dbo.Orders", "PatientInfo_Id", "dbo.Patients", "Id");
        }
    }
}
