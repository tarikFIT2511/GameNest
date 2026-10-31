using Market.Domain.Entities.Sales;

namespace Market.Infrastructure.Database.Configurations.Sales;

public sealed class CouponEntityConfiguration : IEntityTypeConfiguration<CouponEntity>
{
    public void Configure(EntityTypeBuilder<CouponEntity> b)
    {
        b.ToTable("Coupons");

        b.HasKey(x => x.Id);

        b.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(CouponEntity.Constraints.CouponMaxLength);

        b.HasIndex(x => x.Code)
            .IsUnique();

        b.Property(x => x.DiscountPercent)
            .IsRequired()
            .HasPrecision(5, 2);

        b.Property(x => x.IsEnabled)
            .HasDefaultValue(true);
    }
}