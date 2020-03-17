using BookmarkedAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookmarkedAPI.Controllers
{
    //[Authorize(Roles = "Admin")]
    [RoutePrefix("Api/Admin")]
    public class AdminController : ApiController
    {
        private ApplicationUserManager _userManager; //here is our userManager field
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ApplicationUserManager UserManager // this is our User Manager property -- copied from Account Controller
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        //[HttpGet] -- for asp.net web mvc
        //public IHttpActionResult CreateRole()
        //{
        //    return Ok();
        //}
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IHttpActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (!result.Succeeded)
                {
                    return BadRequest();
                }

                //foreach (IdentityError error in result.Errors)
                //{
                //    ModelState.AddModelError("", error.Description);
                //}
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IHttpActionResult> AddUserToRole(AddUserToRoleViewModel model)
        {
            model.UserId = User.Identity.GetUserId();  // what if a user doesn't exist
            if (model.UserId == null)
            {
                return BadRequest("Not Found");
            }

            var result = await UserManager.AddToRoleAsync(model.UserId, model.RoleName); // what if a Role doesn't exist
            if (model.RoleName == null)
            {
                return BadRequest("Not Found");
            }
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("RemoveUserFromRole")]
        public async Task<IHttpActionResult> RemoveUserFromRole(AddUserToRoleViewModel model)
        {
            model.UserId = User.Identity.GetUserId();  // what if a user doesn't exist
            if(model.UserId == null)
            {
                return BadRequest("Not Found");
            }
            var result = await UserManager.RemoveFromRoleAsync(model.UserId, model.RoleName); // what if a Role doesn't exist
            if(model.RoleName == null)
            {
                return BadRequest("Not Found");
            }
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }















        //}
        //[HttpGet]
        //public async Task<IHttpActionResult> EditUsersInRole(string roleId)
        //{
        //    ViewBag.roleId = roleId;

        //    var role = await roleManager.FindByIdAsync(roleId);

        //    if (role == null)
        //    {
        //        //ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
        //        return View("NotFound");
        //    }

        //    var model = new List<UserRoleViewModel>();

        //    foreach (var user in userManager.Users)
        //    {
        //        var userRoleViewModel = new UserRoleViewModel
        //        {
        //            UserId = user.Id,
        //            UserName = user.UserName
        //        };

        //        if (await userManager.IsInRoleAsync(user, role.Name))
        //        {
        //            userRoleViewModel.IsSelected = true;
        //        }
        //        else
        //        {
        //            userRoleViewModel.IsSelected = false;
        //        }

        //        model.Add(userRoleViewModel);
        //    }

        //    return Ok(model);

    }

}
