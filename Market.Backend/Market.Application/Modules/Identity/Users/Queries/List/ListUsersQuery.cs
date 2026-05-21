namespace Market.Application.Modules.Identity.Users.Queries.List;

public sealed class ListUsersQuery : BasePagedQuery<ListUsersQueryDto>
{
    public string? Search { get; init; }
    public bool? OnlyEnabled { get; init; }
}
