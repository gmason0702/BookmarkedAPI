namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingCountSet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBookJoin", "RatingCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookJoin", "RatingCount");
        }
    }
}
