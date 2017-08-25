namespace Stuff_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewArrivals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsNewArriva", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IsNewArriva");
        }
    }
}
