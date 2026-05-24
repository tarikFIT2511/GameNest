// MarketUserEntity.cs
using Market.Domain.Common;
using Market.Domain.Enums;

namespace Market.Domain.Entities.Identity;

public sealed class UserProfileEntity : BaseEntity
{
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public Country Country { get; set; }
    public string ?AvatarUrl { get; set; }
    public string ?Bio { get; set; }

    public static class Constraints
    {
        public const int CountryMaxLength = 80;
        public const int BioMaxLength = 500;
    }
}