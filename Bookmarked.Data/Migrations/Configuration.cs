namespace Bookmarked.Data.Migrations
{
    using BookmarkedAPI.Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookmarkedAPI.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
          
            
            //The UserStore is ASP Identity's data layer. Wrap context with the UserStore.
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);

            //The UserManager is ASP Identity's implementation layer: contains the methods.
            //The constructor takes the UserStore: how the methods will interact with the database.
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            //Add or Update the initial Users into the database as normal.
            context.Users.AddOrUpdate(
                x => x.Email,  //Using Email as the Unique Key: If a record exists with the same email, AddOrUpdate skips it.
                new ApplicationUser() { FirstName = "Damon",LastName="Bailey",Email = "damo2@email.co.uk", UserName = "damo2@email.co.uk", PasswordHash = new PasswordHasher().HashPassword("Som3Pass!") },
                new ApplicationUser() { FirstName = "Karen", LastName = "Bailey", Email = "2ndUser@email.co.uk", UserName = "2ndUser@email.co.uk", PasswordHash = new PasswordHasher().HashPassword("MyPassword") }
            );

            //Save changes so the Id columns will auto-populate.
            context.SaveChanges();

            //ASP Identity User Id's are Guids stored as nvarchar(128), and exposed as strings.
            //Get the UserId only if the SecurityStamp is not set yet.
            string userId = context.Users.Where(x => x.Email == "damo2@email.co.uk" && string.IsNullOrEmpty(x.SecurityStamp)).Select(x => x.Id).FirstOrDefault();

            //If the userId is not null, then the SecurityStamp needs updating.
            if (!string.IsNullOrEmpty(userId)) userManager.UpdateSecurityStamp(userId);

            //Repeat for next user: good opportunity to make a helper method.
            userId = context.Users.Where(x => x.Email == "2ndUser@email.co.uk" && string.IsNullOrEmpty(x.SecurityStamp)).Select(x => x.Id).FirstOrDefault();

            if (!string.IsNullOrEmpty(userId)) userManager.UpdateSecurityStamp(userId);


            context.Books.AddOrUpdate(x => x.Name,
            new Book() { Name = "The Great Gatsby", Author = "F Scott Fitzgerald", Genre = "Mystery",CreatedUtc=DateTimeOffset.Now },
            new Book() { Name = "Huckleberry Finn", Author = "Mark Twain", Genre = "Adventure", CreatedUtc = DateTimeOffset.Now },
            new Book() { Name = "The Catcher in the Rye", Author = "J D Salinger", Genre = "Adult", CreatedUtc = DateTimeOffset.Now }
            );

            context.UserBookJoins.AddOrUpdate(x => x.ReaderId,
            new UserBookJoin() { ReaderId = "1c0b8895-6943-4732-9200-0ee0a3db7064", BookId = 3, Rating = 5, CreatedUtc = DateTimeOffset.Now });

        }
    }
}
