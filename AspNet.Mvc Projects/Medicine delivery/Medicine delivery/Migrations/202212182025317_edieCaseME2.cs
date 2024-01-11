namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edieCaseME2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "ListOfMedicalExaminationDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "ListOfMedicalExaminationDate");
        }
    }
}
