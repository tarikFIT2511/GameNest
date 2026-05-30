using Market.Domain.Entities.Sales;

namespace Market.Application.Abstractions;

// Application layer
public interface IAppDbContext
{
    DbSet<ProductEntity> Products { get; }
    DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<UserEntity> Users { get; }
    DbSet<CouponEntity> Coupons { get; }
    DbSet<RoleEntity> Roles { get; }
    DbSet<UserRoleEntity> UserRoles { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}