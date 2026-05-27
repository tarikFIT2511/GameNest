// MarketUserEntity.cs
using Market.Domain.Common;

namespace Market.Domain.Entities.Identity;

public sealed class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int TokenVersion { get; set; } = 0;// For global revocation
    public bool IsEnabled { get; set; }
    public UserProfileEntity? Profile { get; set; }//for UserProfileEntity
    public ICollection<RefreshTokenEntity> RefreshTokens { get; private set; } = new List<RefreshTokenEntity>();
    public ICollection<UserRoleEntity> UserRoles { get; private set; }
    = new List<UserRoleEntity>();
    public static class Constraints
    {
        public const int UsernameMaxLength = 30;
    }
}