namespace Market.Application.Modules.Sales.Coupons.Commands.Status.Enable;

public sealed class EnableCouponCommandHandler(IAppDbContext ctx)
    : IRequestHandler<EnableCouponCommand, Unit>
{
    public async Task<Unit> Handle(EnableCouponCommand request, CancellationToken ct)
    {
        var coupon = await ctx.Coupons
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (coupon == null)
            throw new MarketNotFoundException("Coupon not found.");

        if (coupon.IsEnabled)
        {
            throw new MarketConflictException("Coupon is already enabled");
        }
        
        coupon.IsEnabled = true;
        coupon.ModifiedAtUtc = DateTime.UtcNow;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}