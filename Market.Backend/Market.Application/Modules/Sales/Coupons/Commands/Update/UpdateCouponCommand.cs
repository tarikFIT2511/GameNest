namespace Market.Application.Modules.Sales.Coupons.Commands.Update;

public sealed class UpdateCouponCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public required string Code { get; set; }
    public required decimal DiscountPercent { get; set; }
    public DateTime? ExpirationDate { get; set; }
}
