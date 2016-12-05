using System.Security.Claims;
using System.Threading.Tasks;
using BikeSharing_Private_Web_Site.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BikeSharing_Private_Web_Site.Services
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            var claimsIdentity = principal.Identity as ClaimsIdentity;
            claimsIdentity.AddClaims(new[] {
                new Claim(ClaimTypes.GivenName, user.Name),
            });

            return principal;
        }
    }
}