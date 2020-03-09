namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMigrationCreateUserBookClubJoin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBookClubJoin", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.UserBookClubJoin", "UserName", c => c.String());
            AddColumn("dbo.UserBookClubJoin", "BookClubName", c => c.String());
            AddColumn("dbo.UserBookJoin", "UserName", c => c.String());
            AddColumn("dbo.UserBookJoin", "BookName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookJoin", "BookName");
            DropColumn("dbo.UserBookJoin", "UserName");
            DropColumn("dbo.UserBookClubJoin", "BookClubName");
            DropColumn("dbo.UserBookClubJoin", "UserName");
            DropColumn("dbo.UserBookClubJoin", "OwnerId");
        }
    }
}
