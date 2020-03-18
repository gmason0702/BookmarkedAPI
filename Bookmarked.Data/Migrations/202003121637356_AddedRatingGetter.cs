namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingGetter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Book", "AvgRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "AvgRating", c => c.Double(nullable: false));
        }
    }
}
