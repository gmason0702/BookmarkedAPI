namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameToTitleMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Title", c => c.String());
            DropColumn("dbo.Book", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Name", c => c.String());
            DropColumn("dbo.Book", "Title");
        }
    }
}
