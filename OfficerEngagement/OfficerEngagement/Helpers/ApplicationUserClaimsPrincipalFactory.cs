using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficerEngagement.Models;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace OfficerEngagement.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<AppilicationUser, IdentityRole >
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<AppilicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager, options)
        {
        
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppilicationUser user)
        {
            var identity= await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", user.firstName ?? ""));
            identity.AddClaim(new Claim("UserLastName", user.LaststName ?? ""));
            identity.AddClaim(new Claim("UserLoginId", user.UserName ?? ""));
            return identity;
        }
    }
}
