namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGuidTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "OwnerId");
        }
    }
}
