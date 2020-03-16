namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModifiedUtcToUserBookJoin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBookJoin", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookJoin", "ModifiedUtc");
        }
    }
}
