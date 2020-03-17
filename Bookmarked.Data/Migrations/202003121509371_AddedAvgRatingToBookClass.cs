namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvgRatingToBookClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "AvgRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "AvgRating");
        }
    }
}
