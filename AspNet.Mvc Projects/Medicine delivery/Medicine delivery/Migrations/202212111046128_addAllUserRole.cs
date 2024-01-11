namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAllUserRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "RoleId", c => c.String(maxLength: 128));
            AddColumn("dbo.Drivers", "RoleId", c => c.String(maxLength: 128));
            AddColumn("dbo.Patients", "RoleId", c => c.String(maxLength: 128));
            AddColumn("dbo.Pharmacists", "RoleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Admins", "RoleId");
            CreateIndex("dbo.Drivers", "RoleId");
            CreateIndex("dbo.Patients", "RoleId");
            CreateIndex("dbo.Pharmacists", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.Drivers", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.Patients", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.Pharmacists", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pharmacists", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Patients", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Drivers", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Admins", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Pharmacists", new[] { "RoleId" });
            DropIndex("dbo.Patients", new[] { "RoleId" });
            DropIndex("dbo.Drivers", new[] { "RoleId" });
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropColumn("dbo.Pharmacists", "RoleId");
            DropColumn("dbo.Patients", "RoleId");
            DropColumn("dbo.Drivers", "RoleId");
            DropColumn("dbo.Admins", "RoleId");
        }
    }
}
