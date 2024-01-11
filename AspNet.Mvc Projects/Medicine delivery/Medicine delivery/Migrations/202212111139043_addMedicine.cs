namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedicine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(maxLength: 25),
                        GenericName = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 10),
                        Size = c.String(maxLength: 10),
                        HowToUse = c.String(maxLength: 100),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicines");
        }
    }
}
