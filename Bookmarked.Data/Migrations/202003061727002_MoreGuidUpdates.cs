namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreGuidUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookClub", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookClub", "OwnerId");
        }
    }
}
