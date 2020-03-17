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
        }

        //Seedmethod to create first instance of an admin

        private async System.Threading.Tasks.Task SeedDefaultRolesAndUsersAsync()
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

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
            }
            // create our first user,
            var user = new ApplicationUser() { FirstName = "UserFirstName", LastName = "UserLastName", UserName = "user@user.com", Email = "user@user.com"};
            
            IdentityResult result = await UserManager.CreateAsync(user., user.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            //var userId = User.Identity.GetUserId(user);

            //then add user to admin role

            var result = await UserManager.AddToRoleAsync(user.UserId, user.RoleName);

            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);



            //add user to dbContext, 

            // if role:"user" doesn't exist, create a "user" role
            if (!roleManager.RoleExists("User"))
            {
                new ApplicationUser { UserName = "user" };
            }


            // then add newly registered user to "user" role in the Account Controller's register method.



            return Ok();
        }
    }
}


