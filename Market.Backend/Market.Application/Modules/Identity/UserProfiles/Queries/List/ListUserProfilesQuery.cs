namespace Market.Application.Modules.Identity.UserProfiles.Queries.List;

public sealed class ListUserProfilesQuery : BasePagedQuery<ListUserProfilesQueryDto>
{
    public string? Search { get; init; }
    public bool? OnlyEnabled { get; init; }
}
