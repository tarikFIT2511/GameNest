namespace Market.Application.Modules.Sales.Coupons.Queries.GetById;

public class GetCouponByIdQueryDto
{
    public required int Id { get; init; }
    public required string Code { get; init; }
    public required decimal DiscountPercent { get; init; }
    public DateTime? ExpirationDate { get; init; }
    public required bool IsEnabled { get; set; }
    public required bool IsActive { get; init; }
}
