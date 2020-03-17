namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    //public partial class fixingaddmigrations : DbMigration
    //{
    //    public override void Up()
    //    {
    //        CreateTable(
    //            "dbo.BookClubBookJoin",
    //            c => new
    //                {
    //                    Id = c.Int(nullable: false, identity: true),
    //                    OwnerId = c.Guid(nullable: false),
    //                    BookId = c.Int(nullable: false),
    //                    BookName = c.String(),
    //                    BookClubId = c.Int(nullable: false),
    //                    BookClubName = c.String(),
    //                })
    //            .PrimaryKey(t => t.Id)
    //            .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
    //            .ForeignKey("dbo.BookClub", t => t.BookClubId, cascadeDelete: true)
    //            .Index(t => t.BookId)
    //            .Index(t => t.BookClubId);
            
    //        AddColumn("dbo.UserBookClubJoin", "OwnerId", c => c.Guid(nullable: false));
    //        AddColumn("dbo.UserBookClubJoin", "UserName", c => c.String());
    //        AddColumn("dbo.UserBookClubJoin", "BookClubName", c => c.String());
    //        AddColumn("dbo.UserBookJoin", "UserName", c => c.String());
    //        AddColumn("dbo.UserBookJoin", "OwnerId", c => c.Guid(nullable: false));
    //        AddColumn("dbo.UserBookJoin", "BookName", c => c.String());
    //    }
        
    //    public override void Down()
    //    {
    //        DropForeignKey("dbo.BookClubBookJoin", "BookClubId", "dbo.BookClub");
    //        DropForeignKey("dbo.BookClubBookJoin", "BookId", "dbo.Book");
    //        DropIndex("dbo.BookClubBookJoin", new[] { "BookClubId" });
    //        DropIndex("dbo.BookClubBookJoin", new[] { "BookId" });
    //        DropColumn("dbo.UserBookJoin", "BookName");
    //        DropColumn("dbo.UserBookJoin", "OwnerId");
    //        DropColumn("dbo.UserBookJoin", "UserName");
    //        DropColumn("dbo.UserBookClubJoin", "BookClubName");
    //        DropColumn("dbo.UserBookClubJoin", "UserName");
    //        DropColumn("dbo.UserBookClubJoin", "OwnerId");
    //        DropTable("dbo.BookClubBookJoin");
    //    }
   // }

    public partial class fixingaddmigrations : DbMigration
    {
        public override void Up()
        {
            //        CreateTable(
            //            "dbo.BookClubBookJoin",
            //            c => new
            //                {
            //                    Id = c.Int(nullable: false, identity: true),
            //                    OwnerId = c.Guid(nullable: false),
            //                    BookId = c.Int(nullable: false),
            //                    BookName = c.String(),
            //                    BookClubId = c.Int(nullable: false),
            //                    BookClubName = c.String(),
            //                })
            //            .PrimaryKey(t => t.Id)
            //            .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
            //            .ForeignKey("dbo.BookClub", t => t.BookClubId, cascadeDelete: true)
            //            .Index(t => t.BookId)
            //            .Index(t => t.BookClubId);

            //        AddColumn("dbo.UserBookClubJoin", "OwnerId", c => c.Guid(nullable: false));
            //        AddColumn("dbo.UserBookClubJoin", "UserName", c => c.String());
            //        AddColumn("dbo.UserBookClubJoin", "BookClubName", c => c.String());
            //        AddColumn("dbo.UserBookJoin", "UserName", c => c.String());
            //        AddColumn("dbo.UserBookJoin", "OwnerId", c => c.Guid(nullable: false));
            //        AddColumn("dbo.UserBookJoin", "BookName", c => c.String());
        }

        public override void Down()
        {
            //        DropForeignKey("dbo.BookClubBookJoin", "BookClubId", "dbo.BookClub");
            //        DropForeignKey("dbo.BookClubBookJoin", "BookId", "dbo.Book");
            //        DropIndex("dbo.BookClubBookJoin", new[] { "BookClubId" });
            //        DropIndex("dbo.BookClubBookJoin", new[] { "BookId" });
            //        DropColumn("dbo.UserBookJoin", "BookName");
            //        DropColumn("dbo.UserBookJoin", "OwnerId");
            //        DropColumn("dbo.UserBookJoin", "UserName");
            //        DropColumn("dbo.UserBookClubJoin", "BookClubName");
            //        DropColumn("dbo.UserBookClubJoin", "UserName");
            //        DropColumn("dbo.UserBookClubJoin", "OwnerId");
            //        DropTable("dbo.BookClubBookJoin");
            //    }
        }
    }
}
