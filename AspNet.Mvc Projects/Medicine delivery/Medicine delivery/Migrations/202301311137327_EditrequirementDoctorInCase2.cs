namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditrequirementDoctorInCase2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cases", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Cases", new[] { "DoctorId" });
            AlterColumn("dbo.Cases", "DoctorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Cases", "DoctorId");
            AddForeignKey("dbo.Cases", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Cases", new[] { "DoctorId" });
            AlterColumn("dbo.Cases", "DoctorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cases", "DoctorId");
            AddForeignKey("dbo.Cases", "DoctorId", "dbo.Doctors", "Id");
        }
    }
}
