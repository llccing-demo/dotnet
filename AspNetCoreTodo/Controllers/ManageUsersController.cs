using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    [Authorize(Roles = Constants.AdministratorRole)]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ManageUsersController(UserManager<IdentityUser> userManager) 
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager.GetUsersInRoleAsync(Constants.AdministratorRole)).ToArray();

            var everyone = _userManager.Users.ToArray();

            var model = new ManageUsersViewModel
            {
                Adminstrators = admins,
                Everyone = everyone
            };

            return View(model);
        }
    } 
}
