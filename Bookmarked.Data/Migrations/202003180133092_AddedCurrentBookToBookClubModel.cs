namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCurrentBookToBookClubModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookClubBookJoin", "ScheduleName", c => c.String());
            AddColumn("dbo.BookClubBookJoin", "StartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.BookClubBookJoin", "EndDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookClubBookJoin", "EndDate");
            DropColumn("dbo.BookClubBookJoin", "StartDate");
            DropColumn("dbo.BookClubBookJoin", "ScheduleName");
        }
    }
}
