namespace Market.Application.Modules.Sales.Coupons.Queries.List;

public sealed class ListCouponsQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListCouponsQuery, PageResult<ListCouponsQueryDto>>
{
    public async Task<PageResult<ListCouponsQueryDto>> Handle(
        ListCouponsQuery request, CancellationToken ct)
    {
        var q = ctx.Coupons.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Code.Contains(request.Search!));
        }

        if (request.OnlyActive is not null)
        {
            q = q.Where(x =>
                (x.IsEnabled &&
                 (x.ExpirationDate == null || x.ExpirationDate > DateTime.UtcNow))
                 == request.OnlyActive);
        }

        var projectedQuery = q.OrderBy(x => x.Code)
            .Select(x => new ListCouponsQueryDto
            {
                Id = x.Id,
                Code = x.Code,
                DiscountPercent = x.DiscountPercent,
                ExpirationDate = x.ExpirationDate
            });

        return await PageResult<ListCouponsQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
