namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookScheduleItemAndSchedule : DbMigration
    {
        public override void Up()
        {
        //    DropColumn("dbo.BookClub", "BookId");
        }
        
        public override void Down()
        {
        //    AddColumn("dbo.BookClub", "BookId", c => c.Int(nullable: false));
        }
    }
}
