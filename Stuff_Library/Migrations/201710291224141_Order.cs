namespace Stuff_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Orders", "UserID");
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "UserID");
            AlterColumn("dbo.Orders", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Orders", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "UserID" });
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "LastName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(maxLength: 150));
            AlterColumn("dbo.Orders", "UserID", c => c.String());
            RenameColumn(table: "dbo.Orders", name: "UserID", newName: "ApplicationUser_Id");
            AddColumn("dbo.Orders", "UserID", c => c.String());
            CreateIndex("dbo.Orders", "ApplicationUser_Id");
        }
    }
}
