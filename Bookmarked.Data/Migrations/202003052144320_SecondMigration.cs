namespace Bookmarked.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserBookClubJoin", "BookClub_BookClubId", "dbo.BookClub");
            DropForeignKey("dbo.UserBookJoin", "Book_Id", "dbo.Book");
            DropIndex("dbo.UserBookClubJoin", new[] { "BookClub_BookClubId" });
            DropIndex("dbo.UserBookJoin", new[] { "Book_Id" });
            RenameColumn(table: "dbo.UserBookClubJoin", name: "BookClub_BookClubId", newName: "BookClubId");
            RenameColumn(table: "dbo.UserBookJoin", name: "Book_Id", newName: "BookId");
            AddColumn("dbo.UserBookClubJoin", "ReaderId", c => c.String(maxLength: 128));
            AddColumn("dbo.UserBookJoin", "ReaderId", c => c.String(maxLength: 128));
            AddColumn("dbo.UserBookJoin", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.UserBookClubJoin", "BookClubId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserBookJoin", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserBookClubJoin", "ReaderId");
            CreateIndex("dbo.UserBookClubJoin", "BookClubId");
            CreateIndex("dbo.UserBookJoin", "ReaderId");
            CreateIndex("dbo.UserBookJoin", "BookId");
            AddForeignKey("dbo.UserBookClubJoin", "ReaderId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.UserBookJoin", "ReaderId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.UserBookClubJoin", "BookClubId", "dbo.BookClub", "BookClubId", cascadeDelete: true);
            AddForeignKey("dbo.UserBookJoin", "BookId", "dbo.Book", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBookJoin", "BookId", "dbo.Book");
            DropForeignKey("dbo.UserBookClubJoin", "BookClubId", "dbo.BookClub");
            DropForeignKey("dbo.UserBookJoin", "ReaderId", "dbo.ApplicationUser");
            DropForeignKey("dbo.UserBookClubJoin", "ReaderId", "dbo.ApplicationUser");
            DropIndex("dbo.UserBookJoin", new[] { "BookId" });
            DropIndex("dbo.UserBookJoin", new[] { "ReaderId" });
            DropIndex("dbo.UserBookClubJoin", new[] { "BookClubId" });
            DropIndex("dbo.UserBookClubJoin", new[] { "ReaderId" });
            AlterColumn("dbo.UserBookJoin", "BookId", c => c.Int());
            AlterColumn("dbo.UserBookClubJoin", "BookClubId", c => c.Int());
            DropColumn("dbo.UserBookJoin", "Rating");
            DropColumn("dbo.UserBookJoin", "ReaderId");
            DropColumn("dbo.UserBookClubJoin", "ReaderId");
            RenameColumn(table: "dbo.UserBookJoin", name: "BookId", newName: "Book_Id");
            RenameColumn(table: "dbo.UserBookClubJoin", name: "BookClubId", newName: "BookClub_BookClubId");
            CreateIndex("dbo.UserBookJoin", "Book_Id");
            CreateIndex("dbo.UserBookClubJoin", "BookClub_BookClubId");
            AddForeignKey("dbo.UserBookJoin", "Book_Id", "dbo.Book", "Id");
            AddForeignKey("dbo.UserBookClubJoin", "BookClub_BookClubId", "dbo.BookClub", "BookClubId");
        }
    }
}
