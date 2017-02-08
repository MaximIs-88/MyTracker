using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MyTracker.Models;

namespace MyTracker.Controllers
{
    public class IdentityManager : IIdentityManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUser GetCurrentUser(ClaimsPrincipal user)
        {
            return _userManager.GetUserAsync(user).Result;
        }
    }

    public interface IIdentityManager
    {
        ApplicationUser GetCurrentUser(ClaimsPrincipal user);
    }
}
