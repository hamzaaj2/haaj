namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "RoleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Doctors", "RoleId");
            AddForeignKey("dbo.Doctors", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Doctors", new[] { "RoleId" });
            DropColumn("dbo.Doctors", "RoleId");
        }
    }
}
