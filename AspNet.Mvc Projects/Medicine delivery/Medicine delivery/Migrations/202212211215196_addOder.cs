namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DrivertId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DrivertId, cascadeDelete: true)
                .Index(t => t.DrivertId);
            
            AddColumn("dbo.MedicineOfPatients", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicineOfPatients", "OrderId");
            AddForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineOfPatients", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "DrivertId", "dbo.Drivers");
            DropIndex("dbo.Orders", new[] { "DrivertId" });
            DropIndex("dbo.MedicineOfPatients", new[] { "OrderId" });
            DropColumn("dbo.MedicineOfPatients", "OrderId");
            DropTable("dbo.Orders");
        }
    }
}
