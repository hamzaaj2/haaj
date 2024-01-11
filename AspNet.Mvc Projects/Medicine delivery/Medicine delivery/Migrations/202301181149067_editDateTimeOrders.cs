namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDateTimeOrders : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TimeCompleted", c => c.DateTime());
            DropColumn("dbo.Cases", "Note");
            DropColumn("dbo.OrderMedicineOfPatients", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderMedicineOfPatients", "Name", c => c.String());
            AddColumn("dbo.Cases", "Note", c => c.String(maxLength: 100));
            AlterColumn("dbo.Orders", "TimeCompleted", c => c.DateTime(nullable: false));
        }
    }
}
