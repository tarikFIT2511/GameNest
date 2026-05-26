namespace Market.Application.Modules.Sales.Coupons.Queries.GetById;

public class GetCouponByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetCouponByIdQuery, GetCouponByIdQueryDto>
{
    public async Task<GetCouponByIdQueryDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
    {
        var coupon = await context.Coupons
            .Where(c => c.Id == request.Id)
            .Select(x => new GetCouponByIdQueryDto
            {
                Id = x.Id,
                Code = x.Code,
                DiscountPercent = x.DiscountPercent,
                ExpirationDate = x.ExpirationDate,
                IsEnabled = x.IsEnabled,
                IsActive = x.IsEnabled &&
                    (x.ExpirationDate == null || x.ExpirationDate > DateTime.UtcNow)
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (coupon == null)
        {
            throw new MarketNotFoundException($"Coupon with Id {request.Id} not found.");
        }

        return coupon;
    }
}