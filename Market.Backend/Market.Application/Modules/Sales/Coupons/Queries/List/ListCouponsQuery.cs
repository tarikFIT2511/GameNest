namespace Market.Application.Modules.Sales.Coupons.Queries.List;

public sealed class ListCouponsQuery : BasePagedQuery<ListCouponsQueryDto>
{
    public string? Search { get; init; }
    public bool? OnlyActive { get; init; }
}
