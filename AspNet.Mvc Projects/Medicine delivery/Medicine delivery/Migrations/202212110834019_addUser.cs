namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        Specialty = c.String(nullable: false, maxLength: 10),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        NationalNumber = c.String(nullable: false, maxLength: 10),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 6),
                        Area = c.String(nullable: false, maxLength: 10),
                        Street = c.String(nullable: false, maxLength: 10),
                        BuildingNumber = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pharmacists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUserRoles", "Admin_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "Doctor_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "Driver_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "Patient_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "Pharmacist_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Admin_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Doctor_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Driver_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Patient_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Pharmacist_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Admin_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Doctor_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Driver_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Patient_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Pharmacist_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserClaims", "Admin_Id");
            CreateIndex("dbo.AspNetUserClaims", "Doctor_Id");
            CreateIndex("dbo.AspNetUserClaims", "Driver_Id");
            CreateIndex("dbo.AspNetUserClaims", "Patient_Id");
            CreateIndex("dbo.AspNetUserClaims", "Pharmacist_Id");
            CreateIndex("dbo.AspNetUserLogins", "Admin_Id");
            CreateIndex("dbo.AspNetUserLogins", "Doctor_Id");
            CreateIndex("dbo.AspNetUserLogins", "Driver_Id");
            CreateIndex("dbo.AspNetUserLogins", "Patient_Id");
            CreateIndex("dbo.AspNetUserLogins", "Pharmacist_Id");
            CreateIndex("dbo.AspNetUserRoles", "Admin_Id");
            CreateIndex("dbo.AspNetUserRoles", "Doctor_Id");
            CreateIndex("dbo.AspNetUserRoles", "Driver_Id");
            CreateIndex("dbo.AspNetUserRoles", "Patient_Id");
            CreateIndex("dbo.AspNetUserRoles", "Pharmacist_Id");
            AddForeignKey("dbo.AspNetUserClaims", "Admin_Id", "dbo.Admins", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Admin_Id", "dbo.Admins", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Admin_Id", "dbo.Admins", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "Doctor_Id", "dbo.Doctors", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Doctor_Id", "dbo.Doctors", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Doctor_Id", "dbo.Doctors", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "Driver_Id", "dbo.Drivers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Driver_Id", "dbo.Drivers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Driver_Id", "dbo.Drivers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "Patient_Id", "dbo.Patients", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Patient_Id", "dbo.Patients", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Patient_Id", "dbo.Patients", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "Pharmacist_Id", "dbo.Pharmacists", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Pharmacist_Id", "dbo.Pharmacists", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Pharmacist_Id", "dbo.Pharmacists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "Pharmacist_Id", "dbo.Pharmacists");
            DropForeignKey("dbo.AspNetUserLogins", "Pharmacist_Id", "dbo.Pharmacists");
            DropForeignKey("dbo.AspNetUserClaims", "Pharmacist_Id", "dbo.Pharmacists");
            DropForeignKey("dbo.AspNetUserRoles", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.AspNetUserLogins", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.AspNetUserClaims", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.AspNetUserRoles", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.AspNetUserLogins", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.AspNetUserClaims", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.AspNetUserRoles", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.AspNetUserLogins", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.AspNetUserClaims", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.AspNetUserRoles", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.AspNetUserLogins", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.AspNetUserClaims", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.AspNetUserRoles", new[] { "Pharmacist_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Patient_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Driver_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Doctor_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Admin_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Pharmacist_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Patient_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Driver_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Doctor_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Admin_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Pharmacist_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Patient_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Driver_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Doctor_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Admin_Id" });
            DropColumn("dbo.AspNetUserLogins", "Pharmacist_Id");
            DropColumn("dbo.AspNetUserLogins", "Patient_Id");
            DropColumn("dbo.AspNetUserLogins", "Driver_Id");
            DropColumn("dbo.AspNetUserLogins", "Doctor_Id");
            DropColumn("dbo.AspNetUserLogins", "Admin_Id");
            DropColumn("dbo.AspNetUserClaims", "Pharmacist_Id");
            DropColumn("dbo.AspNetUserClaims", "Patient_Id");
            DropColumn("dbo.AspNetUserClaims", "Driver_Id");
            DropColumn("dbo.AspNetUserClaims", "Doctor_Id");
            DropColumn("dbo.AspNetUserClaims", "Admin_Id");
            DropColumn("dbo.AspNetUserRoles", "Pharmacist_Id");
            DropColumn("dbo.AspNetUserRoles", "Patient_Id");
            DropColumn("dbo.AspNetUserRoles", "Driver_Id");
            DropColumn("dbo.AspNetUserRoles", "Doctor_Id");
            DropColumn("dbo.AspNetUserRoles", "Admin_Id");
            DropTable("dbo.Pharmacists");
            DropTable("dbo.Patients");
            DropTable("dbo.Drivers");
            DropTable("dbo.Doctors");
            DropTable("dbo.Admins");
        }
    }
}
