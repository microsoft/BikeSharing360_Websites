using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BikeSharing_Private_Web_Site.Models;

namespace BikeSharing_Private_Web_Site.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<IActionResult> Info(string id)
        {
            // Only for demo purposes
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return BadRequest("Not found");
            }

            return Ok(new {
                name = user.Name,
                image = user.ProfileImage
            });
        }
    }
}