namespace WebApi.Entities
{
	public class PermissionRole
	{
		public int Id { get; set; }
		public int PermissionId { get; set; }
		public int RoleId { get; set; }
		public bool Read { get; set; }
		public bool Add { get; set; }
		public bool Edit { get; set; }
		public bool View { get; set; }
		public bool Click { get; set; }

		public virtual  Permission Permission { get; set; }
		public virtual  Role Role { get; set; }
	}
}
