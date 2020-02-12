using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;

namespace WebApi.Persistance
{
    public interface IDbContext
    {
        IList<User> Users { get; set; }
        IList<Role> Roles { get; set; }
        IList<Permission> Permissions { get; set; }
        IList<PermissionRole> PermissionRoles { get; set; }
    }

    public class DbContext : IDbContext
    {
        public DbContext()
        {

            this.Users = new List<User>
                {
                    new User { Id = 1, FirstName = "Arel", LastName = "Yilmaz", Username= "arely", Password = "123", RoleId = 1 },
                    new User { Id = 2, FirstName = "Ayshe", LastName = "Yilmaz", Username= "ayshey", Password = "321", RoleId = 2},
                };

            this.Roles = new List<Role>
            {
                new Role { Id = 1, RoleName = "Admin", Users = Users.Where(x => x.FirstName.Equals("Arel")).ToList() },
                new Role { Id = 2, RoleName = "StandartUser", Users = Users.Where(x => x.FirstName.Equals("Ayshe")).ToList()},
            };

            this.Permissions = new List<Permission>
            {
                new Permission{ Id = 1, PermissionName = "GetUsers"}
            };

            this.PermissionRoles = new List<PermissionRole>
            {
                new PermissionRole
                { 
                    Id = 1, Add = true, Edit = true, Read = true, View = true, Click = true, 
                    PermissionId = 1, Permission = Permissions.FirstOrDefault(x => x.Id == 1),
                    RoleId = 1, Role = Roles.FirstOrDefault(x => x.Id == 1)
                },
                new PermissionRole
                { 
                    Id = 2, Add = false, Edit = false, Read = false, View = false, Click = false, 
                    PermissionId = 1, Permission = Permissions.FirstOrDefault(x => x.Id == 1),
                    RoleId = 2, Role = Roles.FirstOrDefault(x => x.Id == 2)
                }
            };
        }

        public IList<User> Users { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<Permission> Permissions { get; set; }
        public IList<PermissionRole> PermissionRoles { get; set; }
    }
}
