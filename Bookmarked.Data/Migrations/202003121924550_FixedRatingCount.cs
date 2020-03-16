namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedRatingCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserBookJoin", "RatingCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserBookJoin", "RatingCount", c => c.Int(nullable: false));
        }
    }
}
