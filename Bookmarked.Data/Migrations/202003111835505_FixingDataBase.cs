namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBookClubJoin", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookClubJoin", "Description");
        }
    }
}
