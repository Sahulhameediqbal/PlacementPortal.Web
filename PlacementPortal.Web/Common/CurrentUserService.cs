using PlacementPortal.Application.Common;
using System.Security.Claims;

namespace PlacementPortal.Web.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;        

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public Guid UserId => new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        public string Name => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
        public string Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
        public string Role => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role) ?? string.Empty;
        public Guid CompanyId => new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue("CompanyId") ?? string.Empty);
        public Guid CollegeId => new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue("CollegeId") ?? string.Empty);
    }
}
