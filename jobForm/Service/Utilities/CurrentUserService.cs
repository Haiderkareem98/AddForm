using jobForm.Common.Interfaces;
using jobForm.Enums;
using System.Security.Claims;

namespace jobForm.Service.Utilities
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public Roles? UserRole => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role) is { } role
            ? Enum.Parse<Roles>(role)
            : null;

        public Guid? UserId => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) is { } userId
            ? Guid.Parse(userId)
            : null;
    }
}
