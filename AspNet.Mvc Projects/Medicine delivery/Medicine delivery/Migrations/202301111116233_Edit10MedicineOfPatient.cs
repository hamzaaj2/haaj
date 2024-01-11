namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit10MedicineOfPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineOfPatients", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineOfPatients", "Name");
        }
    }
}
