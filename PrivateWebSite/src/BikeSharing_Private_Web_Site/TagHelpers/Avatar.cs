using BikeSharing_Private_Web_Site.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.TagHelpers
{
    public class Avatar : TagHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public Avatar(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ClaimsPrincipal User { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // <div class="nav-item nav-avatar hidden-xs-down" style="background-image: url(@user.ProfileImage)">
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            var user = await _userManager.GetUserAsync(User);
            output.Attributes.Add("style", $"background-image:url({user.ProfileImage})");
        }
    }
}
