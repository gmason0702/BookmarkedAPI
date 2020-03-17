namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedGaveBookClubBookId : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.BookClub", "BookId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.BookClub", "BookId");
        }
    }
}
