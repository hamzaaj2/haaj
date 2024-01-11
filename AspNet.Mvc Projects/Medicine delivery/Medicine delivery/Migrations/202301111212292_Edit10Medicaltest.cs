namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit10Medicaltest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalTests", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicalTests", "Note");
        }
    }
}
