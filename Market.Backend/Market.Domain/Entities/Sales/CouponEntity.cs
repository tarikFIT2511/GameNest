// MarketUserEntity.cs
using Market.Domain.Common;

namespace Market.Domain.Entities.Sales;

public sealed class CouponEntity : BaseEntity
{
    public string Code { get; set; } //code has maximum 15 characters
    public decimal DiscountPercent { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsActive =>
    IsEnabled && (ExpirationDate == null || ExpirationDate > DateTime.UtcNow);
    
    public static class Constraints
    {
        public const int CouponMaxLength = 15;
    }
}