namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCaseME : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "MedicalExaminationId2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "MedicalExaminationId2");
        }
    }
}
