using Market.Domain.Common;

namespace Market.Domain.Entities.Identity;

public sealed class RoleEntity : BaseEntity
{
    public string Name { get; set; } //instead of commands roles will be generated in seeder
    public ICollection<UserRoleEntity> UserRoles { get; private set; }
     = new List<UserRoleEntity>();

    public static class Constraints
    {
        public const int NameMaxLength = 15;
    }
}