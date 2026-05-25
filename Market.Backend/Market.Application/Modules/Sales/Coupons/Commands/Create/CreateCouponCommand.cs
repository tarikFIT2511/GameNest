namespace Market.Application.Modules.Sales.Coupons.Commands.Create;

public class CreateCouponCommand : IRequest<int>
{
    public required string Code { get; set; }
    public required decimal DiscountPercent { get; set; }
    public DateTime? ExpirationDate { get; set; } = null; //default null - no expiration
}