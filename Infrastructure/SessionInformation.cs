using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebApi.Infrastructure
{
    public interface ISessionInformation
    {
        bool IsAuthenticated { get; set; }
        int UserId { get; set; }
        int RoleId { get; set; }
    }

    public class SessionInformation : ISessionInformation
    {
        readonly IHttpContextAccessor _httpContext;
        public SessionInformation(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            IsAuthenticated = _httpContext.HttpContext.User.Identity.IsAuthenticated;
            if (IsAuthenticated)
            {
                int.TryParse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value, out var uId);
                UserId = uId;
                int.TryParse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value, out var rId);
                RoleId = rId;
            }
        }

        public bool IsAuthenticated { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
