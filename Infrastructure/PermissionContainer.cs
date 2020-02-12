namespace WebApi.Infrastructure
{
    public class PermissionContainer
    {
        public PermissionContainer(string permission, PermissionEnum permissionEnum)
        {
            Permission = permission;
            PermissionEnum = permissionEnum;
        }

        public string Permission { get; }
        public PermissionEnum PermissionEnum { get; }
    }
}
