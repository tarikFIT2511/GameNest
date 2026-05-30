namespace Market.Application.Modules.Identity.Roles.Queries.List;

public sealed class ListRolesQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListRolesQuery, PageResult<ListRolesQueryDto>>
{
    public async Task<PageResult<ListRolesQueryDto>> Handle(
        ListRolesQuery request, CancellationToken ct)
    {
        var q = ctx.Roles.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Name.Contains(request.Search!));
        }

        var projectedQuery = q.OrderBy(x => x.Name)
            .Select(x => new ListRolesQueryDto
            {
                Id = x.Id,
                Name = x.Name,
            });

        return await PageResult<ListRolesQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
