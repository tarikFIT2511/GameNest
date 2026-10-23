namespace Market.Application.Modules.Identity.Roles.Queries.List;

public sealed class ListRolesQuery : BasePagedQuery<ListRolesQueryDto>
{
    public string? Search { get; init; }
}
