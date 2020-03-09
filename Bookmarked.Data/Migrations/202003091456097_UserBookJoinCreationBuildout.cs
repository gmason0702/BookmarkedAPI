namespace Bookmarked.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UserBookJoinCreationBuildout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBookJoin", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookJoin", "OwnerId");
        }
    }
}
