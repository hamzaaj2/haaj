namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editeOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders");
            DropIndex("dbo.MedicineOfPatients", new[] { "OrderId" });
            AlterColumn("dbo.MedicineOfPatients", "OrderId", c => c.Int());
            CreateIndex("dbo.MedicineOfPatients", "OrderId");
            AddForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders");
            DropIndex("dbo.MedicineOfPatients", new[] { "OrderId" });
            AlterColumn("dbo.MedicineOfPatients", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicineOfPatients", "OrderId");
            AddForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
