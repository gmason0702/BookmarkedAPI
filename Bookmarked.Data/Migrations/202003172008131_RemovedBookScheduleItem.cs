namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedBookScheduleItem : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BookScheduleItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookScheduleItem",
                c => new
                    {
                        ScheduleItemId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ScheduleItemTitle = c.String(nullable: false),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        EndDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ScheduleItemId);
            
        }
    }
}
