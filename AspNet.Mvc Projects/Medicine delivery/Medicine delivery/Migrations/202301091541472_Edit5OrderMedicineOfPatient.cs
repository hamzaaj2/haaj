namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit5OrderMedicineOfPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderMedicineOfPatients", "StatusOfOrderId", "dbo.StatusOfOrders");
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "StatusOfOrderId" });
            AddColumn("dbo.Orders", "StatusOfOrderId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TimeCompleted", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Orders", "StatusOfOrderId");
            AddForeignKey("dbo.Orders", "StatusOfOrderId", "dbo.StatusOfOrders", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderMedicineOfPatients", "StatusOfOrderId");
            DropColumn("dbo.OrderMedicineOfPatients", "TimeCompleted");
            DropColumn("dbo.Orders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderMedicineOfPatients", "TimeCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderMedicineOfPatients", "StatusOfOrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "StatusOfOrderId", "dbo.StatusOfOrders");
            DropIndex("dbo.Orders", new[] { "StatusOfOrderId" });
            DropColumn("dbo.Orders", "TimeCompleted");
            DropColumn("dbo.Orders", "StatusOfOrderId");
            CreateIndex("dbo.OrderMedicineOfPatients", "StatusOfOrderId");
            AddForeignKey("dbo.OrderMedicineOfPatients", "StatusOfOrderId", "dbo.StatusOfOrders", "Id", cascadeDelete: true);
        }
    }
}
