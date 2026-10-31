using Market.Domain.Entities.Sales;

namespace Market.Application.Modules.Sales.Coupons.Commands.Create;

public class CreateCouponCommandHandler(IAppDbContext context)
    : IRequestHandler<CreateCouponCommand, int>
{
    public async Task<int> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        string code = request.Code;
        decimal percent = request.DiscountPercent;
        var expirationDate = request.ExpirationDate;

        if (string.IsNullOrWhiteSpace(code))
            throw new ValidationException("Code is required.");
        if (code.Length > CouponEntity.Constraints.CouponMaxLength)
            throw new ValidationException("Code is too long.");
        if (percent <= 0 || percent > 100.0m) 
            throw new ValidationException("Invalid discount percentage");
        if (expirationDate != null && expirationDate < DateTime.UtcNow)
            throw new ValidationException("Expiration date can't be a date from the past.");

        // Check if a same code already exists.
        bool codeExists = await context.Coupons
            .AnyAsync(x => x.Code == code, cancellationToken);

        if (codeExists)
        {
            throw new MarketConflictException("Code already exists.");
        }

        var coupon = new CouponEntity
        {
            Code = code.Trim(),
            DiscountPercent = percent,
            ExpirationDate = expirationDate,
            IsEnabled = true,
            CreatedAtUtc = DateTime.UtcNow
        };

        context.Coupons.Add(coupon);
        await context.SaveChangesAsync(cancellationToken);

        return coupon.Id;
    }
}