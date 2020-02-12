using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Infrastructure
{
	public class AuthorizationFilterAttribute : TypeFilterAttribute
	{
		public AuthorizationFilterAttribute(string PermissionName, PermissionEnum permissionEnum) : base(typeof(AuthorizationFilter))
		{
			Arguments = new object[] { new PermissionContainer(PermissionName, permissionEnum) };
		}
	}
}
