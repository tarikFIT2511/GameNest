namespace Market.Application.Modules.Sales.Coupons.Commands.Status.Disable;

public sealed class DisableCouponCommandHandler(IAppDbContext ctx)
    : IRequestHandler<DisableCouponCommand, Unit>
{
    public async Task<Unit> Handle(DisableCouponCommand request, CancellationToken ct)
    {
        var coupon = await ctx.Coupons
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (coupon == null)
        {
            throw new MarketNotFoundException($"Coupon not found.");
        }

        if (!coupon.IsEnabled)
        {
            throw new MarketConflictException("Coupon is already disabled.");
        }

        coupon.IsEnabled = false;
        coupon.ModifiedAtUtc = DateTime.UtcNow;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}