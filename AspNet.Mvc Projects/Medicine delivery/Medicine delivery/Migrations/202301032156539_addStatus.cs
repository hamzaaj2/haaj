namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Cases", "Status");
        }
    }
}
