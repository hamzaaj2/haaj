namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit4OrderMedicineOfPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderMedicineOfPatients", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "OrderId" });
            AlterColumn("dbo.OrderMedicineOfPatients", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderMedicineOfPatients", "OrderId");
            AddForeignKey("dbo.OrderMedicineOfPatients", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderMedicineOfPatients", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "OrderId" });
            AlterColumn("dbo.OrderMedicineOfPatients", "OrderId", c => c.Int());
            CreateIndex("dbo.OrderMedicineOfPatients", "OrderId");
            AddForeignKey("dbo.OrderMedicineOfPatients", "OrderId", "dbo.Orders", "Id");
        }
    }
}
