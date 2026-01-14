using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketMind.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated()
        => this.User.Identity?.IsAuthenticated ?? false;
        protected string? GetUserId()
        {
            String? userId = null;

            bool isAuthenticated = this.IsUserAuthenticated();
            if (isAuthenticated)
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return userId;
        }
    }
}
