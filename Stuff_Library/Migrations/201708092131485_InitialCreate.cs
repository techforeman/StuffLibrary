namespace Stuff_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
			CreateTable(
				"dbo.Categories",
				c => new
				{
					CategoryID = c.Int(nullable: false, identity: true),
					Name = c.String(),
					Description = c.String(),
					IconFilename = c.String(),
				})
				.PrimaryKey(t => t.CategoryID);

			CreateTable(
				"dbo.Courses",
				c => new
				{
					CourseID = c.Int(nullable: false, identity: true),
					CategoryID = c.Int(nullable: false),
					CourseTitle = c.String(),
					AuthorName = c.String(),
					DateAdded = c.DateTime(nullable: false),
					CovertFileName = c.String(),
					Description = c.String(),
					Votes = c.Decimal(nullable: false, precision: 18, scale: 2),
					IsHidden = c.Boolean(nullable: false),
					IsBestVoted = c.Boolean(nullable: false),
				})
				.PrimaryKey(t => t.CourseID)
				.ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
				.Index(t => t.CategoryID);

			CreateTable(
				"dbo.OrderItems",
				c => new
				{
					OrderItemID = c.Int(nullable: false, identity: true),
					OrderID = c.Int(nullable: false),
					CourseID = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.OrderItemID)
				.ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
				.ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
				.Index(t => t.OrderID)
				.Index(t => t.CourseID);

			CreateTable(
				"dbo.Orders",
				c => new
				{
					OrderID = c.Int(nullable: false, identity: true),
					UserID = c.String(),
					FirstName = c.String(maxLength: 150),
					LastName = c.String(maxLength: 150),
					Email = c.String(),
					Comment = c.String(),
					DateCreated = c.DateTime(nullable: false),
					OrderState = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.OrderID);

		}
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.OrderItems", new[] { "CourseID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
