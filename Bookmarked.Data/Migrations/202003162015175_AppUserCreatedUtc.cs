namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserCreatedUtc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "CreatedUtc");
        }
    }
}
