namespace Market.Application.Modules.Identity.UserProfiles.Queries.List;

public sealed class ListUserProfilesQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListUserProfilesQuery, PageResult<ListUserProfilesQueryDto>>
{
    public async Task<PageResult<ListUserProfilesQueryDto>> Handle(
        ListUserProfilesQuery request, CancellationToken ct)
    {
        var q = ctx.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Username.Contains(request.Search!));
        }

        if (request.OnlyEnabled != null)
            q = q.Where(x => x.IsEnabled == request.OnlyEnabled);

        var projectedQuery = q.OrderBy(x => x.Username)
            .Select(x => new ListUserProfilesQueryDto
            {
                Id = x.Id,
                Username = x.Username,
                AvatarUrl = x.Profile.AvatarUrl,
                Country = x.Profile.Country
            });

        return await PageResult<ListUserProfilesQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
