namespace Stuff_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIsNewRemove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "IsNewArriva");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "IsNewArriva", c => c.Boolean(nullable: false));
        }
    }
}
