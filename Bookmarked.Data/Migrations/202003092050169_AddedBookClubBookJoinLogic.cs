namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookClubBookJoinLogic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookClubBookJoin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        BookId = c.Int(nullable: false),
                        BookName = c.String(),
                        BookClubId = c.Int(nullable: false),
                        BookClubName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.BookClub", t => t.BookClubId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.BookClubId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClubBookJoin", "BookClubId", "dbo.BookClub");
            DropForeignKey("dbo.BookClubBookJoin", "BookId", "dbo.Book");
            DropIndex("dbo.BookClubBookJoin", new[] { "BookClubId" });
            DropIndex("dbo.BookClubBookJoin", new[] { "BookId" });
            DropTable("dbo.BookClubBookJoin");
        }
    }
}
