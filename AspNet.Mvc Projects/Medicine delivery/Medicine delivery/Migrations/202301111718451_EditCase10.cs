namespace Medicine_delivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCase10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "Specialty", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Cases", "Diseases", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Cases", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cases", "Name", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Cases", "Diseases");
            DropColumn("dbo.Cases", "Specialty");
        }
    }
}
