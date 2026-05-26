namespace Market.Application.Modules.Sales.Coupons.Queries.List;

public sealed class ListCouponsQueryDto
{
    public required int Id { get; init; }
    public required string Code { get; init; }
    public required decimal DiscountPercent { get; init; }
    public DateTime? ExpirationDate { get; init; }
}
