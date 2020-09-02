using BlazorAuthIssueRepro.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAuthIssueRepro.Server.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public RoleController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Roles/AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string role)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                await _userManager.AddToRoleAsync(currentUser, role);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
