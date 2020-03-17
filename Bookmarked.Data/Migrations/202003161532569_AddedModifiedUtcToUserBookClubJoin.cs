namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModifiedUtcToUserBookClubJoin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBookClubJoin", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookClubJoin", "ModifiedUtc");
        }
    }
}
