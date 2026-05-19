// MarketUserEntity.cs
using Market.Domain.Common;

namespace Market.Domain.Entities.Identity;

public sealed class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsAdmin { get; set; }
    public bool isDeveloper { get; set; }
    public bool isRegular { get; set; }
    public int TokenVersion { get; set; } = 0;// For global revocation
    public bool IsEnabled { get; set; }
    public ICollection<RefreshTokenEntity> RefreshTokens { get; private set; } = new List<RefreshTokenEntity>();
    public static class Constraints
    {
        public const int UsernameMaxLength = 30;
    }
}