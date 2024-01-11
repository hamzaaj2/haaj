namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editReqMedicalTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicalTests", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicalTests", "ImagePath", c => c.String(nullable: false));
        }
    }
}
