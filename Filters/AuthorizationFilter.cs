using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using WebApi.Entities;
using WebApi.Infrastructure;
using WebApi.Persistance;

namespace WebApi.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        PermissionContainer _container;
        IDbContext _context;
        ISessionInformation _session;
        public AuthorizationFilter(PermissionContainer container, IDbContext context, ISessionInformation session)
        {
            _container = container;
            _context = context;
            _session = session;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            PermissionRole pr = _context.PermissionRoles
                .FirstOrDefault(x => x.Permission.PermissionName.Equals(_container.Permission) &&
                                     x.Role.Users.Any(u => u.Id == _session.RoleId));
            bool result = false;
            if (pr != null)
            {
                result = (bool)pr.GetType().GetProperty(_container.PermissionEnum.ToString()).GetValue(pr);
            }

            if (!result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
