using Market.Domain.Entities.Sales;

namespace Market.Application.Modules.Sales.Coupons.Commands.Update;

public sealed class UpdateCouponCommandHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateCouponCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCouponCommand request, CancellationToken ct)
    {
        var coupon = await ctx.Coupons
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (coupon == null)
            throw new MarketNotFoundException($"Coupon not found.");

        var exists = await ctx.Coupons
            .AnyAsync(x => x.Id != request.Id && x.Code == request.Code, ct);

        // Check for duplicate code
        if (exists)
        {
            throw new MarketConflictException("Coupon code already exists.");
        }
        if (string.IsNullOrWhiteSpace(request.Code))
            throw new ValidationException("Code is required.");
         
        if (request.Code.Trim().Length > CouponEntity.Constraints.CouponMaxLength)
            throw new ValidationException("Code is too long.");
        if (request.DiscountPercent <= 0 || request.DiscountPercent > 100.0m)
            throw new ValidationException("Invalid discount percentage");
        var now = DateTime.UtcNow;
        if (request.ExpirationDate != null && request.ExpirationDate < now)
            throw new ValidationException("Expiration date can't be a date from the past.");

        coupon.Code = request.Code.Trim();
        coupon.DiscountPercent = request.DiscountPercent;
        coupon.ExpirationDate = request.ExpirationDate;
        coupon.ModifiedAtUtc = now;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}