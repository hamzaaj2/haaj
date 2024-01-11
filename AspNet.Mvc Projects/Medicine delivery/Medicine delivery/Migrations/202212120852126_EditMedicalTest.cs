namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMedicalTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalTests", "ImagePath", c => c.String(nullable: false));
            DropColumn("dbo.MedicalTests", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicalTests", "Image", c => c.Binary(nullable: false));
            DropColumn("dbo.MedicalTests", "ImagePath");
        }
    }
}
