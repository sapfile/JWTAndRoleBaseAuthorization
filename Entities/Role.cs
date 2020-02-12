using System.Collections.Generic;

namespace WebApi.Entities
{
	public class Role
	{
		public int Id { get; set; }
		public string RoleName { get; set; }

		public virtual IList<PermissionRole> PermissionRoles { get; set; }
		public virtual IList<User> Users { get; set; }
	}
}
