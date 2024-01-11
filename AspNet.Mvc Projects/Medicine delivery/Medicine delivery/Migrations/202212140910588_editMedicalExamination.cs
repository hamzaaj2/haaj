namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editMedicalExamination : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MedicalTests", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicalTests", "Name", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
