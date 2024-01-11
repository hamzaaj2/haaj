namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderMedicineOfPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders");
            DropIndex("dbo.MedicineOfPatients", new[] { "OrderId" });
            CreateTable(
                "dbo.OrderMedicineOfPatients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CaseId = c.Int(nullable: false),
                        OrderId = c.Int(),
                        StatusOfOrderId = c.Int(nullable: false),
                        TimeCompleted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.CaseId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.StatusOfOrders", t => t.StatusOfOrderId, cascadeDelete: true)
                .Index(t => t.CaseId)
                .Index(t => t.OrderId)
                .Index(t => t.StatusOfOrderId);
            
            CreateTable(
                "dbo.StatusOfOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MedicineOfPatients", "OrderMedicineOfPatientId", c => c.Int());
            AlterColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
            CreateIndex("dbo.MedicineOfPatients", "OrderMedicineOfPatientId");
            AddForeignKey("dbo.MedicineOfPatients", "OrderMedicineOfPatientId", "dbo.OrderMedicineOfPatients", "Id");
            DropColumn("dbo.MedicineOfPatients", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicineOfPatients", "OrderId", c => c.Int());
            DropForeignKey("dbo.MedicineOfPatients", "OrderMedicineOfPatientId", "dbo.OrderMedicineOfPatients");
            DropForeignKey("dbo.OrderMedicineOfPatients", "StatusOfOrderId", "dbo.StatusOfOrders");
            DropForeignKey("dbo.OrderMedicineOfPatients", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderMedicineOfPatients", "CaseId", "dbo.Cases");
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "StatusOfOrderId" });
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "OrderId" });
            DropIndex("dbo.OrderMedicineOfPatients", new[] { "CaseId" });
            DropIndex("dbo.MedicineOfPatients", new[] { "OrderMedicineOfPatientId" });
            AlterColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.MedicineOfPatients", "OrderMedicineOfPatientId");
            DropTable("dbo.StatusOfOrders");
            DropTable("dbo.OrderMedicineOfPatients");
            CreateIndex("dbo.MedicineOfPatients", "OrderId");
            AddForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders", "Id");
        }
    }
}
