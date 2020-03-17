namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreModifiedUtcAndReviewProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookClubBookJoin", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.BookClubBookJoin", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Book", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.UserBookJoin", "Review", c => c.String());
            AddColumn("dbo.ApplicationUser", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.BookClub", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookClub", "ModifiedUtc");
            DropColumn("dbo.ApplicationUser", "ModifiedUtc");
            DropColumn("dbo.UserBookJoin", "Review");
            DropColumn("dbo.Book", "ModifiedUtc");
            DropColumn("dbo.BookClubBookJoin", "ModifiedUtc");
            DropColumn("dbo.BookClubBookJoin", "CreatedUtc");
        }
    }
}
