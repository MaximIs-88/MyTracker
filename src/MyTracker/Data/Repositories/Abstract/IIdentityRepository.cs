using System.Security.Claims;
using MyTracker.Models;

namespace MyTracker.Data.Repositories.Abstract
{
    public interface IIdentityRepository
    {
        ApplicationUser GetCurrentUser(ClaimsPrincipal user);
    }
}
