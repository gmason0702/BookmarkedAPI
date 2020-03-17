using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BookmarkedAPI.Data;
using BookmarkedAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using static BookmarkedAPI.Controllers.AccountController;

[assembly: OwinStartup(typeof(BookmarkedAPI.Startup))]

namespace BookmarkedAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedDefaultRolesAndUsers();
        }

        //Seedmethod to create first instance of an admin

        private void SeedDefaultRolesAndUsers()
        {
            // create dbContext
            var ctx = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

            // if Admin role doesn't exist,  create an admin role, 

            if (!roleManager.RoleExists("Admin"))
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = "Admin"
                };

                roleManager.Create(identityRole);


                // create our first user,
                var user = new ApplicationUser() { FirstName = "UserFirstName", LastName = "UserLastName", UserName = "user@user.com", Email = "user@user.com" };
                var password = "password0";
                userManager.Create(user, password);

                //var userId = User.Identity.GetUserId(user);

                //then add user to admin role

                userManager.AddToRole(user.Id, identityRole.Name);
            }

            // if role:"user" doesn't exist, create a "user" role
            if (!roleManager.RoleExists("User"))
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = "user"
                };

                roleManager.Create(identityRole);
            }
            
            
        }
    }
}


