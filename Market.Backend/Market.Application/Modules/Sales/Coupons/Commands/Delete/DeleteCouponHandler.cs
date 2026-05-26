namespace Market.Application.Modules.Sales.Coupons.Commands.Delete;

public class DeleteCouponHandler(IAppDbContext context)
      : IRequestHandler<DeleteCouponCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = await context.Coupons
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (coupon is null)
            throw new MarketNotFoundException("Coupon not found.");

        if (coupon.IsDeleted)
            throw new MarketConflictException("Coupon is already deleted.");

        coupon.IsDeleted = true; // Soft delete
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
