namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editReqMedicalTest2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicalTests", "UploadTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicalTests", "UploadTime", c => c.DateTime(nullable: false));
        }
    }
}
