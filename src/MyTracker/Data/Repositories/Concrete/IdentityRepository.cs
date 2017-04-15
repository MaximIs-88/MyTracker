using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MyTracker.Data.Repositories.Abstract;
using MyTracker.Models;

namespace MyTracker.Data.Repositories.Concrete
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUser GetCurrentUser(ClaimsPrincipal user)
        {
            return _userManager.GetUserAsync(user).Result;
        }
    }
}