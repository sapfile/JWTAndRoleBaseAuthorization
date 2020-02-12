using System.Collections.Generic;

namespace WebApi.Entities
{
	public class Permission
	{
		public int Id { get; set; }
		public string PermissionName { get; set; }

		public virtual  IList<PermissionRole> PermissionRoles { get; set; }
	}
}
