namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingRatingHopefully : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBookJoin", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookJoin", "Rating");
        }
    }
}
