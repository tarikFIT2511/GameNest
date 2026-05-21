namespace Market.Application.Modules.Identity.Users.Queries.List;

public sealed class ListUsersQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListUsersQuery, PageResult<ListUsersQueryDto>>
{
    public async Task<PageResult<ListUsersQueryDto>> Handle(
        ListUsersQuery request, CancellationToken ct)
    {
        var q = ctx.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Username.Contains(request.Search!));
        }

        if (request.OnlyEnabled is not null)
            q = q.Where(x => x.IsEnabled == request.OnlyEnabled);

        var projectedQuery = q.OrderBy(x => x.Username)
            .Select(x => new ListUsersQueryDto
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                IsEnabled = x.IsEnabled
            });

        return await PageResult<ListUsersQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
